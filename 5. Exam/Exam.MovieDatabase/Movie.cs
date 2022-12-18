namespace Exam.MovieDatabase
{
    public class Movie
    {
        public string Id { get; set; }

        public int DurationInMinutes { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public double Budget { get; set; }

        public Movie(string id, int durationInMinutes, string title, double rating, double budget)
        {
            Id = id;
            DurationInMinutes = durationInMinutes;
            Title = title;
            Rating = rating;
            Budget = budget;
        }

        public override bool Equals(object obj)
        {
            return Id == ((Movie)obj).Id;
        }

         
    }
}
