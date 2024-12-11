using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Hospital_Management_OPD.App_Code;
using System.Drawing;
using System.Configuration;

namespace Hospital_Management_OPD
{
    public class DoctorSession_DB
    {
        public DoctorSession_DB() { }

        private DB_Connection db = new DB_Connection();

        public bool MarkDoctorAttendance(int doctorId, DateTime sessionDate, string sessionTime)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("MarkDoctorAttendance", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                cmd.Parameters.AddWithValue("@session_date", sessionDate);
                cmd.Parameters.AddWithValue("@session_time", sessionTime);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetDoctorSessions()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT d.first_name, d.last_name, ds.session_date, ds.session_time, ds.is_present,
                       (SELECT COUNT(*) FROM Appointments WHERE doctor_id = ds.doctor_id AND CAST(appointment_date AS DATE) = ds.session_date) AS appointment_count
                FROM DoctorSessions ds
                INNER JOIN Doctors d ON ds.doctor_id = d.doctor_id
                ORDER BY ds.session_date DESC, ds.session_time", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        


        public DataTable GetDoctorSessionsById(int doctorId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetDoctorSessions", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@doctor_id", doctorId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool ToggleAttendance(int sessionId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("ToggleDoctorAttendance", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@session_id", sessionId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool MarkDoctorAbsent(int sessionId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE DoctorSessions SET is_present = 0 WHERE session_id = @SessionID", conn))
                {
                    cmd.Parameters.AddWithValue("@SessionID", sessionId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected > 0;
                }
            }
        }

        public DataTable GetDoctorsWithSessions()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("GetDoctorsWithSessions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public DataTable GetAllDoctors()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("GetAllDoctors", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public bool DoctorHasSessionOnDate(int doctorId, DateTime sessionDate)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("CheckDoctorSession", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    cmd.Parameters.AddWithValue("@SessionDate", sessionDate);

                    conn.Open();
                    int sessionCount = (int)cmd.ExecuteScalar();
                    return sessionCount > 0; // Return true if a session exists, false otherwise
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool UpdateDoctorSession(int sessionId, DateTime sessionDate, string sessionTime, bool isPresent)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateDoctorSession", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@session_id", sessionId);
                cmd.Parameters.AddWithValue("@session_date", sessionDate);
                cmd.Parameters.AddWithValue("@session_time", sessionTime);
                cmd.Parameters.AddWithValue("@is_present", isPresent);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        public bool AddDoctorSession(int doctorId, DateTime sessionDate, string sessionTime, bool isPresent)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO DoctorSessions (doctor_id, session_date, session_time, is_present) VALUES (@doctor_id, @session_date, @session_time, @is_present)", conn);
                cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                cmd.Parameters.AddWithValue("@session_date", sessionDate);
                cmd.Parameters.AddWithValue("@session_time", sessionTime);
                cmd.Parameters.AddWithValue("@is_present", isPresent);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool ToggleDoctorAttendance(int sessionId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("ToggleDoctorAttendance", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@session_id", sessionId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        public bool DeleteDoctorSession(int sessionId)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("DeleteDoctorSession", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@session_id", sessionId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the DELETE command

                    return rowsAffected > 0; // Return true if at least one row is deleted
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine("Error deleting doctor session: " + ex.Message);
                return false; // Return false if there is an error
            }
        }


    }
}