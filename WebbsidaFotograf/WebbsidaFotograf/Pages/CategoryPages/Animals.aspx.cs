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

        public bool HasMessage
        {
            get
            {
                return Session["SuccessMessage"] != null;
            }
        }

        private string SuccessMessage
        {
            get
            {

                var message = Session["SuccessMessage"] as string;
                Session.Remove("SuccessMessage");
                return message;
            }
            set
            {
                Session["SuccessMessage"] = value;
            }
        }

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HasMessage)
            {
                Success.Visible = true;
                Success.Text = SuccessMessage;
            }

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

                SuccessMessage = String.Format("Uppladdning av {0} lyckades", fileName);
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
            string name = Request.QueryString["name"];
            string thumbPath = Server.MapPath("~/Content/GalleryThumbs/" + name);

            if (File.Exists(filePath) && File.Exists(thumbPath))
            {
                File.Delete(filePath);
                File.Delete(thumbPath);
            }
            SuccessMessage = String.Format("Borttagningen av {0} lyckades", name);
            Response.Redirect("Animals.aspx");
        }
    }
}