using System;
using System.Web.Routing;
using System.Web.UI;
using WebPortalCode;

namespace YazilimciPortaliProject.YonetimPaneli
{
    public partial class AdminIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            bool a = Convert.ToBoolean(Session["admnGiris"]);
            if (Convert.ToBoolean(Session["admnGiris"]) == true)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Utilities.LogError(ex);
                }
            }
            else
            {
                Response.Redirect("/Bulunamadi.aspx");
            }
            //}
            
        }

        protected void imgBtnVideoYukle_Click(object sender, ImageClickEventArgs e)
        {
            Response.RedirectToRoute("VideoYukle", new { ID = "0", NAME="Video", PAGE = "0" });
        }

        protected void imgBtnPrgYukle_Click(object sender, ImageClickEventArgs e)
        {
            Response.RedirectToRoute("DemoProgramYukle", new { ID = "0", NAME = "Program", PAGE = "0" });
        }

    
    }
}