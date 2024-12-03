using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_Management_OPD;
using Hospital_Management_OPD.App_Code;

namespace Hospital_Management_OPD
{
    public partial class AddPatient : System.Web.UI.Page
    {
    
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
               
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                DateTime dateOfBirth = DateTime.Parse(txtDOB.Text);
                string gender = ddlGender.SelectedValue;
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                string emergencyContact = txtEmergencyContact.Text.Trim();
                string bloodGroup = ddlBloodGroup.SelectedValue;

                
                Main main = new Main();

                // Call the InsertPatient method
                bool isInserted = main.InsertPatient(firstName, lastName, dateOfBirth, gender, phoneNumber, email, address, emergencyContact, bloodGroup);

                
                if (isInserted)
                {
                    lblMessage.Text = "Patient added successfully!";
                    lblMessage.CssClass = "text-success";
                    ClearForm();
                }
                else
                {
                    lblMessage.Text = "Failed to add patient.";
                    lblMessage.CssClass = "text-danger";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"An error occurred: {ex.Message}";
                lblMessage.CssClass = "text-danger";
            }
        }

        //protected void btnTest_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DB_Connection db = new DB_Connection();
        //        using (SqlConnection conn = db.GetConnection())
        //        {
        //            conn.Open();
        //            lblMessage.Text = "Connection successful!";
        //            lblMessage.CssClass = "text-success";

                    

                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMessage.Text = "Connection failed: " + ex.Message;
        //        lblMessage.CssClass = "text-danger";
        //    }
        //}

        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDOB.Text = "";
            ddlGender.SelectedIndex = 0;  
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtEmergencyContact.Text = "";
            ddlBloodGroup.SelectedIndex = 0;  
        }

    }
}
