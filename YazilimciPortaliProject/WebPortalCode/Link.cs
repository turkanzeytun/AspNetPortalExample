using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPortalCode
{
    public static class Link
    {

        public static string BuildAbsolute(string relativeUri)
        {
            Uri uri = HttpContext.Current.Request.Url;
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/")) app += "/";

            relativeUri = relativeUri.TrimStart('/');
            return HttpUtility.UrlPathEncode(String.Format("http://{0}:{1}{2}{3}",uri.Host,uri.Port,app,relativeUri));
        }

        public static string ToDepartment(string departmentID, string page)
        {
            if (page == "1")
                return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}",departmentID));
            else
                return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}&Page={1}", departmentID,page));
        }

        public static string ToDepartment(string departmentID)
        {
            return ToDepartment(departmentID, "1");
        }
        /// <summary>
        /// ToDepartment link oluştururken daha esnek bi method gerekti. sayfa ismini kaç sayfa olduğunu ve 
        /// id sine göre veri çekilecekse linki burdan oluşturacağım
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="page"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public static string ToDepartment(string departmentID, string page, string pageName)
        {
            if (page == "1")
                return BuildAbsolute(String.Format("\"" + pageName + ".aspx?ID={0}", departmentID));
            else
                return BuildAbsolute(String.Format("\"" + pageName + ".aspx?ID={0}&Page={1}", departmentID, page));
        }
    }
}