﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbsidaFotograf.Model;
using WebbsidaFotograf.Pages.AdminPages;

namespace WebbsidaFotograf.Pages
{
    public partial class Home : System.Web.UI.Page
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
            bool admin = Convert.ToBoolean(Session["IsAdmin"]);
            //Session["IsAdmin"] = true;
            if (admin == true)
            {
                loggedIn.Visible = true;
            }
            else 
            {
                loggedIn.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["IsAdmin"] = false;
            Response.Redirect("Home.aspx");
        }
    }
}