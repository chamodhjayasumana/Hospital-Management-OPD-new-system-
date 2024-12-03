using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class ViewMedicalRecords : System.Web.UI.Page
    {
        MedicalRecords_db main = new MedicalRecords_db();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMedicalRecords();
            }
        }

        private void LoadMedicalRecords()
        {
            DataTable dt = main.GetAllMedicalRecords(); // Ensure this method exists in Main class
            gvMedicalRecords.DataSource = dt;
            gvMedicalRecords.DataBind();
        }

        protected void gvMedicalRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int recordId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteRecord")
            {
                bool success = main.DeleteMedicalRecord(recordId);
                lblMessage.Text = success ? "Record deleted successfully!" : "Failed to delete record.";
                lblMessage.Visible = true;
                LoadMedicalRecords();
            }
            else if (e.CommandName == "UpdateRecord")
            {
                Response.Redirect($"UpdateMedicalRecord.aspx?recordId={recordId}");
            }
        }
    }
}