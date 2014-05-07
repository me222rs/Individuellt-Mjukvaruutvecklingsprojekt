using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbsidaFotograf.Model
{
    public class Blog
    {
        #region Properties
        public int BlogPostID { get; set; }

        public string Title { get; set; }

        public string Post { get; set; }

        public DateTime Date { get; set; }
        #endregion
    }
}