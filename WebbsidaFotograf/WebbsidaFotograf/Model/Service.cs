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

        private AdminLogin AdminLogin
            {
                get
                {
                    return _adminLogin ?? (_adminLogin = new AdminLogin());
                }
            }

        #region PFields
        private static AdminLogin _adminLogin;
        private static Regex ApprovedExtentions;
        private static string PhysicalUploadedImagesPath;
        private static string PhysicalUploadedImagesThumbNailPath;
        #endregion

        #region Get Image Names
        public static IEnumerable<string> GetImageNames()
        {
            var fileInfos = new DirectoryInfo(PhysicalUploadedImagesThumbNailPath).GetFiles();
            List<string> imageNames = new List<string>();
            foreach (var fileInfo in fileInfos)
            {
                if (ApprovedExtentions.IsMatch(fileInfo.Extension))
                {
                    imageNames.Add(fileInfo.Name);
                }
            }
            imageNames.TrimExcess();
            imageNames.Sort();
            return imageNames;
        }
        #endregion

        #region Constructor
        static Service()
        {
            var invalidChars = new string(Path.GetInvalidFileNameChars());

            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\GalleryPics");
            PhysicalUploadedImagesThumbNailPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\GalleryThumbs");
            ApprovedExtentions = new Regex(@"^.*\.(gif|jpg|png)$");

        }
        #endregion


        private static bool IsValidImage(Image image)
        {
            return image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid;
        }


        public static bool ImageExists(string name)
        {
            return File.Exists(Path.Combine(PhysicalUploadedImagesPath, name));
        }

        #region Save Image
        public static string SaveImage(Stream stream, string fileName)
        {
            var image = System.Drawing.Image.FromStream(stream);

            if (IsValidImage(image))
            {
                int i = 0;
                if (ImageExists(fileName))
                {
                    //Hämtar ut exempelvis .jpg, .png osv.
                    var extention = Path.GetExtension(fileName);
                    //Hämtar ut filnamnet, alltså det som står innan .jpg
                    var imageName = Path.GetFileNameWithoutExtension(fileName);

                    do
                    {
                        //Slår samman de olika delarna i filen
                        fileName = String.Format("{0}({1}){2}", imageName, ++i, extention);
                    } while (ImageExists(fileName));
                }

                image.Save(Path.Combine(PhysicalUploadedImagesPath, fileName));
                var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);
                thumbnail.Save(Path.Combine(PhysicalUploadedImagesThumbNailPath, fileName));
            }


            return fileName;
        }
        #endregion

        public bool UserLogin(string userName, string password)
        {
            return AdminLogin.UserLogin(userName, password);
        }
    }
}