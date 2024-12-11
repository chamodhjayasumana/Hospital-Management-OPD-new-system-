using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Hospital_Management_OPD.App_Code;

namespace Hospital_Management_OPD
{
    public class Appointments_DB
    {
        public Appointments_DB() { }

        private DB_Connection db = new DB_Connection();
        public bool InsertAppointment(int patientId, int doctorId, DateTime appointmentDateTime, string reasonForVisit)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertAppointment", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Debugging line
                        Console.WriteLine("Appointment DateTime: " + appointmentDateTime.ToString());

                        cmd.Parameters.AddWithValue("@patient_id", patientId);
                        cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                        cmd.Parameters.AddWithValue("@appointment_date", appointmentDateTime);  // Ensure this includes time
                        cmd.Parameters.AddWithValue("@reason_for_visit", reasonForVisit);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }


        //public DataTable GetPatientAppointments(int patientId)
        //{
        //    using (SqlConnection conn = db.GetConnection())
        //    {
        //        try
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand("GetPatientAppointments", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@patient_id", patientId);

        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                return dt;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            return null;
        //        }
        //    }
        //}

        public DataTable GetMedicalRecordsByPatient(int patientId)
        {
            DataTable medicalRecords = new DataTable();
            using(SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetMedicalRecordsByPatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@patient_id", patientId);

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(medicalRecords);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it as needed
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return medicalRecords;
        }

        public bool UpdateAppointmentStatus(int appointmentId, string status)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateAppointmentStatus", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
                        cmd.Parameters.AddWithValue("@status", status);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

        }


        public DataTable GetPatientAppointments(int patientId)
        {
            DataTable appointments = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetPatientAppointments", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@patient_id", patientId);

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(appointments);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return appointments;
        }

        public DataTable GetAppointmentDetailsById(int appointmentId)
        {
            DataTable appointmentDetails = new DataTable();

            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetAppointmentDetailsById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@appointment_id", appointmentId);

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(appointmentDetails);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it as needed
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return appointmentDetails;
        }


        //public void AssignAppointmentNumbers(int doctorId, DateTime sessionDate, string sessionTime)
        //{
        //    using (SqlConnection conn = db.GetConnection())
        //    {
        //        try
        //        {
        //            // Open the connection
        //            conn.Open();

        //            // Create command to call stored procedure
        //            using (SqlCommand cmd = new SqlCommand("AssignAppointmentNumbers", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                // Add parameters to the stored procedure
        //                cmd.Parameters.AddWithValue("@doctor_id", doctorId);
        //                cmd.Parameters.AddWithValue("@session_date", sessionDate);
        //                cmd.Parameters.AddWithValue("@session_time", sessionTime);

        //                // Execute the stored procedure
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log the exception or handle it as needed
        //            throw new Exception("An error occurred while assigning appointment numbers: " + ex.Message);
        //        }
        //    }
        //}

        public bool AssignAppointmentNumber(int doctorId, DateTime sessionDate, string sessionTime)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AssignAppointmentNumbers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                    cmd.Parameters.AddWithValue("@session_date", sessionDate);
                    cmd.Parameters.AddWithValue("@session_time", sessionTime);

                    conn.Open();
                    cmd.ExecuteNonQuery();  // Execute the stored procedure
                    conn.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }






    }
}
