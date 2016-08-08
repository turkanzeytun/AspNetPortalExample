using System;
using WebPortalCode;
using System.Web.Routing;
using WebPortalCode.Entities;
using System.Data;

namespace YazilimciPortaliProject.YonetimPaneli
{
    public partial class VideoYukle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool a = Convert.ToBoolean(Session["admnGiris"]);
            if (Convert.ToBoolean(Session["admnGiris"]) == true)
            {
                //try
                //{
                    VideoCategories.DataSource = VideoCategoriesAccess.GetVideoCategories();
                    VideoCategories.DataBind();

                    if (!IsPostBack)
                    {
                        Degerleriyukle();
                    }
                //}
                //catch (Exception ex)
                //{
                //    Utilities.LogError(ex);
                //}
                //finally
                //{

                //}
            }
            else
            {
                Response.Redirect("/Bulunamadi.aspx");
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
                string firstPageUrl = "1";

                DataTable dt = VideoCategoriesAccess.GetVideosOnFront(Convert.ToInt32(CategoryId), Convert.ToInt32(Page), out howManyPages);
                              
                dt.Columns[1].ColumnName = "Video Adı";
                dt.Columns[2].ColumnName = "Açıklama";
                dt.Columns[3].ColumnName = "Resim Yolu";
                dt.Columns[4].ColumnName = "Görünsün Mü";
                grdVideos.DataSource = dt;
                grdVideos.DataBind();
                grdVideos.Columns[0].Visible = false;
                
                Show(howManyPages, Convert.ToInt32(Page),firstPageUrl,true);
            }
        }

        public void Show(int howManyPages, int currentpage, string firstPageUrl, bool showPages)
        {
            if (currentpage==1)
            {
                PreviousLink.Enabled = false;
            }
            //else
            //{
            //    //PreviousLink.NavigateUrl = (currentpage == 2) ? firstPageUrl : "'<%# GetRouteUrl(\"VideoDetails\", new {ID = " + RouteData.Values["ID"].ToString() + "\", NAME=\"" + "sdada" + "\",PAGE = \"" + "1" + "\" }) %>'";
            //}

            if (currentpage==howManyPages)
            {
                NextLink.Enabled = false;
            }
            //else
            //{
            //    //NextLink.NavigateUrl = "'<%# GetRouteUrl(\"VideoDetails\", new {ID = " + RouteData.Values["ID"].ToString() + "\", NAME=\"" + "sdada" + "\",PAGE = \"" + (currentpage - 1).ToString() + "\" }) %>'";
            //}


            if (showPages)
            {
                PageUrl[] pages = new PageUrl[howManyPages];

                for (int i = 0; i < howManyPages; i++)
                {
                    pages[i] = new PageUrl(RouteData.Values["ID"].ToString(), (i + 1).ToString());                    
                }

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



        protected void btnVideoYukle_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                string yol = Request.PhysicalApplicationPath + "App_Themes\\Yuklemeler\\Videolar\\";

                FileUpload1.SaveAs(yol + FileUpload1.FileName);

                Video video = new Video();
                video.Name = txtVideoName.Text;
                video.Thumb = Request.PhysicalApplicationPath + "App_Themes\\Yuklemeler\\Videolar\\" + FileUpload1.FileName;
                video.Comment = txtVideoComment.Text;
                video.CatId = 1;//rout ile gelen id alınacakk
                VideoCategoriesAccess.AddVideo(video);

                txtVideoName.Text = string.Empty;
                txtVideoComment.Text = string.Empty;
            } 
        }

       

    }  
}