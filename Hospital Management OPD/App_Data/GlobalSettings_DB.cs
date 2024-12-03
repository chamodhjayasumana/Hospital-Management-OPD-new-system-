using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Hospital_Management_OPD.App_Code;

namespace Hospital_Management_OPD
{
    public class GlobalSettings_DB
    {
        public GlobalSettings_DB() { }

        private DB_Connection db = new DB_Connection();

        public DataTable GetGlobalSettings()
        {
            DataTable settingsTable = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetGlobalSettings", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(settingsTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return settingsTable;
        }

        public DataTable AuthenticateAdmin(string username, string password)
        {
            DataTable adminData = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("AuthenticateAdmin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); 

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(adminData);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return adminData;
        }


    }
}