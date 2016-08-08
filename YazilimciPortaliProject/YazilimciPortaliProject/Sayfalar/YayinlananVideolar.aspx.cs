using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortalCode;

namespace YazilimciPortaliProject.Sayfalar
{
    public partial class YayinlananVideolar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Degerleriyukle();
                }
            }
            catch (Exception ex)
            {
                Utilities.LogError(ex);
            }
            finally
            {

            }
        }

        public void Degerleriyukle()
        {
            if (RouteData.Values["ID"].ToString() != "TÜMVİDEOLAR")
            {
                string CategoryId = RouteData.Values["ID"].ToString();
                string Page = RouteData.Values["PAGE"].ToString();

                if (Page == null) Page = "1";
                int howManyPages = 1;

                VideoList.DataSource = VideoCategoriesAccess.GetVideosOnFront(Convert.ToInt32(CategoryId), Convert.ToInt32(Page), out howManyPages);
                VideoList.DataBind();
                Show(howManyPages, Convert.ToInt32(Page), true);
            }
        }

        public void Show(int howManyPages, int currentpage, bool showPages)
        {
            if (currentpage == 1)
            {
                PreviousLink.Enabled = false;
            }

            if (currentpage == howManyPages)
            {
                NextLink.Enabled = false;
            }

            if (showPages)
            {
                PageUrl[] pages = new PageUrl[howManyPages];

                for (int i = 0; i < howManyPages; i++)
                {
                    pages[i] = new PageUrl(RouteData.Values["ID"].ToString(), (i + 1).ToString());
                }
                //Response.RedirectToRoute("AdminIndex", new { });

                pagesRepeater.DataSource = pages;
                pagesRepeater.DataBind();
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
    }
}