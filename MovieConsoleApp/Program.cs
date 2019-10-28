using System;
using System.Collections.Generic;
using System.IO;

namespace MovieConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = @"C:\Code\MovieConsoleApp\MovieConsoleApp\MovieData.txt";

            String currentMovieList = LoadCurrentMovieList(textPath);


            Console.WriteLine("Welcome to the MovieAPP");

            Console.WriteLine("Here is the movies we currently house in our database file");

            ReadAndFormat(textPath);

            bool continuationFlag = true;

            while (continuationFlag)
            {
                List<Movie> movies = new List<Movie>();

                Console.WriteLine("Please enter a movie title.");
                string inputTitle = Console.ReadLine();

                Console.WriteLine("Please enter a movie genre.");
                string inputGenre = Console.ReadLine();

                Console.WriteLine("Please enter a movie year.");
                string inputYear = Console.ReadLine();

                Movie movie = new Movie(inputTitle, inputGenre, inputYear);

                movies.Add(movie);


                List<string> movieCollection = new List<string>();

                //Ensures current movie list will be written to the new file writing
                movieCollection.Add(currentMovieList);

                foreach (Movie item in movies)
                {
                    movieCollection.Add($"{item.MovieTitle}|{item.Genre}|{item.YearMade}");
                }


                WriteToFile(textPath, movieCollection);

                Console.WriteLine("This is the updated Movie Database: ");

                ReadAndFormat(textPath);

                Console.WriteLine("Would you like to enter another entry? y or n");
                string keepGoing = Console.ReadLine();

                if (keepGoing != null && keepGoing.ToLower() != "y")
                {
                    continuationFlag = false;
                }

            }

            Console.WriteLine("We appreciate your entries. Please come again.");
        }

        private static void WriteToFile(string textPath, List<string> movieCollection)
        {
            using (StreamWriter sw = new StreamWriter(textPath))
            {
                foreach (string movieItem in movieCollection)
                {
                    sw.WriteLine(movieItem);
                }
            }
        }

        private static string LoadCurrentMovieList(string textPath)
        {
            //loads current movie list
            string currentMovieList;

            using (StreamReader sr = new StreamReader(textPath))
            {
                currentMovieList = sr.ReadToEnd().TrimEnd();
            }

            return currentMovieList;
        }

        private static void ReadAndFormat(string textPath)
        {
            using (StreamReader sr = new StreamReader(textPath))
            {
                string line = sr.ReadToEnd();

                string[] textArray = line.Split('|');

                foreach (var formattedLine in textArray)
                {
                    Console.Write($"{formattedLine} ");
                }

                Console.WriteLine();
            }
        }
    }
}
