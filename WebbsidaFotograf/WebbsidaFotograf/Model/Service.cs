using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using WebbsidaFotograf.Model.DAL;
using System.ComponentModel.DataAnnotations;
using WebbsidaFotograf.app_infrastructure;

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

        private static Blog _blog;
        private static Blog Blog
        {
            get { return _blog ?? (_blog = new Blog()); }
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
            //ICollection<ValidationResult> validationResults;
            //if (!image.Validate(out validationResults)) // Använder "extension method" för valideringen!
            //{                                              // Klassen finns under App_Infrastructure.
            //    // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
            //    // till samlingen med resultat av valideringen.
            //    var ex = new ValidationException("Objektet klarade inte valideringen.");
            //    ex.Data.Add("ValidationResults", validationResults);
            //    throw ex;
            //}
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
        public string CreateBlogPost(string title, string post, string tags) 
        {
            Blog blog = new Blog();
            blog.Title = title;
            blog.Post = post;
            ICollection<ValidationResult> validationResults;
            if (!blog.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }


            BlogDAL.CreateBlogPost(title, post);
            int id = Convert.ToInt32(HttpContext.Current.Session["BlogPostID"]);
            //int blogPostID = Blog.BlogPostID;

            string[] links = tags.Split(',');

            foreach (string word in links)
            {
                TagsDAL.CreateBlogTags(word, id);
            }
            HttpContext.Current.Session.Remove("BlogPostID");
           
            return null;
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

        public void DeleteAllTagsByID(int? postID)
        {
            TagsDAL.DeleteAllTagsByID(postID);
        }

        /// <summary>
        /// Uppdaterar en bloggpost
        /// </summary>
        /// <param name="item"></param>
        public void SaveChanges(Blog item, string tags, int? id) 
        {
            ICollection<ValidationResult> validationResults;
            if (!item.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            BlogDAL.UpdateBlogPost(item);

            string[] links = tags.Split(',');

            foreach (string word in links)
            {
                TagsDAL.CreateBlogTags(word, id);
            }

            //TagsDAL.CreateBlogTags(tags);
        }

        public string GetSalt(string userName) 
        {
            return AdminLogin.GetSalt(userName);
        }

        public Blog GetBlogPostByID2(int? postID)
        {
            return BlogDAL.GetBlogPostById2(postID);
        }

        //public string GetTagsByBlogPostID(int? postID)
        //{
        //    return TagsDAL.GetTagsByBlogPostID(postID);
        //}

        public List<BlogTags> GetTagsByBlogPostID(int? postID)
        {
            return TagsDAL.GetTagsByBlogPostID(postID);
        }
    }
}