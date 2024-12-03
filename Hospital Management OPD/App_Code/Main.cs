using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Hospital_Management_OPD.App_Code
{
    public class Main
    {
        private DB_Connection db = new DB_Connection();

        // Method to insert a new patient
        public bool InsertPatient(string firstName, string lastName, DateTime dateOfBirth, string gender, string phoneNumber, string email, string address, string emergencyContact, string bloodGroup)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertPatient", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@first_name", firstName);
                        cmd.Parameters.AddWithValue("@last_name", lastName);
                        cmd.Parameters.AddWithValue("@date_of_birth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@emergency_contact", emergencyContact);
                        cmd.Parameters.AddWithValue("@blood_group", bloodGroup);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // Method to update an existing patient
        public bool UpdatePatient(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender, string phoneNumber, string email, string address, string emergencyContact, string bloodGroup)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdatePatient", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@patient_id", patientId);
                        cmd.Parameters.AddWithValue("@first_name", firstName);
                        cmd.Parameters.AddWithValue("@last_name", lastName);
                        cmd.Parameters.AddWithValue("@date_of_birth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@emergency_contact", emergencyContact);
                        cmd.Parameters.AddWithValue("@blood_group", bloodGroup);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }

}

