using mySite.Models.Post;
using mySite.Models.PostComment;
using System.Collections.Generic;

namespace mySite.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }

        public IEnumerable<PostListingModel> LatestPosts { get; set; }

        public IEnumerable<PostCommentModel> LatestComments { get; set; }

        public virtual IEnumerable<ApplicationUser.ProfileModel> Users { get; set; }

    }
}
