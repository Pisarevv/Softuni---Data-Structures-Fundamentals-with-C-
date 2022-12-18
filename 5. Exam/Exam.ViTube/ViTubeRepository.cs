using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        public Dictionary<string, Video> videosByName = new Dictionary<string, Video>();
        public Dictionary<string, User> usersByName = new Dictionary<string, User>();


        public bool Contains(User user)
        {
            return this.usersByName.ContainsKey(user.Id);
        }

        public bool Contains(Video video)
        {
            return this.videosByName.ContainsKey(video.Id);
        }

        public void DislikeVideo(User user, Video video)
        {
            var takenUser = this.usersByName.ContainsKey(user.Id);
            var takenVideo = this.videosByName.ContainsKey(video.Id);
            if (takenVideo == false || takenUser == false)
            {
                throw new ArgumentException();
            }
            videosByName[video.Id].Dislikes++;
            usersByName[user.Id].VideoDislikes++;
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            return this.usersByName.Values.Where(x => x.VideoLikes == 0 && x.VideoDislikes == 0 && x.VideoWatches == 0);
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            return this.usersByName.Values.OrderByDescending(x => x.VideoWatches).ThenByDescending(x => x.VideoLikes).ThenByDescending(x => x.VideoDislikes).ThenBy(x => x.Username).ToArray();
            
        }

        public IEnumerable<Video> GetVideos()
        {
            return this.videosByName.Values.ToArray();
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            return this.videosByName.Values.OrderByDescending(x => x.Views).ThenByDescending(x => x.Likes).ThenBy(x=> x.Dislikes).ToArray();
        }

        public void LikeVideo(User user, Video video)
        {

            var takenUser = this.usersByName.ContainsKey(user.Id);
            var takenVideo = this.videosByName.ContainsKey(video.Id);
            if(takenVideo == false || takenUser == false)
            {
                throw new ArgumentException();
            }
            videosByName[video.Id].Likes++;
            usersByName[user.Id].VideoLikes++;
        }

        public void PostVideo(Video video)
        {
            if (!videosByName.ContainsKey(video.Id))
            {
                videosByName[video.Id] = null;
            }
            videosByName[video.Id] = video;
        }

        public void RegisterUser(User user)
        {
            if (!usersByName.ContainsKey(user.Id))
            {
                usersByName[user.Id] = null;
            }
            usersByName[user.Id] = user;
        }

        public void WatchVideo(User user, Video video)
        {
            var takenUser = this.usersByName.ContainsKey(user.Id);
            var takenVideo = this.videosByName.ContainsKey(video.Id);
            if (takenVideo == false || takenUser == false)
            {
                throw new ArgumentException();
            }
            videosByName[video.Id].Views++;
            usersByName[user.Id].VideoWatches++;
        }
    }
}
