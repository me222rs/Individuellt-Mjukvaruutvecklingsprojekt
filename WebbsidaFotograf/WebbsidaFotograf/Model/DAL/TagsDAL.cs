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


        private static string _connectionString;

        static TagsDAL() 
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
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
                            //ImageProps imageProps = new ImageProps();
                            //return new ImageProps
                            //{
                            //ImageName = reader.GetString(imageName),
                            string hej = reader.GetString(tagName);
                            Tags.TagName = hej;

                            return hej;
                            //return hej;


                            //};
                        }
                        return null;
                        //___________________________________________________________________________
                        //ImageProps imageProps = new ImageProps();

                        //cmd.Parameters.Add("@ImageName", SqlDbType.VarChar, 50).Value = image;

                        //cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                        //conn.Open();
                        //cmd.ExecuteNonQuery();
                        //imageProps.Description = (string)cmd.Parameters["@Description"].Value;
                    }
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