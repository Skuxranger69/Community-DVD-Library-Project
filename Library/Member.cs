using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
namespace Library
{
    class Member
    {
        string firstName;//varibale to store the first name of memeber
        string lastName;//variable to store the last name of member
        string mobileNumber;// variable to store the mobile number of member
        string password; //variable to store the passoword of member
        string userName;//variable to store the user name of member
        string address;//variable to store the address of member
        Collection<string> borrowedDVD = new Collection<string>();// collection of type string to store the borrowed DVD name
        
        public Member() //default constructor 
        {
        
        }

        public Member(string firstName, string lastName, string mobileNumber, string password,string address) //parametrized constructor to intialize the variable of the Member class
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.mobileNumber = mobileNumber;
            this.password = password;
            this.address = address;
            this.userName = firstName + lastName;
        }

        public string getUserName() // this function returns the user name of member
        {
            return userName;
        }

        public string getFirstName() // this function returns the first name of member
        {
            return firstName;
        }

        public string getLastName() // this function returns the last name of member
        {
            return lastName;
        }

        public string getMobileNumber() // this function returns the mobile number of member
        {
            return mobileNumber;
        }

        public string getPassword() // this function returns the passowrd of member
        {
            return password;
        }

        public void setPassword(string password) // this function returns the changes the password of member
        {
            this.password = password;
        }

        public int checkTotalBorrowedMovie() // this function return the number of movies member has borrowed
        {
            return borrowedDVD.Count;
        }

        public bool checkIfAlreadyBorrowed(string movieName)//this finction check wheather a movie with a given name is already borrowed or not, if it is borrowed it returns true if not false
        {
            int borrowedMovieCount = borrowedDVD.Count;
            for (int i =0;i<borrowedMovieCount;i++)
            {
                if (borrowedDVD[i] == movieName)
                {
                    return true;
                }           
            }
            return false;
        }

        public void borrowMovie(string movieName)// this funvtion add the movie to the borrowedDVD collection 
        {
            borrowedDVD.Add(movieName);
        }

        public void returnMovie(string movieName) // this functions returns a movie
        {
            int borrowedMovieCount = borrowedDVD.Count;
            for (int i=0;i<borrowedMovieCount;i++)
            {
                if (borrowedDVD[i] == movieName) 
                {
                    borrowedDVD.RemoveAt(i);
                }
            }
        }

        public void currentBorrowedMovie() // this functions displays the name of the current borrowed movie
        {
            int borrowedMovieCount = borrowedDVD.Count;
            Console.WriteLine("Current borrowed movie are ");
            for (int i = 0; i < borrowedMovieCount; i++)
            {
                Console.WriteLine(borrowedDVD[i]);
            }
        }

        public bool checkBorrowed(string movieName) // this function checks whether a movie is borrowed or not
        {
            int borrowedMovieCount = borrowedDVD.Count;
            for (int i = 0; i < borrowedMovieCount; i++)
            {
                if(borrowedDVD[i] == movieName)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
