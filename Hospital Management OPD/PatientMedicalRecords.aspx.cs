using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_Management_OPD;

namespace Hospital_Management_OPD
{
    public partial class PatientMedicalRecords : System.Web.UI.Page
    {
        MedicalRecords_db main = new MedicalRecords_db();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int patientId = Convert.ToInt32(Session["PatientId"]); // Session stores patient ID
                LoadMedicalRecords(patientId);
            }
            Session.Remove("PatientId");

        }

        //private int GetPatientIdFromSession()
        //{
        //    if (Session["PatientId"] != null)
        //    {
        //        return Session["PatientId"] != null ? Convert.ToInt32(Session["PatientId"]) : 0;
        //    }
        //    return 0;

        //}

        private void LoadMedicalRecords(int patientId)
        {
            DataTable dtRecords = main.GetMedicalRecordsByPatient(patientId);
            if (dtRecords.Rows.Count > 0)
            {
                lblPatientName.Text = dtRecords.Rows[0]["patient_name"].ToString();
                gvMedicalRecords.DataSource = dtRecords;
                gvMedicalRecords.DataBind();
            }
            else
            {
                lblPatientName.Text = "No records found.";
            }
        }

        protected void gvMedicalRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateRecord")
            {
                int recordId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"UpdateMedicalRecord.aspx?recordId={recordId}");
               
                
            }
            else if (e.CommandName == "DeleteRecord")
            {
                int recordId = Convert.ToInt32(e.CommandArgument);
                DeleteMedicalRecord(recordId);
                LoadMedicalRecords(Convert.ToInt32(Session["SelectedPatientID"])); // Refresh the list after deletion
            }
        }

        private void DeleteMedicalRecord(int recordId)
        {
            // Call the DeleteMedicalRecord stored procedure
            bool success = main.DeleteMedicalRecord(recordId);
            if (success)
            {
                // Display a success message or update the UI as needed
                lblMessage.Text = "Record deleted successfully.";
                lblMessage.CssClass = "text-success";
            }
            else
            {
                lblMessage.Text = "Failed to delete record.";
                lblMessage.CssClass = "text-danger";
            }
        }

    
    }
}

