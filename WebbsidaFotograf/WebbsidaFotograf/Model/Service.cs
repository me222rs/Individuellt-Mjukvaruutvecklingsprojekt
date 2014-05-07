using System;
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
        #region Properties
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
        #endregion
        #region Fields
        private static BlogDAL _blogDAL;
        private static TagsDAL _tagsDAL;
        private static ImageDAL _imageDAL;
        private static AdminLogin _adminLogin;
        #endregion

        /// <summary>
        /// Denna metoden slänger in bildens namn, beskrivning och taggar i databasen
        /// </summary>
        /// <param name="image"></param>
        public void SaveImage(ImageProps image) 
        {
            ImageDAL.SaveImage(image);
        }

        /// <summary>
        /// Denna metod skickar vidare en bild till DAL klassen som ska ta bort den ur databasen
        /// </summary>
        /// <param name="image"></param>
        public void DeleteImage(ImageProps image)
        {
            ImageDAL.DeleteImage(image);
        }

        /// <summary>
        /// Denna metod skickar vidare en post till DAL klassen som ska ta bort den ur databasen
        /// </summary>
        /// <param name="postID"></param>
        public void DeleteBlogPost(int? postID) 
        {
            BlogDAL.DeleteBlogPost(postID);
        }

        /// <summary>
        /// Denna metod skickar vidare ett användarnamn och lösenord till DAL klassen som ska logga in användaren
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UserLogin(string userName, string password)
        {
            return AdminLogin.UserLogin(userName, password);
        }

        /// <summary>
        /// Denna metod skickar vidare en bild till DAL klassen som ska hämta en beskrivning till den valda bilden
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string GetDescriptionByImageName(string image) 
        {
            return ImageDAL.GetDescriptionByImageName(image);
        }

        /// <summary>
        /// Denna metod hämtar bildernas namn från databasen
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ImageProps> GetImages()
        {
            return ImageDAL.GetImages();
        }


        /// <summary>
        /// Hämtar den valda bildens taggar
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string GetTagsByImageName(string image)
        {
            return ImageDAL.GetTagsByImageName(image);
        }


        /// <summary>
        /// Skickar vidare namn och ny beskrivning för att uppdatera den valda bildens beskrivning
        /// </summary>
        /// <param name="image"></param>
        /// <param name="description"></param>
        public void UpdateDescription(string image, string description)
        {
            ImageDAL.UpdateDescription(image, description);
        }


        /// <summary>
        /// Skickar vidare den inmatade titeln och texten till databasen
        /// </summary>
        /// <param name="title"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public string CreateBlogPost(string title, string post) 
        {
            return BlogDAL.CreateBlogPost(title, post);
        }


        /// <summary>
        /// Hämtar alla bloggposter
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog> GetBlogPosts() 
        {
            return BlogDAL.GetBlogPosts();
        }


        /// <summary>
        /// Skickar vidare ett id för att hämta ut en enskild post ur databasen
        /// </summary>
        /// <param name="postID"></param>
        /// <returns></returns>
        public Blog GetBlogPostByID(int? postID) 
        {
            return BlogDAL.GetBlogPostById(postID);
        }


        /// <summary>
        /// Uppdaterar en bloggpost
        /// </summary>
        /// <param name="item"></param>
        public void SaveChanges(Blog item) 
        {
            BlogDAL.UpdateBlogPost(item);
        }
    }
}