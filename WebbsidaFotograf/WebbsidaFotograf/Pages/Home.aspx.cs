using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbsidaFotograf.Model;
using WebbsidaFotograf.Pages.AdminPages;
using System.IO;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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



       

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    //string[] arr = (from u in Directory.GetFiles(Server.MapPath("../Content/GalleryPics")));
        //    string[] filePaths = Directory.GetFiles(Server.MapPath("../Content/GalleryPics"));
            

        //    Random random = new Random();
        //    int randomNumber = random.Next(1, 8);

        //    Image1.ImageUrl = "~/Content/GalleryPics/" + Path.GetFileName(filePaths[randomNumber]) + ".jpg";
        //}

        //private void GetCustomersPageWise(int pageIndex)
        //{
        //    string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("GetBlogPostsPageWise", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        //            cmd.Parameters.AddWithValue("@PageSize", int.Parse(ddlPageSize.SelectedValue));
        //            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        //            cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        //            con.Open();
        //            IDataReader idr = cmd.ExecuteReader();
        //            ListView1.DataSource = idr;
        //            ListView1.DataBind();
        //            idr.Close();
        //            con.Close();
        //            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
        //            this.PopulatePager(recordCount, pageIndex);
        //        }
        //    }
        //}

        //private void PopulatePager(int recordCount, int currentPage)
        //{
        //    double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
        //    int pageCount = (int)Math.Ceiling(dblPageCount);
        //    List<ListItem> pages = new List<ListItem>();
        //    if (pageCount > 0)
        //    {
        //        pages.Add(new ListItem("First", "1", currentPage > 1));
        //        for (int i = 1; i <= pageCount; i++)
        //        {
        //            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        //        }
        //        pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        //    }
        //    rptPager.DataSource = pages;
        //    rptPager.DataBind();
        //}

        //protected void PageSize_Changed(object sender, EventArgs e)
        //{
        //    this.GetCustomersPageWise(1);
        //}

        //protected void Page_Changed(object sender, EventArgs e)
        //{
        //    int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        //    this.GetCustomersPageWise(pageIndex);
        //}

    }
}