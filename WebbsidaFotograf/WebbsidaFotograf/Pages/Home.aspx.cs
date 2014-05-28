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


        //Paging av bloggposter så att sidan inte blir för lång
        protected void ListView2_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            ListViewDataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            BindListView();
        }

        void BindListView()
        {
            ListView2.DataSource = ListView1_GetData();
            ListView2.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView();
            }

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

        /// <summary>Fpag
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

    }
}