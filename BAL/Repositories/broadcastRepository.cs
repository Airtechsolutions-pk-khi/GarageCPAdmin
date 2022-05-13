
using DAL.DBEntities;

using BAL.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Twilio.Rest.Api.V2010.Account;
using Twilio;
using System.Web;
using System.IO;
using System.Configuration;
using System.Net;
using System.Net.Mail;


namespace BAL.Repositories
{
    public class broadcastRepository : BaseRepository
    {


        public broadcastRepository()
             : base()
        {
            DBContext = new Garage_UATEntities();
        }

        public broadcastRepository(Garage_UATEntities contextDB)
            : base(contextDB)
        {
            DBContext = contextDB;
        }
       

        public int SendEmailCustomer(BroadcastViewModel obj)
        {
            string[] arr = obj.Email;
            foreach (var email in arr)
            {
                string Bcc = email;

                //Viewbag.Contact = "";
                string ToEmail, SubJect, cc;
                cc = "";
                
                SubJect = obj.Subject;
                string BodyEmail = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Template") + "\\" + "contactcustomer.txt");
                DateTime dateTime = DateTime.UtcNow.Date;
                BodyEmail = BodyEmail.Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
                .Replace("#Message#", obj.Message.ToString());
                
                try
                {
                    SendEmailCus(SubJect, BodyEmail, Bcc);
                }

                catch (Exception ex)
                {
                    //ViewBag.Contact = "";
                }
                
            }
            return 1;
        }

        public void SendEmailCus(string Subject, string BodyEmail, string To)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(To);

                mail.From = new MailAddress("airtechgitrepo@gmail.com".ToString());
                mail.Subject = Subject;
                string Body = BodyEmail;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
               
                smtp.Port = int.Parse("587".ToString());
                smtp.Host = "smtp.gmail.com".ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential("airtechgitrepo@gmail.com".ToString(), "Flutter2021".ToString());

                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }

        public int SendEmailToAdmin(BroadcastViewModel obj)
        {
            string[] arr = obj.Email;
            string emails = ($"{string.Join(", ", arr)}");
           
            string ToEmail, SubJect, cc;
            cc = "";
            //Bcc = "";
            ToEmail = "ammadsiddiqui136@gmail.com";
            SubJect = obj.Subject;
            string BodyEmail = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Template") + "\\" + "admin.txt");
            DateTime dateTime = DateTime.UtcNow.Date;
            BodyEmail = BodyEmail.Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
            .Replace("#Message#", obj.Message.ToString())
            .Replace("#Emails#", emails.ToString());
            try
            {
                SendEmailAdmin(SubJect, BodyEmail, ToEmail);
            }

            catch (Exception ex)
            {
                //ViewBag.Contact = "";
            }
            return 1;

        }
        public void SendEmailAdmin(string Subject, string BodyEmail, string To)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(To);
                mail.From = new MailAddress("airtechgitrepo@gmail.com".ToString());
                mail.Subject = Subject;
                string Body = BodyEmail;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                
                smtp.Port = int.Parse("587".ToString());
                smtp.Host = "smtp.gmail.com".ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential("airtechgitrepo@gmail.com".ToString(), "Flutter2021".ToString());

                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
        public string Smsdirect(BroadcastViewModel obj)
        {
            try
            {
                List<string> arr = obj.Email.ToList();
                var list = DBContext.Users.Where(x => arr.Contains(x.Email)).ToList();

                string[] mobileno = obj.Email;
                foreach (var item in list)
                {
                    try
                    {
                        var mobileNo = item.ContactNo.Replace("+", "").Replace(" ", "");
                        var SenderName = "GARAGE-AD";

                        string remoteUrl = string.Format("https://mshastra.com/sendurl.aspx?user=20096101&pwd=dpgikb&senderid={0}&mobileno={1}&msgtext={2}&priority=High&CountryCode=ALL", SenderName, item.ContactNo, obj.Message);
                        HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
                        WebResponse response = httpRequest.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        string result = reader.ReadToEnd();
                    }
                    catch { }
                }

                return "success";
            }
            catch (Exception ex)
            {
                return "failed";
            }
        }
      
        public List<User> getAllUsers()
        {
            List<SmsBilling> lst = new List<SmsBilling>();
            try
            {
                return DBContext.Users.Where(x => x.StatusID == 1).ToList();
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

    }
}
