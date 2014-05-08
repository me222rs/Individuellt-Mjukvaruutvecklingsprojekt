using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbsidaFotograf.Model;

namespace WebbsidaFotograf.Pages
{
    public partial class CreateBlogPost : System.Web.UI.Page
    {

        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        private Blog _blog;
        private Blog Blog
        {
            get { return _blog ?? (_blog = new Blog()); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            bool admin = Convert.ToBoolean(Session["IsAdmin"]);
            //Session["IsAdmin"] = true;
            if (admin == true)
            {
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = false;
            }
            else
            {
                PlaceHolder1.Visible = false;
                PlaceHolder2.Visible = true;
            }
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            string title = BlogTitle.Text;
            string post = BlogContent.Text;
            Service.CreateBlogPost(title, post);
            Response.Redirect("Home.aspx");
        }
    }
}