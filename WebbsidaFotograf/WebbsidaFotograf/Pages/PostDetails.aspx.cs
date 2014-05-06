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
            fbdiv.Attributes["data-href"] = "http://localhost:2257/Pages/CategoryPages/Animals.aspx?Id=" + Request.QueryString["Id"];
        }

        public Blog ListView1_GetData([QueryString]int postID)
        {
            
            //postID = Convert.ToInt32(Request.QueryString["Id"]);
            return Service.GetBlogPostByID(postID);
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
    }
}