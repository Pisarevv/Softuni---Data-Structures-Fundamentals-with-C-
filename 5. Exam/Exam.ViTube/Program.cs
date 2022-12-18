using System;

namespace Exam.ViTube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ViTubeRepository repository = new ViTubeRepository();

            Video video = new Video("1", "ASD", 4, 0, 0, 0);
            Video video1 = new Video("12", "AS2D", 4, 0, 2, 0);
            User user = new User("1s", "Petko");
           // repository.PostVideo(video);
            //repository.PostVideo(video1);
            var videos = repository.GetVideosOrderedByViewsThenByLikesThenByDislikes();



        }
    }
}
