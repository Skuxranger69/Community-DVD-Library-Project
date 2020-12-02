using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
{
    class MemberCollection// this class is a singleton class so that only one object is made of this class throughout the program
    {
        private static MemberCollection instance;// the instance is made of this class and object is made with the help of this
        public static MemberCollection getInstance() // this function returns the instance of the class or the object
        {
            if (instance == null)
            {
                instance = new MemberCollection();
            }
            return instance;
        }

        Collection<Member> memberCollection = new Collection<Member>();// this collection is used to store the object of class Member 

        private MemberCollection() // default construtor
        {
        
        
        }

        public void registerMember()// this function is used to register a member
        {
            try
            {
                Console.WriteLine("Enter the first name of member");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter the last name of member");
                string lastName = Console.ReadLine();
                string defaultPassword = "1111";
                Console.WriteLine("Enter the mobile number of member");
                string mobileNumber;
                while (true)
                {
                    Regex reg = new Regex(@"^[0-9]{10}$");// this is used to check if the input it a int and has length 10
                    mobileNumber = Console.ReadLine();
                    if (reg.IsMatch(mobileNumber))// checking if input id equal to Regex
                    {
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Enter a valid 10 digit mobile number");
                    }
                }
                Console.WriteLine("Enter the member residential address");
                string address = Console.ReadLine();
                Member member = new Member(firstName,lastName,mobileNumber,defaultPassword,address);// making a object of class member using the parmetrized constructor
                memberCollection.Add(member);// we are adding the object of class member to memberCollection
                Console.WriteLine("New member is added with user name: "+member.getUserName()+" and default password is: "+member.getPassword());
            }
            catch (FormatException) 
            {
                Console.WriteLine("Error: Enter valid input details");
            }
        }

        public bool findMobileNumber() // this member is used to find the mobile number of the registered member it returns true if member is found and print mobile number else false
        {
            Console.WriteLine("Enter the first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            string lastName = Console.ReadLine();
            int memberCount = memberCollection.Count;
            for (int i =0;i<memberCount;i++) 
            {
                if ((memberCollection[i].getFirstName() == firstName)&&(memberCollection[i].getLastName() == lastName))
                {
                    Console.WriteLine("Member moblie number is: "+memberCollection[i].getMobileNumber());
                    return true;
                }
            }
            return false;
        }

        public bool findUserName(string userName) // this function check wheather a given user name is right and if registered it returns true else it returns false
        {
            
            int memberCount = memberCollection.Count;
            for (int i =0;i<memberCount;i++) 
            {
                if (memberCollection[i].getUserName() == userName) 
                {
                   return true;
                }
            }
            return false;
        }

        public bool checkPassword(string userName,string password)//this function checks if the password corresponding to given user name is correct and it returns true if correct else it returns false
        {
            int memberCount = memberCollection.Count;
            for (int i=0;i<memberCount;i++) 
            {
                if ((memberCollection[i].getUserName() == userName)&& (memberCollection[i].getPassword() == password)) 
                {
                    return true;
                }
            }
            return false;
        }

        public int getIndex(string userName,string password)// this fuction returns the index of the given username and password in the memberCollection 
        {
            int memberCount = memberCollection.Count;
            for (int i = 0; i < memberCount; i++)
            {
                if ((memberCollection[i].getUserName() == userName) && (memberCollection[i].getPassword() == password))
                {
                    return i; 
                }
            }
            return -1;
        }
        public void menu(int index)// this function display the member menu
        {
            MovieCollection movieCollection = MovieCollection.getInstance();
            while (true)
            {
                Console.WriteLine("===========Member Menu===========");
                Console.WriteLine("1. Display all movie");
                Console.WriteLine("2. Borrow a movie DVD");
                Console.WriteLine("3. Return a movie  DVD");
                Console.WriteLine("4. List current borrowed movie DVDs");
                Console.WriteLine("5. Display top 10 most popular movies");
                Console.WriteLine("6. Change your password");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("================================");
                Console.WriteLine("");
                Console.WriteLine("Please make selection (1-6 or 0 to return to main menu)");
                try
                {
                    int staffChoice = Convert.ToInt32(Console.ReadLine());
                    switch (staffChoice)
                    {
                            case 1:
                            movieCollection.showAllMovie();
                            break;
                        case 2:
                            Console.WriteLine("Enter the movie name you want to borrow");
                            string movieName = Console.ReadLine();
                            bool checkMovie = movieCollection.checkMovie(movieName);// this check if the if the movie exists in the library or not
                            if (checkMovie == true)
                            {
                                int checkBorrowedMoviesCount = memberCollection[index].checkTotalBorrowedMovie();//it gives the current number of moives borrowed by the member
                                if (checkBorrowedMoviesCount < 11)// if the borrowed cout is less than 11
                                {
                                    bool checkIfAlreadyBorrowed = memberCollection[index].checkIfAlreadyBorrowed(movieName);// if the user have already borrowed that movie
                                    if (checkIfAlreadyBorrowed == true)
                                    {
                                        Console.WriteLine("You have already borrowed this movie");
                                    }
                                    else
                                    {
                                        memberCollection[index].borrowMovie(movieName);// borrow the movie to the user
                                        Console.WriteLine("You have borrowed this movie");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You currently have borrowed 10 movies you cannot borrow more");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No movie with this name exists in the library");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter the movie name you want to return");
                            string returnMovieName = Console.ReadLine();
                            bool checkBorrowed = memberCollection[index].checkBorrowed(returnMovieName);// check if the user have borrowed that movie or not
                            if (checkBorrowed == true)
                            {
                                memberCollection[index].returnMovie(returnMovieName); // returns the movie
                                Console.WriteLine("Movie have been returned");
                            }
                            else
                            {
                                Console.WriteLine("You donot have borrowed this movie");
                            }
                            break;
                        case 4:
                            memberCollection[index].currentBorrowedMovie();// display the current borrowed movie by the user
                            break;
                        case 5:
                            Console.WriteLine("Top 10 most popular movies ");
                            movieCollection.sort();// first sort the movies in the descending order of the borrowed count
                            movieCollection.showTop_10();// display the top 10 movies after the sorting
                            break;
                        case 6:
                            Console.WriteLine("Enter 4 digit new password");
                            while (true)
                            {
                                string newPassword = Console.ReadLine();
                                Regex reg = new Regex(@"^[0-9]{4}$");
                                if (reg.IsMatch(newPassword))// check wheather the password entered is integer of 4 digits
                                {
                                    memberCollection[index].setPassword(newPassword);// change the password
                                    Console.WriteLine("Password have been changed");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter a valid four digit password");
                                }
                            }
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Wrong input. Try Again");
                            break;
                    }
                }
                catch (FormatException f)
                {
                    Console.WriteLine("Error: Enter only integer values");
                }
            
            }

        }
    }
}
