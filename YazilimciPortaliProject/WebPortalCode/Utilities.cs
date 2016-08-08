using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Xml.Linq;

namespace WebPortalCode
{
    public static class Utilities
    {
        public static void SendMail(string from, string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, "Yazilim Portal İyi Günler Diler");
            mail.To.Add(to);// aynı anda hata mesajı başka bir proje yöneticisine gitsin
            //mail.To.Add("t.zeytun@hotmail.com");
            mail.Subject = subject;
            mail.Body = body;
            //mail.IsBodyHtml = true;// bir hata mail sayfası tasarlanacak

            SmtpClient client = new SmtpClient(AdminPanelConfugration.MailServer, AdminPanelConfugration.MailServerPort);
            client.Credentials = new NetworkCredential(AdminPanelConfugration.MailUser, AdminPanelConfugration.MailPassword);
            client.EnableSsl = true;
            client.Send(mail);


            //SmtpClient smpt = new SmtpClient();
            //smpt.Credentials = new NetworkCredential(AdminPanelConfugration.MailUser, AdminPanelConfugration.MailPassword);
            //smpt.Port = AdminPanelConfugration.MailServerPort;//Siz kendi mail hesabınızın port numarasını vereceksiniz
            //smpt.Host = AdminPanelConfugration.MailServer;//Siz kendi mail hesabınızın adını vereceksiniz
            //smpt.Send(mail);
        }

        public static void LogError(Exception ex)
        {
            //XDocument xdoc1 = XDocument.Load("/Web.config"); var path1 = xdoc1.Element("configuration").Element("appSettings").Element("add").Attribute("MailUser").Value;
            //XDocument xdoc2 = XDocument.Load("~/Web.config"); var path2 = xdoc2.Element("configuration").Element("appSettings").Element("add").Attribute("MailUser").Value;
            //XDocument xdoc3 = XDocument.Load("Web.config"); var path3 = xdoc3.Element("configuration").Element("appSettings").Element("add").Attribute("MailUser").Value; 
            
            
            string hataMesaji ="Tarih: " + DateTime.Now.ToLongDateString() + " Saat: " + DateTime.Now.ToLongTimeString();
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            hataMesaji +="\n\n Sayfa: " + context.Request.RawUrl;
            hataMesaji += "\n\n Hata Mesajı: " + ex.Message;
            hataMesaji += "\n\n Kaynak: " + ex.Source;
            string from = AdminPanelConfugration.MailUser;
            string to = AdminPanelConfugration.ErrorMail;
            string subject = "Yazılımcı Hocası Admin Hata Mesajı";
            SendMail(from, to, subject, hataMesaji);
        }
    }
}