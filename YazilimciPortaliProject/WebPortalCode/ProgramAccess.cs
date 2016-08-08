using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using WebPortalCode.Entities;

namespace WebPortalCode
{
    public static class ProgramAccess
    {
        public static DataTable GetPrograms(int id)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetPrograms";
            DbParameter param1 = com.CreateParameter();
            param1.ParameterName = "@CID";
            param1.Value = id;
            com.Parameters.Add(param1);
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);
            return dt;
        }

        public static DemoProgram GetProgramDetail(int id)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetProgramDetail";
            DbParameter param1 = com.CreateParameter();
            param1.ParameterName = "@PID";
            param1.DbType = DbType.Int32;
            param1.Value = id;
            com.Parameters.Add(param1);
            DemoProgram vcd = new DemoProgram();
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);

            if (dt.Rows.Count > 0)
            {
                vcd.Name = dt.Rows[0]["name"].ToString();
                vcd.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                vcd.CatId = Convert.ToInt32(dt.Rows[0]["CategoryID"].ToString());
                vcd.Comment = dt.Rows[0]["comment"].ToString();
                vcd.IsAktive = Convert.ToBoolean(dt.Rows[0]["PageFron"].ToString());
                vcd.Thumb = dt.Rows[0]["path"].ToString();
            }
            return vcd;
        }

        public static void AddProgram(DemoProgram video)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "AddProgram";

            DbParameter param = com.CreateParameter();
            param.ParameterName = "@Name";
            param.DbType = DbType.String;
            param.Value = video.Name;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@Thumb";
            param.DbType = DbType.String;
            param.Value = video.Thumb;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@Comment";
            param.DbType = DbType.String;
            param.Value = video.Comment;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@CaID";
            param.DbType = DbType.Int32;
            param.Value = video.CatId;
            com.Parameters.Add(param);

            GenericDataAccess.ExecuteNonCommand(com);
        }
    }
}