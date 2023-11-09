using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mySite.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int ViewCount { get; set; }

        public DateTime Created { get; set; }

        public PostType postType { get; set; }

        public enum PostType
        {
            공지 = 1,
            자유,
            뉴스,
            질문,
            후기
        }

        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<PostComment> Comments { get; set; }

    }

    
}
