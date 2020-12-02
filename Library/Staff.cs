using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Staff
    {
        MovieCollection obj = MovieCollection.getInstance();// getting the instance of the MovieCollection class
        MemberCollection memberCollection = MemberCollection.getInstance();// getting the instance of the MemberCollection class
        public void menu()// showing the staff menu
        {
            while (true)
            {
                Console.WriteLine("===========Staff Menu===========");
                Console.WriteLine("1. Add a new movie");
                Console.WriteLine("2. Remove a movie");
                Console.WriteLine("3. Register a new Member");
                Console.WriteLine("4. Find a registered member's phone number");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("================================");
                Console.WriteLine("");
                Console.WriteLine("Please make selection (1-4 or 0 to return to main menu)");
                try
                {
                    int staffChoice = Convert.ToInt32(Console.ReadLine());
                    switch (staffChoice)
                    {
                        case 1:
                            obj.addMovie();//adding movie to the library
                            Console.WriteLine("Movie have been added to Library");
                            break;
                        case 2:
                            bool check = obj.removeMovie();// removing a movie
                            if (check == true)
                            {
                                Console.WriteLine("Movie have been removed");
                            }
                            else
                            {
                                Console.WriteLine("No Movie exists with this name");
                            }
                            break;
                        case 3:
                            memberCollection.registerMember();// registering a new member
                            break;
                        case 4:
                            bool checkMobileNumber = memberCollection.findMobileNumber();// printing the mobile number of registered member
                            if (checkMobileNumber == false)
                            {
                                Console.WriteLine("No member is registered with this name");
                            }
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Wrong input by staff");
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
