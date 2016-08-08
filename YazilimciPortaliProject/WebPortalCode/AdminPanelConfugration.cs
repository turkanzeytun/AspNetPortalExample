using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebPortalCode
{
    public static class AdminPanelConfugration
    {
        static AdminPanelConfugration()
        {
            _Provider = ConfigurationManager.AppSettings["Provider"];
            _ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            _VideoPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["VideoPerPage"]);
            _VideoCommentLenght = Convert.ToInt32(ConfigurationManager.AppSettings["VideoCommentLenght"]);
            _SiteName = ConfigurationManager.AppSettings["_SiteName"];
        }
      
        private static string _Provider;
        public static string Provider
        {
            get { return AdminPanelConfugration._Provider; }
        }


        private static string _ConnectionString;
        public static string ConnectionString
        {
            get { return AdminPanelConfugration._ConnectionString; }
        }


        private readonly static int _VideoPerPage;
        public static int VideoPerPage
        {
            get { return AdminPanelConfugration._VideoPerPage; }
        }


        private readonly static int _VideoCommentLenght;
        public static int VideoCommentLenght
        {
            get { return AdminPanelConfugration._VideoCommentLenght; }
        }


        private readonly static string _SiteName;
        public static string SiteName
        {
            get { return AdminPanelConfugration._SiteName; }
        } 



      
        public static string MailServer
        {
            get { return ConfigurationManager.AppSettings["MailServer"]; }
        }

        public static string MailPassword
        {
            get { return ConfigurationManager.AppSettings["MailPassword"]; }
        }

        public static string MailUser
        {
            get { return ConfigurationManager.AppSettings["MailUser"]; }
        }
   
        public static int MailServerPort
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"]); }
        }

        public static string ErrorMail
        {
            get { return ConfigurationManager.AppSettings["ErrorMail"]; }
        }

    }
}