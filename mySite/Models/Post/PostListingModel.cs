using Microsoft.AspNetCore.Authorization;
using mySite.Models.ApplicationUser;
using mySite.Models.PostComment;
using mySite.Utility;
using System.Collections.Generic;

namespace mySite.Models.Post
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }
        public string AuthorImageUrl { get; set; }

        public string PostContent { get; set; }
        public int viewCount { get; set; }

        public PostType postType { get; set; }

        public enum PostType
        {
            
            공지 = 1,
            자유,
            뉴스,
            질문,
            후기
        }

        public int CommentCount { get; set; }

        public bool IsAuthorAdmin { get; set; }

        public ProfileModel ProfileModels { get; set; }

        public IEnumerable<PostCommentModel> Comments { get; set; }

    }

    
}
