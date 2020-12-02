using System;
using System.IO;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Library
{
    class Program// this is the main class 
    { 

        static void Main(string[] args)
        {
            int userMainMenuChoice;// this variable is used to store the choice entered by the user
            while (true)// infinte loop till  the user press 0 it will run
            {
                Console.WriteLine("Welcome to the Community Library");
                Console.WriteLine("===========Main Menu============");
                Console.WriteLine("1. Staff Login");
                Console.WriteLine("2. Member Login");
                Console.WriteLine("0. Exit");
                Console.WriteLine("================================");
                Console.WriteLine();
                Console.WriteLine("Please make a selection (1-2, or 0 to exit):");
                try
                {
                    userMainMenuChoice = Convert.ToInt32(Console.ReadLine());// taking the user input
                    switch (userMainMenuChoice)
                    {
                        case 1:// if 1 is pressed by user
                            Console.WriteLine("Enter the username");
                            string staffUserName = Console.ReadLine();
                            if (staffUserName == "staff")// checking if the username entered by the user is correct
                            {
                                Console.WriteLine("Enter the password");
                                string staffPassword = Console.ReadLine();
                                if (staffPassword == "today123")// checking if the password entered by the user is correct
                                {
                                    Staff s = new Staff();// making the object of class Staff 
                                    s.menu();// calling the menu function of class staff using object s
                                }
                                else 
                                {
                                    Console.WriteLine("Wrong password entered");
                                }
                            }
                            else 
                            {
                                Console.WriteLine("Wrong username");
                            }
                            break;
                        case 2:// if 2 is enterd by user
                            MemberCollection memberCollection = MemberCollection.getInstance();// getting the instance of class member function
                            Console.WriteLine("Enter the userName");
                            string userName = Console.ReadLine();
                            bool checkUserName = memberCollection.findUserName(userName);// checking if the user name enterd by the user in correct
                            if (checkUserName == true)
                            {
                                Console.WriteLine("Enter the password");
                                string password = Console.ReadLine();
                                Regex reg = new Regex(@"^[0-9]{4}$");
                                if (reg.IsMatch(password))// checking if the password enterd is a 4 digit integer
                                {
                                    bool checkPassword = memberCollection.checkPassword(userName,password);// cheking if the passowrd entered by the user corresponding to the user name is correct
                                    if (checkPassword == true)
                                    {
                                      int index =  memberCollection.getIndex(userName,password);// getting the index of the member of corresponding username and password
                                      memberCollection.menu(index);// showing the menu of the corresponding member
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Wrong Password");
                                    }
                                }
                                else 
                                {
                                    Console.WriteLine("Enter four digit int only");
                                }
                            }
                            else 
                            {
                                Console.WriteLine("Worng user name entered");
                            }
                            break;
                        case 0:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Wrong input");
                            break;

                    }
                }
                catch(FormatException) 
                {
                    Console.WriteLine("Error: Enter only integer values");
                }
                
            }
        }
    }
}
