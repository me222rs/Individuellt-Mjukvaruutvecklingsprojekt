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
            string post = BlogContent.Text.
                Replace("\n", "<br>").
                Replace("[BOLD]", "<b>").
                Replace("[/BOLD]", "</b>").
                Replace("[ITALIC]", "<em>").
                Replace("[/ITALIC]", "</em>").
                Replace("[HEADER1]", "<h1>").
                Replace("[/HEADER1]", "</h1>").
                Replace("[HEADER2]", "<h2>").
                Replace("[/HEADER2]", "</h2>");
            string title = BlogTitle.Text;
            
            
            Service.CreateBlogPost(title, post);
            Response.Redirect("Home.aspx");
        }

        protected void BoldButton_Click(object sender, EventArgs e)
        {
            BlogContent.Font.Bold = true;
        }

        protected void ItalicButton_Click(object sender, EventArgs e)
        {

        }
    }
}