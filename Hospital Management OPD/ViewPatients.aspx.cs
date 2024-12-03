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
    public partial class ViewPatients : System.Web.UI.Page
    {
        Main main = new Main();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
            }
        }

        private void LoadPatients()
        {
            DataTable dt = main.GetAllPatients();
            gvPatients.DataSource = dt;
            gvPatients.DataBind();

        }

        protected void gvPatients_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdatePatient")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int patientId = Convert.ToInt32(gvPatients.DataKeys[index].Value);
                // Store the patientId in the session
                Session["PatientId"] = patientId;

                // Redirect to the UpdatePatient page
                Response.Redirect("UpdatePatient.aspx");
            }
            else if (e.CommandName == "ViewAppointment")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int patientId = Convert.ToInt32(gvPatients.DataKeys[index].Value);
                //Response.Redirect($"ViewAppointment.aspx?patientId={patientId}");

                Session["PatientId"] = patientId;
                Response.Redirect("ViewAppointment.aspx");

            }
            else if(e.CommandName == "PatientMedicalRecords")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int patientId = Convert.ToInt32(gvPatients.DataKeys[index].Value);
               
                Session["PatientId"] = patientId;

               
                Response.Redirect("PatientMedicalRecords.aspx");
            }
        }

        private void LoadPatients(string searchTerm = "")
        {
            DataTable dt;
            if (string.IsNullOrEmpty(searchTerm))
            {
                dt = main.GetAllPatients();
            }
            else
            {
                dt = main.SearchPatients(searchTerm); // Add this method in your Main class
            }

            gvPatients.DataSource = dt;
            gvPatients.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadPatients(searchTerm);
        }

        // Existing RowCommand logic...
    }


}




