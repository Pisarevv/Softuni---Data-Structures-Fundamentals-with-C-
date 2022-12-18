using System.Collections.Generic;

namespace Exam.MovieDatabase
{
    public class Actor
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double BiggestMovieBudget { get; set; }

        public bool IsNewbie { get; set; }

        public List<Movie> Movies;

        public Actor(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
            BiggestMovieBudget = 0;
            IsNewbie = true;
            Movies = new List<Movie>();
        }

        public void AddMovieToActorCollection(Movie movie)
        {
            Movies.Add(movie);
            IsNewbie = false;
            if(movie.Budget > BiggestMovieBudget)
            {
                BiggestMovieBudget = movie.Budget;
            }
        }



    }
}
