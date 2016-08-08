using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortalCode;

namespace YazilimciPortaliProject
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btbGiris_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                DataTable dt = new DataTable();

                if (txtxKullanici.Text != null && txtParola.Text != null)
                {
                    try
                    {
                        string rqName = HttpUtility.HtmlEncode(txtxKullanici.Text);
                        string rqPss = HttpUtility.HtmlEncode(txtParola.Text);
                        dt = AdminAccess.GetAdmin(rqName, rqPss);
                    }
                    catch (Exception ex)
                    {
                        Utilities.LogError(ex);
                    }
                    finally
                    {
                    }

                    if (dt.Rows.Count == 1) //Eğer Kullanıcı adı ve şifresi veritabanında kayıtlı ise aşağıdaki işlermleri gerçekleştirir.
                    {
                        try
                        {
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            1, //Ticket versiyonu (şu andadaki güncel versiyon 1'dir)
                            HttpUtility.HtmlEncode(txtxKullanici.Text), //ticket ile ilgili olan txtusername
                            DateTime.Now, //şu anki zamanı alıyor.
                            DateTime.Now.AddMinutes(30), //yaratılan cookie'nin zamanını 30 dakika olarak ayarlıyor.
                            false, //yaratılan cookie'nin IsPErsistent özelliğini false yapıyor.
                            dt.Rows[0][2].ToString(),// kullanıcının rollerle ilgili bilgisini alıyor.
                            FormsAuthentication.FormsCookiePath); // yaratılan cookie'nin yolunu belirtiyor.

                            // FormsAuthenticationTicket ile yaratılan cookie'yi şifreliyoruz.
                            string encTicket = FormsAuthentication.Encrypt(ticket);
                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                            // Eğer FormsAuthenticationTicket ile yaratılan cookie'nin expiration süresi
                            //sınırsız ise, bu cookie'ye ticket nesnesinin Expiration süresi atanıyor.
                            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                            Response.Cookies.Add(cookie);

                            //Response.StatusCode = 301;
                            //Response.StatusDescription = "Moved Permanently";
                            //Response.AddHeader("Location", "AdminIndex.aspx");
                            Session["admnGiris"] = true;
                            Response.RedirectToRoute("AdminIndex", new { });
                        }
                        catch (Exception ex)
                        {
                            //Utilities.LogError(ex);                            
                        }
                    }
                    else // Eğer kullanıcı adı ve şifresi veritabanındakilerle uyuşmuyorsa aşağıdaki uyarı hatasını verir.
                        Response.Redirect("/UyeGirisHata.aspx");
                }
            }
        }




    }
}