using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Hospital_Management_OPD.App_Code;

namespace Hospital_Management_OPD.App_Code
{
    public class DB_Connection
    {
        public DB_Connection()
        {
        }

        public SqlConnection GetConnection()
        {
            String Connection_string = ConfigurationManager.ConnectionStrings["HospitalManagementOPD"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(Connection_string);
            return con;

        }
    }

}

