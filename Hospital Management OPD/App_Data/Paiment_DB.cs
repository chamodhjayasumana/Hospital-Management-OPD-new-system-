using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Hospital_Management_OPD.App_Code;

namespace Hospital_Management_OPD
{
    public class Paiment_DB
    {

        public Paiment_DB() { }

        private DB_Connection db = new DB_Connection();


        public bool InsertBillingRecord(int patientId, int appointmentId, decimal doctorCharges, decimal hospitalCharges, string paymentStatus, string paymentMethod)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("InsertBillingRecord", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patient_id", patientId);
                cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
                cmd.Parameters.AddWithValue("@doctor_charges", doctorCharges);
                cmd.Parameters.AddWithValue("@hospital_charges", hospitalCharges);
                cmd.Parameters.AddWithValue("@payment_status", paymentStatus);
                cmd.Parameters.AddWithValue("@payment_method", paymentMethod);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }


        public DataTable GetBillingByPatient(int patientId)
        {
            DataTable dtBilling = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetBillingByPatient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patient_id", patientId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtBilling);
            }
            return dtBilling;
        }


        public bool UpdatePaymentStatus(int billId, string paymentStatus, string paymentMethod)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdatePaymentStatus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bill_id", billId);
                cmd.Parameters.AddWithValue("@payment_status", paymentStatus);
                cmd.Parameters.AddWithValue("@payment_method", paymentMethod);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }


        public DataTable GetBillingRecords(string patientName = "", string paymentStatus = "")
        {
            using (SqlConnection conn = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetFilteredBillingRecords", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientName", patientName);
                cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}