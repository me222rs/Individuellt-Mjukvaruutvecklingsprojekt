using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebbsidaFotograf.Model;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace WebbsidaFotograf.Pages.AdminPages
{
    public partial class AdminLogIn : System.Web.UI.Page
    {
        
        private Service _service;
        private Service Service
        {
            get
            {
                return _service ?? (_service = new Service());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }  


        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            
            string userName = Login1.UserName;
            string password = Login1.Password;
            int size = 8;
            //var salt = CreateSalt(size);
            var salt = Service.GetSalt(userName);

            var stringDataToHash = String.Format(password + salt);

            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(stringDataToHash);

            byte[] byteHash = hashAlg.ComputeHash(byteValue);

            string base64 = Convert.ToBase64String(byteHash);

            //Kolla länken sedan
            //http://stackoverflow.com/questions/4329909/hashing-passwords-with-md5-or-sha-256-c-sharp


            bool result = Service.UserLogin(userName, base64);
            if ((result))
            {
                e.Authenticated = true;
                //Service.IsAdmin = true;
                Session["IsAdmin"] = true;
                Response.Redirect("../Home.aspx");
            }
            else
            {
                e.Authenticated = false;
            }

        }

        private static string Encrypt(string password) 
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 20))
            {
                
            }
            

            return password;
        }



    }
}