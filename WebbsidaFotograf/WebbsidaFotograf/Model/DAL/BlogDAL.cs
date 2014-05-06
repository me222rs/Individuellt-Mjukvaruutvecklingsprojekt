﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebbsidaFotograf.Model.DAL
{
    public class BlogDAL
    {
        static BlogDAL() 
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private static string _connectionString;


        public static string CreateBlogPost(string title, string post)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    Blog blog = new Blog();
                    SqlCommand cmd = new SqlCommand("appSchema.AddBlogPost", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50).Value = title;
                    cmd.Parameters.Add("@Post", SqlDbType.VarChar, 2000).Value = post;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    

                    return null;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade i datalagret");
                }
            }
        }

        public IEnumerable<Blog> GetBlogPosts()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var posts = new List<Blog>(100);

                    var cmd = new SqlCommand("appSchema.GetBlogPosts", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var blogpostIDIndex = reader.GetOrdinal("BlogPostID");
                        var titleIndex = reader.GetOrdinal("Title");
                        var postIndex = reader.GetOrdinal("Post");
                        var dateIndex = reader.GetOrdinal("Date");


                        while (reader.Read())
                        {
                            posts.Add(new Blog
                            {
                                BlogPostID = reader.GetInt32(blogpostIDIndex),
                                Title = reader.GetString(titleIndex),
                                Post = reader.GetString(postIndex),
                                Date = reader.GetDateTime(dateIndex),

                            });

                        }
                    }
                    posts.TrimExcess();
                    return posts;
                }
                catch
                {
                    //throw new ApplicationException("Fel inträffade när kontakterna skulle hämtas från databasen.");
                    return null;
                }
            }
        }
        public Blog GetBlogPostById(int postID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.GetBlogPostByID", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BlogPostID", postID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var postIDIndex = reader.GetOrdinal("BlogPostID");
                            var titleIndex = reader.GetOrdinal("Title");
                            var postIndex = reader.GetOrdinal("Post");
                            var dateIndex = reader.GetOrdinal("Date");

                            return new Blog
                            {
                                BlogPostID = reader.GetInt32(postIDIndex),
                                Title = reader.GetString(titleIndex),
                                Post = reader.GetString(postIndex),
                                Date = reader.GetDateTime(dateIndex),

                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade i data access layer.");
                }
            }

        }

    }
}