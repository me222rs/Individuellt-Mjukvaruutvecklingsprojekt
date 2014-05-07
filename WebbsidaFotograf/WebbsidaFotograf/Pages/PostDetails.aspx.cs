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
            //int id = Convert.ToInt32(Request.QueryString["Id"]);
            fbdiv.Attributes["data-href"] = "http://localhost:2257/Pages/CategoryPages/Animals.aspx?Id=" + Request.QueryString["Id"];
        }

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

        protected void UpdatePost_Click(object sender, EventArgs e)
        {

        }

        //protected void ListView2_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{

        //}
    }
}