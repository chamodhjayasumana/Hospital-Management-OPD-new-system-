using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_Management_OPD;

namespace Hospital_Management_OPD
{
    public partial class UpdatePatient : System.Web.UI.Page
    {
        Main main = new Main(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["PatientId"] != null)
                {
                    int patientId = Convert.ToInt32(Session["PatientId"]);
                    LoadPatientDetails(patientId);

                }
                else
                {
                    
                    lblMessage.Text = "Patient ID is missing from session.";
                    lblMessage.CssClass = "text-danger";
                }


            }
        }

        private void LoadPatientDetails(int patientId)
        {
            DataTable patientData = main.GetPatientByID(patientId); 

            if (patientData.Rows.Count > 0)
            {
                DataRow row = patientData.Rows[0];
                lblPatientIDValue.Text = row["patient_id"].ToString();
                txtFirstName.Text = row["first_name"].ToString();
                txtLastName.Text = row["last_name"].ToString();
                txtDateOfBirth.Text = Convert.ToDateTime(row["date_of_birth"]).ToString("yyyy-MM-dd");
                ddlGender.SelectedValue = row["gender"].ToString();
                txtPhoneNumber.Text = row["phone_number"].ToString();
                txtEmail.Text = row["email"].ToString();
                txtAddress.Text = row["address"].ToString();
                txtEmergencyContact.Text = row["emergency_contact"].ToString();
                ddlBloodGroup.SelectedValue = row["blood_group"].ToString();
            }
            else
            {
                lblMessage.Text = "Patient not found.";
                lblMessage.CssClass = "text-danger";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["PatientId"] != null)
            {
                int patientId = Convert.ToInt32(Session["PatientId"]);

                
                bool success = main.UpdatePatient(
                    patientId,
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    Convert.ToDateTime(txtDateOfBirth.Text),
                    ddlGender.SelectedValue,
                    txtPhoneNumber.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtAddress.Text.Trim(),
                    txtEmergencyContact.Text.Trim(),
                    ddlBloodGroup.SelectedValue
                );

                lblMessage.Text = success ? "Patient updated successfully!" : "Update failed.";
                lblMessage.CssClass = success ? "text-success" : "text-danger";
                //Response.Redirect("ViewPatients.aspx");
                Session.Remove("PatientId");

            }
            else
            {   
                lblMessage.Text = "Session expired or invalid patient ID.";
                lblMessage.CssClass = "text-danger";
            }
        }

        
    }
}

