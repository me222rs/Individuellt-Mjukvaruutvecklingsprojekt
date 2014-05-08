using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbsidaFotograf.Model
{
    public class Login
    {
        public int AdminID { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string Salt { get; set; }

        public string Hash { get; set; }
    }
}