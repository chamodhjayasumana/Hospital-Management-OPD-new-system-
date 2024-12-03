using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Hospital_Management_OPD.App_Code;

namespace Hospital_Management_OPD
{
    public class MedicalRecords_db
    {

        public MedicalRecords_db() { }

        private DB_Connection db = new DB_Connection();

        public bool InsertMedicalRecord(int patientId, int doctorId, DateTime visitDate, string diagnosis, string prescribedTreatment)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("InsertMedicalRecord", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@patient_id", patientId);
                    cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                    cmd.Parameters.AddWithValue("@visit_date", visitDate);
                    cmd.Parameters.AddWithValue("@diagnosis", diagnosis);
                    cmd.Parameters.AddWithValue("@prescribed_treatment", prescribedTreatment);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateMedicalRecord(int recordId, string diagnosis, string prescribedTreatment)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("UpdateMedicalRecord", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@record_id", recordId);
                    cmd.Parameters.AddWithValue("@diagnosis", diagnosis);
                    cmd.Parameters.AddWithValue("@prescribed_treatment", prescribedTreatment);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public DataTable GetMedicalRecordsByPatient(int patientId)
        {
            DataTable medicalRecords = new DataTable();
            using (SqlConnection conn = db.GetConnection())
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
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return medicalRecords;
        }

        public bool DeleteMedicalRecord(int recordId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("DeleteMedicalRecord", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@record_id", recordId);
                     
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public DataTable GetAllMedicalRecords()
        {
            DataTable medicalRecords = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetAllMedicalRecords", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable GetMedicalRecordById(int recordId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetMedicalRecordById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@record_id", recordId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return dt;
            }
        }

    }
}