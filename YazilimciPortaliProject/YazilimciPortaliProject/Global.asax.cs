using System;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using WebPortalCode;

namespace YazilimciPortaliProject
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["OnlineKisiSayisi"] = 0;
           
            //RouteTable.Routes.Add("AdminIndex", new Route("Admin_Index", new PageRouteHandler("~/YonetimPaneli/AdminIndex.aspx")));
            RouteTable.Routes.Add("CSharp_ProgShow", new Route("CS_Programs", new PageRouteHandler("~/UyeSayfalar/CSProgramShow.aspx")));

            RouteTable.Routes.MapPageRoute("IndexGoster", "Yazilim_Egitim", "~/index.aspx");
            //RouteTable.Routes.MapPageRoute("AdminLogin", "Admin_Login", "~/login.aspx");

            RouteTable.Routes.MapPageRoute("AdminIndex", "Admin_Index", "~/YonetimPaneli/AdminIndex.aspx");
            RouteTable.Routes.MapPageRoute("VideoYukle", "CS_Egitim_VideosuYukleme/{ID}/{NAME}/{PAGE}", "~/YonetimPaneli/VideoYukle.aspx");
            RouteTable.Routes.MapPageRoute("DemoProgramYukle", "CS_Demo_ProgramYukleme/{ID}/{NAME}/{PAGE}", "~/YonetimPaneli/ProgramYukle.aspx");
          
            RouteTable.Routes.MapPageRoute("ProgramlariGoster", "CS_Programlar/{ID}/{PAGE}", "~/Sayfalar/YayinlananProgramciklar.aspx");
            RouteTable.Routes.MapPageRoute("VideolariGoster", "CS_Egitim_Videolari/{ID}/{PAGE}", "~/Sayfalar/YayinlananVideolar.aspx");
            RouteTable.Routes.MapPageRoute("VideoGoster", "CS_Egitim_Videosu/{ID}", "~/Sayfalar/VideoShow.aspx");
            RouteTable.Routes.MapPageRoute("IletisimSayfasi", "Iletisim/", "~/Sayfalar/Iletisim.aspx");
        }    

        protected void Session_Start(object sender, EventArgs e)
        {
            int sayi = (int)Application.Get("OnlineKisiSayisi");
            sayi++;
            Application.Set("OnlineKisiSayisi", sayi);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {


        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Utilities.LogError(Server.GetLastError());
        }

        protected void Session_End(object sender, EventArgs e)
        {
            int sayi = (int)Application.Get("OnlineKisiSayisi");
            sayi--;
            Application.Set("OnlineKisiSayisi", sayi);
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}