using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.PostComment
{
    public class PostCommentModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime Created { get; set; }
        public int AuthorPoints { get; set; }
        public string CommentContent { get; set; }
        public bool IsAuthorAdmin { get; set; }

    }
}
