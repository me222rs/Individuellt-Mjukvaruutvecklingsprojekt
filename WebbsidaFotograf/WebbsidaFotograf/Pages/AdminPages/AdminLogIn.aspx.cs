using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbsidaFotograf.Model;
using System.Security.Cryptography;

namespace WebbsidaFotograf.Pages.AdminPages
{
    public partial class AdminLogIn : System.Web.UI.Page
    {
        
        private Service _service;
        private Service Service
        {
            get
            {
                return _service ?? (_service = new Service());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string password = Login1.Password;

            bool result = Service.UserLogin(userName, password);
            if ((result))
            {
                e.Authenticated = true;
                //Service.IsAdmin = true;
                Session["IsAdmin"] = true;
                Response.Redirect("../Home.aspx");
            }
            else
            {
                e.Authenticated = false;
            }
        }



    }
}