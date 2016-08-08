using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using WebPortalCode.Entities;


namespace WebPortalCode
{
    public static class VideoCategoriesAccess
    {
        public struct VideoCategoriesDetail
        {
            public string id;
            public string name;
        }

        public struct VideoDetails
        {
            public int id;
            public string name;
            public  string path;
            public string comment;
            public int categoryID;
            public bool pageFront;
        }

        public static DataTable GetVideoCategories()
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetVideoCategories";

            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);
            return dt;
        }

        public static DataTable GetVideos(int id)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetVideos";

            DbParameter param1 = com.CreateParameter();
            param1.ParameterName = "@VID";
            param1.Value = id;
            com.Parameters.Add(param1);

 
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);
            return dt;
        }

        public static VideoCategoriesDetail GetVideoCategoriesDetail(int id)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetVideoCategoriDetail";

            DbParameter param1 = com.CreateParameter();
            param1.ParameterName = "@VCatd";
            param1.DbType = DbType.Int32;
            param1.Value = id;
            com.Parameters.Add(param1);

            VideoCategoriesDetail vcd = new VideoCategoriesDetail();
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);

            if (dt.Rows.Count>0)
            {
                vcd.name = dt.Rows[0]["name"].ToString();
            }
            return vcd;
        }

        public static VideoDetails GetVideoDetail(int id)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetVideoDetail";

            DbParameter param1 = com.CreateParameter();
            param1.ParameterName = "@VCatd";
            param1.DbType = DbType.Int32;
            param1.Value = id;
            com.Parameters.Add(param1);

            VideoDetails vcd = new VideoDetails();
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);

            if (dt.Rows.Count > 0)
            {
                vcd.name = dt.Rows[0]["name"].ToString();
                vcd.id = Convert.ToInt32( dt.Rows[0]["id"]);
                vcd.categoryID = Convert.ToInt32(dt.Rows[0]["CategoryID"].ToString());
                vcd.comment = dt.Rows[0]["comment"].ToString();
                vcd.pageFront = Convert.ToBoolean(dt.Rows[0]["PageFron"].ToString());
                vcd.path = dt.Rows[0]["path"].ToString();
            }
            return vcd;
        }

        public static DataTable GetVideosOnFront(int cid, int pageNum, out int howManyPages)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetVideosInCategori";

            DbParameter param = com.CreateParameter();
            param.ParameterName = "@categoryID";
            param.DbType = DbType.Int32;
            param.Value = cid;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@descriptionLenght";
            param.DbType = DbType.Int32;
            param.Value = AdminPanelConfugration.VideoCommentLenght;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@pageNumber";
            param.DbType = DbType.Int32;
            param.Value = pageNum;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@videoPerPage";
            param.DbType = DbType.Int32;
            param.Value = AdminPanelConfugration.VideoPerPage;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@howManyVideo";
            param.DbType = DbType.Int32;
            param.Direction = ParameterDirection.Output;
            com.Parameters.Add(param);

          
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);
            int howManyVideo = Int32.Parse(com.Parameters["@howManyVideo"].Value.ToString());
            howManyPages =(int)Math.Ceiling((double)howManyVideo / (double)AdminPanelConfugration.VideoPerPage);
            return dt;
        }
    
        public static void AddVideo(Video video)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "AddVideo";

            DbParameter param = com.CreateParameter();
            param.ParameterName = "@VideoName";
            param.DbType = DbType.String;
            param.Value = video.Name;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@VideoThumb";
            param.DbType = DbType.String;
            param.Value = video.Thumb;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@VideoComment";
            param.DbType = DbType.String;
            param.Value = video.Comment;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@CategoryID";
            param.DbType = DbType.Int32;
            param.Value = video.CatId;
            com.Parameters.Add(param);

            GenericDataAccess.ExecuteNonCommand(com);
        }

        public static void DeleteVideo(Video video)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "DeleteVideo";

            DbParameter param = com.CreateParameter();
            param.ParameterName = "@VID";
            param.DbType = DbType.Int32;
            param.Value = video.CatId;
            com.Parameters.Add(param);

            GenericDataAccess.ExecuteNonCommand(com);
        }

    }
}