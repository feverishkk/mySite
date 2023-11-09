using mySite.Models.Post;
using mySite.Models.PostComment;
using System.Collections.Generic;

namespace mySite.Models.ApplicationUser
{
    public class ProfileListModel
    {
        public ProfileModel Profiles { get; set; }

        public IEnumerable<PostCommentModel> Comments { get; set; }
        public IEnumerable<PostListingModel> PostListings { get; set; }

    }
}
