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
        #region Properties
        private ImageProps _image;
        private ImageProps ImageProps
        {
            get { return _image ?? (_image = new ImageProps()); }
        }
        #endregion

        #region Connection
        private static string _connectionString;

        static ImageDAL() 
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        #endregion

        /// <summary>
        /// Lägger till ett bildnamn, beskrivning i databasen
        /// </summary>
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
                    cmd.Parameters.Add("@Tags", SqlDbType.VarChar, 200).Value = image.Tags;

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

        /// <summary>
        /// Tar bort en bild ur databasen
        /// </summary>
        /// <param name="image"></param>
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

        /// <summary>
        /// Hämtar en bilds beskrivning från databasen
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string GetDescriptionByImageName(string image) 
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //ImageProps imageProps = new ImageProps();
                    //imageProps.ImageName = image;
                    SqlCommand cmd = new SqlCommand("appSchema.GetDescriptionByImageName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageName", image);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //var imageName = reader.GetOrdinal("ImageName");
                            var description = reader.GetOrdinal("Description");
                            //ImageProps imageProps = new ImageProps();
                            //return new ImageProps
                            //{
                            //ImageName = reader.GetString(imageName),
                             string hej = reader.GetString(description);
                            ImageProps.Description = hej;
                            
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


        /// <summary>
        /// Hämtar alla bilder och deras info från databasen
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ImageProps> GetImages()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var images = new List<ImageProps>(100);

                    var cmd = new SqlCommand("appSchema.GetImages", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var imageIDIndex = reader.GetOrdinal("ImageID");
                        var imageName = reader.GetOrdinal("ImageName");
                        var description = reader.GetOrdinal("Description");

                        while (reader.Read())
                        {
                            images.Add(new ImageProps
                            {
                                ImageID = reader.GetInt32(imageIDIndex),
                                ImageName = reader.GetString(imageName),
                                Description = reader.GetString(description)
                            });
                        }
                    }
                    images.TrimExcess();
                    return images;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Hämtar en specifik bilds taggar från databasen
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string GetTagsByImageName(string image)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //var tags = new List<Tags>(100);
                    //ImageProps imageProps = new ImageProps();
                    //imageProps.ImageName = image;
                    SqlCommand cmd = new SqlCommand("appSchema.GetTags2", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageName", image);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //var imageName = reader.GetOrdinal("ImageName");
                            var tagName = reader.GetOrdinal("Tags");
                            //ImageProps imageProps = new ImageProps();
                            //return new ImageProps
                            //{
                            //ImageName = reader.GetString(imageName),
                            string hej = reader.GetString(tagName);
                            ImageProps.Tags = hej;

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

        /// <summary>
        /// Uppdaterar en specifik bilds beskrivning
        /// </summary>
        /// <param name="image"></param>
        /// <param name="description"></param>
        public void UpdateDescription(string image, string description)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.UpdateDescription", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ImageName", image);
                    cmd.Parameters.AddWithValue("@Description", description);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{
                    //    if (reader.Read())
                    //    {
                    //        var desc = reader.GetOrdinal("Description");

                    //        string hej = reader.GetString(desc);
                    //        ImageProps.Description = hej;

                    //        return hej;
                    //    }
                    //    return null;
                    //}
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i dataåtkomstlagret");
                }
            }
        }
    }
}