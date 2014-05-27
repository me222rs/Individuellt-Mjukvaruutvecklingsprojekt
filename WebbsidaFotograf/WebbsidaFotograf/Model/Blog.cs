using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebbsidaFotograf.Model
{
    public class Blog
    {
        #region Properties
        
        public int BlogPostID { get; set; }


        [Required(ErrorMessage = "En titel måste anges.")]
        [StringLength(40, ErrorMessage = "Titeln kan bestå av som mest 40 tecken.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "En post måste anges.")]
        [StringLength(30, ErrorMessage = "Posten kan bestå av som mest 2000 tecken.")]
        public string Post { get; set; }


        public DateTime Date { get; set; }
        #endregion
    }
}