using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WebbsidaFotograf.Model;


namespace WebbsidaFotograf.Pages.CategoryPages
{
    public partial class Animals : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            var image = Request.QueryString["name"];
            BigImage.ImageUrl = "~/Content/GalleryPics/" + image;

        }
        #endregion

        
        protected void Upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {

                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                var stream = FileUpload1.FileContent;

                Service hej = new Service();
                var name = Service.SaveImage(stream, fileName);
                Response.Redirect("Animals.aspx?name=" + name);

            }

        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //var fileinfo = (FileInfo)e.Item.DataItem;
            }
        }

        public IEnumerable<string> Repeater1_GetData()
        {
            return Service.GetImageNames();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            //"~/Content/GalleryThumbs/" + "Penguins.jpg"
            string filePath = Server.MapPath(BigImage.ImageUrl);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            Response.Redirect("Animals.aspx");
        }
    }
}