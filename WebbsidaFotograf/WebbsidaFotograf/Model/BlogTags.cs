using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebbsidaFotograf.Model
{
    public class BlogTags
    {
        public int TagID { get; set; }

        
        [StringLength(200, ErrorMessage = "Alla taggar kan totalt bestå av som mest 200 tecken.")]
        public string Tag { get; set; }

        public int BlogPostID { get; set; }
    }
}