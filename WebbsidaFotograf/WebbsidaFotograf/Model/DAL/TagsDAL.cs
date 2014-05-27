using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebbsidaFotograf.Model.DAL
{
    public class TagsDAL
    {
        private Tags _tags;
        private Tags Tags
        {
            get { return _tags ?? (_tags = new Tags()); }
        }

        private static BlogTags _blogTags;
        private static BlogTags BlogTags
        {
            get { return _blogTags ?? (_blogTags = new BlogTags()); }
        }

        private static string _connectionString;

        static TagsDAL() 
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private static Blog _blog;
        private static Blog Blog
        {
            get { return _blog ?? (_blog = new Blog()); }
        }

        public static void DeleteAllTagsByID(int? PostId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.DeleteAllTagsByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BlogPostId", SqlDbType.Int, 4).Value = PostId;




                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i dataåtkomstlagret");
                }
            }
        }


        public string GetTagsByImageName(string image)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //var tags = new List<Tags>(100);
                    //ImageProps imageProps = new ImageProps();
                    //imageProps.ImageName = image;
                    SqlCommand cmd = new SqlCommand("appSchema.GetTagsByImageName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageName", image);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //var imageName = reader.GetOrdinal("ImageName");
                            var tagName = reader.GetOrdinal("TagName");

                            string hej = reader.GetString(tagName);
                            Tags.TagName = hej;

                            return hej;
                            //return hej;


                            //};
                        }
                        return null;

                    }
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i dataåtkomstlagret");
                }
            }
            //return null;
        }

        public void CreateBlogTags(string tags, int? id)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.CreateBlogTags", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Blog blog = new Blog();
                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.

                    cmd.Parameters.Add("@Tag", SqlDbType.VarChar, 50).Value = tags;
                    cmd.Parameters.Add("@BlogPostID", SqlDbType.Int).Value = id;


                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        //public string GetTagsByBlogPostID(int? postID)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            //var tags = new List<>(100);
        //            //ImageProps imageProps = new ImageProps();
        //            //imageProps.ImageName = image;
        //            SqlCommand cmd = new SqlCommand("appSchema.GetTagsByBlogPostID", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@BlogPostID", postID);

        //            conn.Open();
        //            //string[] hej;
        //            //hej = new string[10];
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    //var imageName = reader.GetOrdinal("ImageName");
        //                    var tagName = reader.GetOrdinal("Tag");

        //                        string hej = reader.GetString(tagName);
                            
        //                    //BlogTags.Tag = hej;
        //                    //tags.Add(hej); 
        //                    return hej;

        //                }
        //                return null;

        //            }
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Ett fel inträffade i dataåtkomstlagret");
        //        }
        //    }
        //    //return null;
        //}


        //GetTagsByBlogPostID


        public List<BlogTags> GetTagsByBlogPostID(int? postID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //var tags = new List<>(100);
                    //ImageProps imageProps = new ImageProps();
                    //imageProps.ImageName = image;
                    SqlCommand cmd = new SqlCommand("appSchema.GetTagsByBlogPostID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BlogPostID", postID);

                    List<BlogTags> tags = new List<BlogTags>(10);

                    conn.Open();
                    //string[] hej;
                    //hej = new string[10];
                    using (var reader = cmd.ExecuteReader())
                    {

                        var tagName = reader.GetOrdinal("Tag");

                        while (reader.Read())
                        {
                            tags.Add(new BlogTags 
                            {
                                Tag = reader.GetString(tagName)
                            });

                        }
                       

                    }

                    tags.TrimExcess();
                    return tags;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i dataåtkomstlagret");
                }
            }
            //return null;
        }
    }
}