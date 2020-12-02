using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library
{
    class Movie
    {
        string movieTitle;// is stores the movie title
        int numberOfDVD;// is stores the number  movie exits int the library
        int borrowedCount = 0;// the number of times movie is borrowed
        string starring;// is stores the movie starring
        string director;// is stores the movie director name
        float duration;// is stores the movie duration
        string genre;// is stores the movie genre
        string classification;// is stores the movie classification
        DateTime releaseDate;// is stores the movie release date
        
        public Movie() // this is default constructor
        {
        
        }

        public Movie(string movieTitle,int numberOfDVD,string starting,string director,float duration,string genre,string classification,DateTime releaseDate)// parameterized constructor
        {
            this.movieTitle = movieTitle;
            this.numberOfDVD = numberOfDVD;
            this.starring = starting;
            this.director = director;
            this.duration = duration;
            this.genre = genre;
            this.classification = classification;
            this.releaseDate = releaseDate;
        }

        public string getMovieTitle() // it returns the movie title
        {
            return movieTitle;
        }

        public int getNumberOfDVD()// it reuturns the number of dvd in library
        {
            return numberOfDVD;
        }

        public void borrowedCounter() // it increments the borrowed counter every time a movie is borrowed
        {
            borrowedCount = borrowedCount + 1;
        }

        public int getborrowedCount()//it returns the borrowed count
        {
            return borrowedCount;
        }
    }
}
