﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using WebbsidaFotograf.Model.DAL;

namespace WebbsidaFotograf.Model
{
    public class Service
    {
        public bool IsAdmin { get; set; }
        private AdminLogin AdminLogin
            {
                get
                {
                    return _adminLogin ?? (_adminLogin = new AdminLogin());
                }
            }

        private BlogDAL BlogDAL
        {
            get
            {
                return _blogDAL ?? (_blogDAL = new BlogDAL());
            }
        }


        private ImageDAL ImageDAL
        {
            get
            {
                return _imageDAL ?? (_imageDAL = new ImageDAL());
            }
        }

        private TagsDAL TagsDAL
        {
            get
            {
                return _tagsDAL ?? (_tagsDAL = new TagsDAL());
            }
        }

        #region PFields
        private static BlogDAL _blogDAL;
        private static TagsDAL _tagsDAL;
        private static ImageDAL _imageDAL;
        private static AdminLogin _adminLogin;
        #endregion

        public void SaveImage(ImageProps image) 
        {
            ImageDAL.SaveImage(image);
        }

        public void DeleteImage(ImageProps image)
        {
            ImageDAL.DeleteImage(image);
        }

        public void DeleteBlogPost(int? postID) 
        {
            BlogDAL.DeleteBlogPost(postID);
        }


        public bool UserLogin(string userName, string password)
        {
            return AdminLogin.UserLogin(userName, password);
        }

        public string GetDescriptionByImageName(string image) 
        {
            return ImageDAL.GetDescriptionByImageName(image);
        }

        public IEnumerable<ImageProps> GetImages()
        {
            return ImageDAL.GetImages();
        }

        public string GetTagsByImageName(string image)
        {
            return ImageDAL.GetTagsByImageName(image);
        }

        public void UpdateDescription(string image, string description)
        {
            ImageDAL.UpdateDescription(image, description);
        }

        public string CreateBlogPost(string title, string post) 
        {
            return BlogDAL.CreateBlogPost(title, post);
        }

        public IEnumerable<Blog> GetBlogPosts() 
        {
            return BlogDAL.GetBlogPosts();
        }

        public Blog GetBlogPostByID(int? postID) 
        {
            return BlogDAL.GetBlogPostById(postID);
        }

        public void SaveChanges(Blog item) 
        {
            BlogDAL.UpdateBlogPost(item);
        }
    }
}