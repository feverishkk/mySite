﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.Post
{
    public class DeletePostModel
    {
        public int PostId { get; set; }
        public string PostAuthor { get; set; }
        public string PostTitle { get; set; }

    }
}
