using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebbsidaFotograf.Model.DAL
{
    public class ImageDAL
    {
        private static string _connectionString;

        static ImageDAL() 
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static void InsertImageInfo() 
        {
            using (SqlConnection conn = CreateConnection()) 
            {
                try
                {
                    ImageProps name = new ImageProps();
                    SqlCommand cmd = new SqlCommand("appSchema.AddImageInfo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ImageName", SqlDbType.VarChar, 50).Value = name.ImageName;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Value = name.Description;


                    cmd.Parameters.Add("@ImageID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    name.ImageID = (int)cmd.Parameters["@ImageID"].Value;

                }

                catch 
                {
                    throw new ApplicationException("Ett fel inträffade i datalagret");
                }
            }
        }

        public void SaveImage(ImageProps image) 
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.AddImageInfo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ImageName", SqlDbType.VarChar, 50).Value = image.ImageName;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Value = image.Description;

                    //cmd.Parameters.Add("@ImageID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //image.ImageID = (int)cmd.Parameters["@ImageID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i dataåtkomstlagret");
                }
            }
        }

        public void DeleteImage(ImageProps image)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.DeleteImageByFileName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ImageName", SqlDbType.VarChar, 50).Value = image.ImageName;
                    

                    

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i dataåtkomstlagret");
                }
            }
        }

        public string GetDescriptionByImageName(string image) 
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.GetDescriptionByImageName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    ImageProps imageProps = new ImageProps();
                    
                    cmd.Parameters.Add("@ImageName", SqlDbType.VarChar, 50).Value = image;

                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    imageProps.Description = (string)cmd.Parameters["@Description"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i dataåtkomstlagret");
                }
            }
            return null;
        }
    }
}