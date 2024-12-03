using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class UpdateMedicalRecord : System.Web.UI.Page
    {
        MedicalRecords_db main = new MedicalRecords_db();
        int recordId;

        protected void Page_Load(object sender, EventArgs e)
        {
            recordId = Convert.ToInt32(Request.QueryString["recordId"]);
            if (!IsPostBack)
            {
                LoadRecordDetails(recordId);
            }
        }

        private void LoadRecordDetails(int id)
        {
            DataTable dt = main.GetMedicalRecordById(id);  // Ensure this method exists
            if (dt.Rows.Count > 0)
            {
                txtDiagnosis.Text = dt.Rows[0]["diagnosis"].ToString();
                txtTreatment.Text = dt.Rows[0]["prescribed_treatment"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text) || string.IsNullOrWhiteSpace(txtTreatment.Text))
            {
                lblMessage.Text = "Diagnosis and treatment fields cannot be empty.";
                lblMessage.CssClass = "text-danger";
                lblMessage.Visible = true;
                return;
            }

            bool success = main.UpdateMedicalRecord(recordId, txtDiagnosis.Text.Trim(), txtTreatment.Text.Trim());
            lblMessage.Text = success ? "Record updated successfully!" : "Failed to update record.";
            lblMessage.CssClass = success ? "text-success" : "text-danger";
            lblMessage.Visible = true;
        }

    }
}

