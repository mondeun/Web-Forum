﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Forum.Models
{
    public class PostViewModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
    }
}