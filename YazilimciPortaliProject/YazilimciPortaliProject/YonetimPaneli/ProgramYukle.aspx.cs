using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortalCode;

namespace YazilimciPortaliProject.YonetimPaneli
{
    public partial class ProgramYukle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool a = Convert.ToBoolean(Session["admnGiris"]);
            if (Convert.ToBoolean(Session["admnGiris"]) == true)
            {
                VideoCategories.DataSource = VideoCategoriesAccess.GetVideoCategories();
                VideoCategories.DataBind();
            }
            else
            {
                Response.Redirect("/Bulunamadi.aspx");
            }
        }

     
        public struct PageUrl
        {
            public PageUrl(string id, string page)
            {
                this.page = page;
                this.id = id;
            }

            private string id;
            public string Id
            {
                get { return id; }
            }

            private string page;
            public string Page
            {
                get { return page; }
            }
        }

        protected void btnProgramYukle_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                string yol = Request.PhysicalApplicationPath + "/App_Themes/Yuklemeler/DemoPragramlar/";
                FileUpload1.SaveAs(yol + FileUpload1.FileName);
                //database içine program bilgilerinin kayıt işlemleri yapılacak
                txtPrgName.Text = string.Empty;
                txtPrgComment.Text = string.Empty;
            } 
        }
    }
}