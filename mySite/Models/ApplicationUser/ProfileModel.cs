using Microsoft.AspNetCore.Http;
using mySite.Models.Post;
using mySite.Models.PostComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.ApplicationUser
{
    public class ProfileModel
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string UserPoints { get; set; }

        public string ProfileImageUrl { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime RegisteredDate { get; set; }
        public IFormFile ImageUpload { get; set; }
        public DateTime LastLoginDate { get; set; }

    }
}
