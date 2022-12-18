using System;

namespace Exam.MovieDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieDatabase database= new MovieDatabase();
            Actor pesho = new Actor("1", "Pesho", 25);
            Actor gosho = new Actor("2", "Gosho", 33);

            database.AddActor( pesho );
            database.AddActor( gosho );

            Movie fastAndFurious = new Movie("1", 5, "F&F", 10, 500);
            Movie slowAndFurious = new Movie("2", 4, "S&W", 9, 4000);

         

            database.AddMovie(pesho, fastAndFurious );
            database.AddMovie(gosho,slowAndFurious );

            Console.WriteLine(database.Contains(fastAndFurious));

            var movies = database.GetMoviesInRangeOfBudget(400, 4500);
        }
    }
}
