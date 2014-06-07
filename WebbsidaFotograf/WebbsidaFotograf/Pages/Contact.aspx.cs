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

        public bool HasMessage
        {
            get
            {
                return Session["SuccessMessage"] != null;
            }
        }

        //Rättmeddelanden
        private string SuccessMessage
        {
            get
            {

                var message = Session["SuccessMessage"] as string;
                Session.Remove("SuccessMessage");
                return message;
            }
            set
            {
                Session["SuccessMessage"] = value;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (HasMessage)
            {
                Success.Visible = true;
                Success.Text = SuccessMessage;
            }
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            //**********************************************************************************
            //Hittade koden här
            //http://www.aspsnippets.com/Articles/How-to-create-Contact-Us-Page-in-ASPNet.aspx
            //**********************************************************************************

            //Här får du fylla i din egen epost adress för att testa.
            //Detta fungerar inte på skolans server kupan eftersom google antagligen inte kan komma åt vpn200
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
            //användarnamn och lösen till adressen det ska skickas ifrån.
            NetworkCred.UserName = "mikael.edberg92@gmail.com";
            NetworkCred.Password = "supermicke112"; //Committade nästan mitt lösenord :P
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            SuccessMessage = String.Format("Meddelandet skickades");
            Response.Redirect("Contact.aspx");
            //Success.Text = "Email Sent SucessFully.";
        }
    }
}