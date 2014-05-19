using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbsidaFotograf.Model;
using System.Web.ModelBinding;

namespace WebbsidaFotograf.Pages
{
    public partial class PostDetails : System.Web.UI.Page
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
                PlaceHolder1.Visible = true;
            }
            else
            {
                PlaceHolder1.Visible = false;
            }

            //Gör så att facebookkommentarerna läggs på en unik url för varje blogginlägg
            fbdiv.Attributes["data-href"] = "http://localhost:2257/Pages/CategoryPages/Animals.aspx?Id=" + Request.QueryString["Id"];
        }

        /// <summary>
        /// Hämtar ut en querystring som innehåller ett id som skickas vidare till service klassen
        /// </summary>
        /// <param name="postID"></param>
        /// <returns></returns>
        public Blog ListView2_GetData(int? postID)
        {
            postID = Convert.ToInt32(Request.QueryString["Id"]);
            return Service.GetBlogPostByID(postID);
        }


        protected void Delete_Click(object sender, EventArgs e)
        {
            int? postID = Convert.ToInt32(Request.QueryString["Id"]);
            Service.DeleteBlogPost(postID);
            Response.Redirect("Home.aspx");
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BlogPostFormView_UpdateItem(int? id)
        {
            id = Convert.ToInt32(Request.QueryString["Id"]);
            //WebbsidaFotograf.Model.Blog item = null;
            var item = Service.GetBlogPostByID(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                Service.SaveChanges(item);
            }
        }

        public WebbsidaFotograf.Model.Blog BlogPostFormView_GetItem(int? blogPostID)
        {
            blogPostID = Convert.ToInt32(Request.QueryString["Id"]);
            return Service.GetBlogPostByID(blogPostID);

            
            
            
        
        }

    //    protected void PostTextBox_Load(object sender, EventArgs e)
    //    {
    //        Blog blog = new Blog();
    //        blog.Post = blog.Post.
    //Replace("<br>", "\n").
    //Replace("<b>", "[BOLD]").
    //Replace("</b>", "[/BOLD]").
    //Replace("<em>", "[ITALIC]").
    //Replace("</em>", "[/ITALIC]").
    //Replace("<h1>", "[HEADER1]").
    //Replace("</h1>", "[/HEADER1]").
    //Replace("<h2>", "[HEADER2]").
    //Replace("</h2>", "[/HEADER2]");
    //    }

        //protected void ListView2_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{

        //}
    }
}