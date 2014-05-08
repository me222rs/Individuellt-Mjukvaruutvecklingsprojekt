using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbsidaFotograf.Model;
using WebbsidaFotograf.Pages.AdminPages;
using System.IO;

namespace WebbsidaFotograf.Pages
{
    public partial class Home : System.Web.UI.Page
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
            //Här Kollar jag om en admin är inloggad. Är admin inloggad så kommer det att finnas lite extra funktionalitet på sidan.
            bool admin = Convert.ToBoolean(Session["IsAdmin"]);
            //Session["IsAdmin"] = true;
            if (admin == true)
            {
                loggedIn.Visible = true;
                PlaceHolder1.Visible = true;
            }
            else 
            {
                loggedIn.Visible = false;
            }

            


        }
        /// <summary>
        /// Loggar ut användaren genom att sätta IsAdmin till false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["IsAdmin"] = false;
            Response.Redirect("Home.aspx");
        }

        /// <summary>
        /// Denna metoden hämtar ut de olika bloggposterna från databasen.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WebbsidaFotograf.Model.Blog> ListView1_GetData()
        {
            return Service.GetBlogPosts();
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }

        
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //var fileinfo = (FileInfo)e.Item.DataItem;
            }
        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    //string[] arr = (from u in Directory.GetFiles(Server.MapPath("../Content/GalleryPics")));
        //    string[] filePaths = Directory.GetFiles(Server.MapPath("../Content/GalleryPics"));
            

        //    Random random = new Random();
        //    int randomNumber = random.Next(1, 8);

        //    Image1.ImageUrl = "~/Content/GalleryPics/" + Path.GetFileName(filePaths[randomNumber]) + ".jpg";
        //}
    }
}