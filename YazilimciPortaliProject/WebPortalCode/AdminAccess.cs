using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WebPortalCode
{
    public static class AdminAccess
    {
        public static DataTable GetAdmins()
        {
            //using (DataTable dt = new DataTable())
            //{
            //    using (DbCommand com = GenericDataAccess.CreateCommand())
            //    {
            //        com.CommandText = "GetAdminList";
                    
            //        dt = GenericDataAccess.ExecuteSelectCommand(com);
            //    }

            //    return dt;
            //}

            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetAdminList";

            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);
            return dt;   
        }

        public static DataTable GetAdmin(string name, string pss)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetAdmin";

            DbParameter param1 = com.CreateParameter();
            param1.ParameterName = "@AName";            
            param1.Value = name;
            com.Parameters.Add(param1);

            DbParameter param2 = com.CreateParameter();
            param2.ParameterName = "@APrl";
            param2.Value = pss;
            com.Parameters.Add(param2);
            
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);
            return dt;
        }

        public static DataTable GetUser(string name, string pss)
        {
            DbCommand com = GenericDataAccess.CreateCommand();
            com.CommandText = "GetUser";

            DbParameter param1 = com.CreateParameter();
            param1.ParameterName = "@AName";
            param1.Value = name;
            com.Parameters.Add(param1);

            DbParameter param2 = com.CreateParameter();
            param2.ParameterName = "@APrl";
            param2.Value = pss;
            com.Parameters.Add(param2);

            DataTable dt = GenericDataAccess.ExecuteSelectCommand(com);
            return dt;
        }

    }
}