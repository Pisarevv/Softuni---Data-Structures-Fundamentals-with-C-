using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private Dictionary<string, Actor> actorsByName = new Dictionary<string, Actor>();
        private Dictionary<string, Movie> moviesByName = new Dictionary<string, Movie>();



        public void AddActor(Actor actor)
        {
            if (!actorsByName.ContainsKey(actor.Id))
            {
                actorsByName[actor.Id] = null;
            }
            actorsByName[actor.Id] = actor;
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!actorsByName.ContainsKey(actor.Id))
            {
                throw new ArgumentException();
            }
            if (!moviesByName.ContainsKey(movie.Id))
            {
                moviesByName[movie.Id] = null;
            }
            var curractor = actorsByName[actor.Id];
            moviesByName[movie.Id] = movie;
            curractor.AddMovieToActorCollection(moviesByName[movie.Id]);
        }

        public bool Contains(Actor actor)
        {
            return this.actorsByName.ContainsKey(actor.Id);
        }

        public bool Contains(Movie movie)
        {
            return this.moviesByName.ContainsKey(movie.Id);
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            return this.actorsByName.Values.OrderByDescending(x => x.BiggestMovieBudget).ThenByDescending(x => x.Movies.Count).ToList();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return this.moviesByName.Values.ToList();
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            return this.moviesByName.Values.Where(x => x.Budget >= lower && x.Budget <= upper).OrderByDescending(x => x.Rating).ToList();
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
           return this.moviesByName.Values.OrderByDescending(x => x.Budget).ThenByDescending(x => x.Rating).ToList();
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return this.actorsByName.Values.Where(x => x.IsNewbie == true).ToList();
        }
    }
}
