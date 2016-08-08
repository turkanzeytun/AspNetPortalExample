using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortalCode;

namespace YazilimciPortaliProject.Sayfalar
{
    public partial class Iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (email.Text!=null && comment.Text!=null)
            {
                Utilities.SendMail(AdminPanelConfugration.MailUser, AdminPanelConfugration.MailUser, HttpUtility.HtmlEncode(email.Text), HttpUtility.HtmlEncode((comment.Text)));
            }
            else
            {
                
            }
            
        }
    }
}