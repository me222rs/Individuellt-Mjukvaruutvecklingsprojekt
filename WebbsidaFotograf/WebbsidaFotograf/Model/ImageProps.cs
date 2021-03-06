﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using WebbsidaFotograf.Model.DAL;
using System.ComponentModel.DataAnnotations;

namespace WebbsidaFotograf.Model
{
    public class ImageProps
    {
        public int ImageID { get; set; }

        public string ImageName { get; set; }

        [Required(ErrorMessage = "En beskrivning måste anges.")]
        [StringLength(200, ErrorMessage = "Beskrivningen kan bestå av som mest 200 tecken.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "En beskrivning måste anges.")]
        public string Tags { get; set; }

        private Service Service 
        { 
            get 
            { 
                return _service ?? (_service = new Service()); 
            } 
        }
        private ImageDAL ImageDAL
        {
            get
            {
                return _imageDAL ?? (_imageDAL = new ImageDAL());
            }
        }

        #region PFields
        private static Service _service;
        private static ImageProps _imageProps;
        private static ImageDAL _imageDAL;
        private static Regex ApprovedExtentions;
        private static string PhysicalUploadedImagesPath;
        private static string PhysicalUploadedImagesThumbNailPath;
        #endregion

        #region Get Image Names
        public static IEnumerable<string> GetImageNames(string category)
        {
            PhysicalUploadedImagesThumbNailPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\" + category + "Thumbs");
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
        static ImageProps()
        {
            var invalidChars = new string(Path.GetInvalidFileNameChars());

            //PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\");
            //PhysicalUploadedImagesThumbNailPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\GalleryThumbs");
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
        public static string SaveImage(Stream stream, string fileName, string description, string tags, string category)
        {
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\" + category);
            PhysicalUploadedImagesThumbNailPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\" + category + "Thumbs");
            //fileName = Path.GetRandomFileName();
            var image = System.Drawing.Image.FromStream(stream);
            //var name = Path.GetRandomFileName();
            var fileNameWithoutExtention = Path.GetFileNameWithoutExtension(fileName);
            var fileNameWithExtention = Path.GetExtension(fileName);


            fileNameWithoutExtention = Path.GetRandomFileName();
            fileName = String.Format(fileNameWithoutExtention + fileNameWithExtention);

            if (IsValidImage(image))
            {
                int i = 0;
                if (ImageExists(fileName))
                {
                    //Hämtar ut exempelvis .jpg, .png osv.
                    var extention = Path.GetExtension(fileName);
                    //Hämtar ut filnamnet, alltså det som står innan .jpg
                    var imageName = Path.GetFileNameWithoutExtension(fileName);
                    imageName = Path.GetRandomFileName();

                    do
                    {
                        //Slår samman de olika delarna i filen
                        fileName = String.Format("{0}({1}){2}", imageName, ++i, extention);
                    } while (ImageExists(fileName));
                }
                ImageProps imageProps = new ImageProps();
                imageProps.ImageName = fileName;
                imageProps.Description = description;
                imageProps.Tags = tags;
                Service service = new Service();

                var imgPhoto = ScaleImage(image, 400);

                service.SaveImage(imageProps);
                
                //PhysicalUploadedImagesThumbNailPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\" + category);
                imgPhoto.Save(Path.Combine(PhysicalUploadedImagesPath, fileName));
                


                var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);
                thumbnail.Save(Path.Combine(PhysicalUploadedImagesThumbNailPath, fileName));
                //ImageDAL.InsertImageInfo();

            }


            return fileName;
        }

        //********************************************************************************************************
        //Använt mig av koden på denna sidan
        //http://stackoverflow.com/questions/10329010/c-sharp-how-to-resize-image-proportionately-with-max-height
        //********************************************************************************************************
        public static Image ScaleImage(Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        #endregion
    }
}