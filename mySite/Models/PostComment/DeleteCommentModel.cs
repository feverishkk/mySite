using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.PostComment
{
    public class DeleteCommentModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
    }
}
