using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbsidaFotograf.Model
{
    public class BlogTags
    {
        public int TagID { get; set; }

        public string Tag { get; set; }

        public int BlogPostID { get; set; }
    }
}