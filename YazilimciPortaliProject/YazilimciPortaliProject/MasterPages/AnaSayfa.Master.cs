using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortalCode;

namespace YazilimciPortaliProject.MasterPages
{
    public partial class AnaSayfa : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {             
            if (!IsPostBack)
            {
                string activeLink = Request.RawUrl;
                if (activeLink.Contains("CS_Programlar"))
                {
                    menu1.Attributes["class"] = "active";
                }
                else if (activeLink.Contains("Yazilim_Egitim") || activeLink.Contains("index"))
                {
                     menu0.Attributes["class"] = "active";
                }
                
                Label1.Text = Application.Get("OnlineKisiSayisi").ToString() + " Kişi Online";
                SonYuklenenVideolariYukle(); 
            }
        }

        public void SonYuklenenVideolariYukle()
        {
            string CategoryId = "1";
            string Page = "1";

            if (Page == null) Page = "1";
            int howManyPages = 1;

            SonVideolarDataList.DataSource = VideoCategoriesAccess.GetVideosOnFront(Convert.ToInt32(CategoryId), Convert.ToInt32(Page), out howManyPages);
            SonVideolarDataList.DataBind();
        }

        protected void login_go_Click(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                DataTable dt = new DataTable();

                if (txtKullanici.Text != null && txtPassword.Text != null)
                {
                    try
                    {
                        string rqName = HttpUtility.HtmlEncode(txtKullanici.Text);
                        string rqPss = HttpUtility.HtmlEncode(txtPassword.Text);
                        dt = AdminAccess.GetUser(rqName, rqPss);
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
                            string role = dt.Rows[0][2].ToString();
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            1, //Ticket versiyonu (şu andadaki güncel versiyon 1'dir)
                            HttpUtility.HtmlEncode(txtKullanici.Text), //ticket ile ilgili olan txtusername
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
                            Session["uyeGiris"] = true;
                            //Response.RedirectToRoute("CSharp_ProgShow", new { });
                        }
                        catch (Exception ex)
                        {
                            Utilities.LogError(ex);
                        }
                    }
                    else // Eğer kullanıcı adı ve şifresi veritabanındakilerle uyuşmuyorsa aşağıdaki uyarı hatasını verir.
                        Response.Redirect("/UyeGirisHata.aspx");
                }
            //}
        }
    }
}