namespace Exam.ViTube
{
    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int VideoLikes { get; set; }

        public int VideoWatches { get; set; }

        public int VideoDislikes { get; set; }

        public User(string id, string username)
        {
            Id = id;
            Username = username;
            VideoDislikes= 0;
            VideoLikes = 0;
            VideoWatches = 0;
        }

        
    }
}
