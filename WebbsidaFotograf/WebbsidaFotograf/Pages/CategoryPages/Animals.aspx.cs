using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WebbsidaFotograf.Model;
using System.Data;
using System.Web.UI.HtmlControls;
using System.ComponentModel.DataAnnotations;


namespace WebbsidaFotograf.Pages.CategoryPages
{
    #region Properties
    public partial class Animals : System.Web.UI.Page
    {
       

        private ImageProps _image;
        private ImageProps ImageProps
        {
            get { return _image ?? (_image = new ImageProps()); }
        }

        private Tags _tags;
        private Tags Tags
        {
            get { return _tags ?? (_tags = new Tags()); }
        }

        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public bool HasMessage
        {
            get
            {
                return Session["SuccessMessage"] != null;
            }
        }

        //Rättmeddelanden
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


    #endregion
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            var category = "";
            //Hämtar ut vilken kategori man har klickat sig in på
            if (Request.QueryString["Category"] != null)
            {
                Session["Category"] = Request.QueryString["Category"];
            }
            
            bool admin = Convert.ToBoolean(Session["IsAdmin"]);
            if (admin == true)
            {
                PlaceHolder1.Visible = true;
                Column1PlaceHolder.Visible = true;
                //ThumbNails.Style.Add("padding-left", "15.5%");
            }
            else
            {
                HtmlLink link = Page.Master.FindControl("Css") as HtmlLink;
                link.Href = "~/Styles/StyleSheet2.css";
                PlaceHolder1.Visible = false;
                Column1PlaceHolder.Visible = false;
            }

            

            if (HasMessage)
            {
                Success.Visible = true;
                Success.Text = SuccessMessage;
            }
            ImageProps imageProps = new ImageProps();
            var image = Request.QueryString["name"];

            
            //BigImage.ImageUrl = "~/Content/GalleryPics/" + image;
            BigImage.ImageUrl = "~/Content/" + Session["Category"] + "/" + image;

            fbdiv.Attributes["data-href"] = "http://localhost:2257/Pages/CategoryPages/Animals.aspx?name=" + Request.QueryString["name"] + "&Category=" + Request.QueryString["Category"];
            
            ImageProps.ImageName = image;
            

            //Här finns namnen på de olika kategorierna
            var categories = new List<string>(){"Djur", "Landskap", "Macro", "Porträtt"};
            if (categories.Contains(image))
            {
                BigImage.ImageUrl = "~/Content/CategoryImage/" + image + ".png";
                //DescPlaceHolder.Visible = false;
            }

            if (image == null)
            {

            }
            else
            {
                //DescPlaceHolder.Visible = true;
                string desc = GetDescriptionByImageName(image);
                string tags = GetTagsByImageName(image);
                DescriptionLiteral.Text = desc;

                ImageTags.Text = tags;
                
            }
            
            
        }
        #endregion


        public string GetDescriptionByImageName(string image) 
        {
            var desc = Service.GetDescriptionByImageName(image);
            return desc;
        }

        public string GetTagsByImageName(string image)
        {
            var tags = Service.GetTagsByImageName(image);
            return tags;
        }
        
        protected void Upload_Click(object sender, EventArgs e)
        {
            if(ModelState.IsValid)
            {
                if (FileUpload1.HasFile)
                {
                    //ImageProps imageProps = new ImageProps();


                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    var stream = FileUpload1.FileContent;
                    string description = DescriptionTextBox.Text;
                    string tags = TagTextBox.Text;
                    //imageProps.ImageName = fileName;
                    //imageProps.Description = DescriptionTextBox.Text;
                    var image = ImageProps;
                    image.Description = DescriptionTextBox.Text;
                    image.ImageName = fileName;

                    string category = Convert.ToString(Session["Category"]);
                    Service service = new Service();

                    fileName = ImageProps.SaveImage(stream, fileName, description, tags, category);
                    //service.SaveImage(image);
                    //string s = TagTextBox.Text;
                    //string[] tags = s.Split(' ');




                    SuccessMessage = String.Format("Uppladdning av {0} lyckades", fileName);
                    Response.Redirect("Animals.aspx?name=" + fileName);
                }

                else 
                {
                    throw new ApplicationException();
                }
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
            var category = Convert.ToString(Session["Category"]);
            return ImageProps.GetImageNames(category);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            //"~/Content/GalleryThumbs/" + "Penguins.jpg"
            string filePath = Server.MapPath(BigImage.ImageUrl);
            string category = Request.QueryString["Category"];
            string name = Request.QueryString["name"];
            string thumbPath = Server.MapPath("~/Content/" + category + "Thumbs" + "/" + name);

            Service service = new Service();
            var image = ImageProps;
            image.ImageName = name;
            service.DeleteImage(image);
            

            if (File.Exists(filePath) && File.Exists(thumbPath))
            {
                File.Delete(filePath);
                File.Delete(thumbPath);
            }
            SuccessMessage = String.Format("Borttagningen av denna bilden lyckades");
            Response.Redirect("Animals.aspx?name=" + Request.QueryString["name"] + "&Category=" + Session["Category"]);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<WebbsidaFotograf.Model.ImageProps> DescListView_GetData()
        {
            return Service.GetImages();
        }

        protected void UpdateDescription_Click(object sender, EventArgs e)
        {
            ImageProps imageProps = new ImageProps();
            //var image = Request.QueryString["name"];
            imageProps.ImageName = Request.QueryString["name"];

            //var description = UpdateDescriptionTextBox.Text;
            imageProps.Description = UpdateDescriptionTextBox.Text;

            //var tags = UpdateTagsTextBox.Text;
            imageProps.Tags = UpdateTagsTextBox.Text;

            Service.UpdateDescription(imageProps);
            Response.Redirect(Request.RawUrl);
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            UpdatePlaceHolder.Visible = true;
            var name = Request.QueryString["name"];
            UpdateDescriptionTextBox.Text = GetDescriptionByImageName(name);
            UpdateTagsTextBox.Text = Service.GetTagsByImageName(name);
        }
    }
}