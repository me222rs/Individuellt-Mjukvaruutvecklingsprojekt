using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace WebbsidaFotograf.Pages
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            //**********************************************************************************
            //Hittade koden här
            //http://www.aspsnippets.com/Articles/How-to-create-Contact-Us-Page-in-ASPNet.aspx
            //**********************************************************************************

            //Adress som mailet ska skickas ifrån + adressen det ska skickas till
            MailMessage mm = new MailMessage("mikael.edberg92@gmail.com", "mikael.edberg92@gmail.com");
            mm.Subject = Amne.Text;
            mm.Body = "Name: " + Namn.Text + "<br /><br />Email: " + Epost.Text + "<br />" + Meddelande.Text;
            if (FileUpload1.HasFile)
            {
                string FileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                mm.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileName));
            }
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "mikael.edberg92@gmail.com";
            NetworkCred.Password = ""; //Committade nästan mitt lösenord :P
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            Success.Text = "Email Sent SucessFully.";
        }
    }
}