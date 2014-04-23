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
        private ImageProps _image;
        private ImageProps ImageProps
        {
            get { return _image ?? (_image = new ImageProps()); }
        }

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
            bool admin = Convert.ToBoolean(Session["IsAdmin"]);
            if (admin == true)
            {
                PlaceHolder1.Visible = true;
            }
            else
            {
                PlaceHolder1.Visible = false;
            }

            if (HasMessage)
            {
                Success.Visible = true;
                Success.Text = SuccessMessage;
            }

            var image = Request.QueryString["name"];
            BigImage.ImageUrl = "~/Content/GalleryPics/" + image;

            fbdiv.Attributes["data-href"] = "http://localhost:2257/Pages/CategoryPages/Animals.aspx?name=" + Request.QueryString["name"];

        }
        #endregion

        
        protected void Upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //ImageProps imageProps = new ImageProps();
                
                
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                var stream = FileUpload1.FileContent;
                
                //imageProps.ImageName = fileName;
                //imageProps.Description = DescriptionTextBox.Text;
                var image = ImageProps;
                image.Description = DescriptionTextBox.Text;
                image.ImageName = fileName;

                Service service = new Service();
                ImageProps.SaveImage(stream, fileName);
                //service.SaveImage(image);


                SuccessMessage = String.Format("Uppladdning av {0} lyckades", fileName);
                Response.Redirect("Animals.aspx?name=" + fileName);

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
            return ImageProps.GetImageNames();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            //"~/Content/GalleryThumbs/" + "Penguins.jpg"
            string filePath = Server.MapPath(BigImage.ImageUrl);
            string name = Request.QueryString["name"];
            string thumbPath = Server.MapPath("~/Content/GalleryThumbs/" + name);

            Service service = new Service();
            var image = ImageProps;
            image.ImageName = name;
            service.DeleteImage(image);

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