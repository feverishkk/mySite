using mySite.Models.PostComment;
using mySite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.Post
{
    public class PostMainPageModel
    {
        
        public IEnumerable<PostListingModel> PostListingModels { get; set; }

        public IEnumerable<PostCommentModel> PostCommentModels { get; set; }

        public IEnumerable<PostIndexModel> PostIndexModels { get; set; }

        public string SearchQuery { get; set; }
    }
}
