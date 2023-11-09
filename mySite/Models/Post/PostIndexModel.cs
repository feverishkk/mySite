using Microsoft.AspNetCore.Authorization;
using mySite.Models.PostComment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.Post
{
    
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }
        public int CommentCount { get; set; }
        public int viewCount { get; set; }

        public bool IsAuthorAdmin { get; set; }


        public int PostCommentId { get; set; }

        public IEnumerable<PostCommentModel> Comments { get; set; }

        public IEnumerable<PostListingModel> PostListingModels { get; set; }

        

    }

    
}
