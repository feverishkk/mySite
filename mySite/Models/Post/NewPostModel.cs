using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.Post
{
    public class NewPostModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public PostType postType { get; set; }
    }

    public enum PostType
    {
        공지 = 1,
        자유,
        뉴스,
        질문,
        후기
    }
}
