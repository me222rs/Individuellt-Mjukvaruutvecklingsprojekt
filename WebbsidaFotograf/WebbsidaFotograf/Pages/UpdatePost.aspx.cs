using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbsidaFotograf.Model;

namespace WebbsidaFotograf.Pages
{
    public partial class UpdatePost : System.Web.UI.Page
    {

        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BlogPostFormView_UpdateItem(int id)
        {
            WebbsidaFotograf.Model.Blog item = null;
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

            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public WebbsidaFotograf.Model.Blog BlogPostFormView_GetItem(int id)
        {
            return Service.GetBlogPostByID(id);
        }
    }
}