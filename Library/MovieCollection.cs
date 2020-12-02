using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Library
{
    class MovieCollection
    {
        public Collection<Movie> movieCollection = new Collection<Movie>();// creating a collection of class Movie to store its object
        private static MovieCollection instance;// creating a instance of class MovieCollection
        
        public static MovieCollection getInstance() // this function returns the object of class MovieCollection
        {
            if (instance == null) 
            {
                instance = new MovieCollection();
            }
            return instance;
        }

        private MovieCollection() // constructor
        {
        
        }

        public void addMovie() // this functions add a movie in the library
        { 
            try
            {
                Console.WriteLine("Enter the movie title");
                string movieName = Console.ReadLine();
                Console.WriteLine("Enter the number of DVD avaliable");
                int numberOfDVD = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the starring");
                string starting = Console.ReadLine();
                Console.WriteLine("Enter the director name");
                string director = Console.ReadLine();
                Console.WriteLine("Enter the duration of movie");
                float duration = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter the genre: Drama,Adventure,Family,Action, Sci - Fi, Comedy, Animated, Thriller, or Other");
                string genre;
                while (true) 
                {
                    genre = Console.ReadLine();
                    if (genre.Equals("Drama") || genre.Equals("Adventure") || genre.Equals("Family") || genre.Equals("Action") || genre.Equals("Sci - Fi") || genre.Equals("Comedy") || genre.Equals("Animated") || genre.Equals("Thriller") || genre.Equals("Other"))
                    {
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Please enter one of these Drama,Adventure,Family,Action, Sci - Fi, Comedy, Animated, Thriller, or Other");
                    }
                }
                Console.WriteLine("Enter the classification :G, PG, M15+, or MA15+");
                string classification;
                while (true) 
                {
                    classification = Console.ReadLine();
                    if (classification.Equals("G")||classification.Equals("PG")||classification.Equals("M15+")||classification.Equals("MA15+")) 
                    {
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Enter one of these G, PG, M15+, or MA15+");
                    }
                
                }
                Console.WriteLine("Enter the release date");
                DateTime releaseDate = Convert.ToDateTime(Console.ReadLine());
                Movie movieObj = new Movie(movieName, numberOfDVD, starting, director, duration, genre, classification, releaseDate);// creating an object of class movie
                movieCollection.Add(movieObj);// adding the object of class movie to the collection movieCollection
                Console.WriteLine("Movie is added");
            }
            catch (FormatException) 
            {
                Console.WriteLine("Enter a valid value for date it is dd/mm/yyyy");
            }
        }

        public bool removeMovie() // to remove a movie returns true if movie exits and remove it if movie doesnot exists it returns false
        {
            Console.WriteLine("Enter the movie name to be removed");
            string movieName = Console.ReadLine();
            int collectionCount = movieCollection.Count;
            for (int i = 0;i<collectionCount;i++)
            {
                if (movieCollection[i].getMovieTitle() == movieName)
                {
                    movieCollection.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        // 
        public void showAllMovie() // it prints all the movie stored in the library
        {
            Console.WriteLine("Showing all the movie titles");
            int movieCount = movieCollection.Count;
            for (int i =0;i<movieCount;i++)
            {
                Console.WriteLine(movieCollection[i].getMovieTitle()+" "+movieCollection[i].getNumberOfDVD());
            }
        }

        public bool checkMovie(string movieName) // this fuction check if the movie exits int the library and returns true else it returns false
        {
            int movieCount = movieCollection.Count;
            for (int i=0;i<movieCount;i++) 
            {
                if (movieCollection[i].getMovieTitle() == movieName) 
                {
                    movieCollection[i].borrowedCounter();
                    return true;
                }
            }
            return false;
        }

        public void sort()// this functions sorts the movie in descending order of the boroowed count of the movie
        {
            int movieCount = movieCollection.Count;
            for (int i = 0; i < movieCount - 1; i++)
                for (int j = i + 1; j < movieCount; j++)
                    if (movieCollection[i].getborrowedCount() > movieCollection[j].getborrowedCount())
                    {
                        Movie temp = new Movie("", 0,"","",0,"","", DateTime.Now);
                        temp = movieCollection[i];
                        movieCollection[i] = movieCollection[j];
                        movieCollection[j] = temp;

                    }

        }
        public void showTop_10()// this function print the top 10 movies after the sorting is done
        {
            int movieCount = movieCollection.Count;
            if (movieCount > 10)
            {
                movieCount = 10;
            }
            Console.WriteLine("Showing Top {0} Movies", movieCount);
            for (int i = 0; i < movieCount; i++)
            {
                Console.WriteLine(movieCollection[i].getMovieTitle());
            }
        }


    }
}
