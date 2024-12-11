using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class ManageDoctorSessions : System.Web.UI.Page
    {
        Doctors_DB doctorDb = new Doctors_DB();
        DoctorSession_DB sessionDb = new DoctorSession_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDoctors();
                LoadSessions();
            }
        }

        //private void LoadDoctors()
        //{
        //    DataTable dtDoctors = doctorDb.GetAllDoctors();
        //    ddlDoctors.DataSource = dtDoctors;
        //    ddlDoctors.DataTextField = "full_name"; // Adjust based on your column name
        //    ddlDoctors.DataValueField = "doctor_id";
        //    ddlDoctors.DataBind();
        //    ddlDoctors.Items.Insert(0, new ListItem("Select Doctor", ""));
        //}

        private void LoadSessions()
        {
            DataTable dtSessions = sessionDb.GetDoctorSessions();
            gvDoctorSessions.DataSource = dtSessions;
            gvDoctorSessions.DataBind();
        }


        protected void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                int doctorId = Convert.ToInt32(ddlDoctors.SelectedValue);
                DateTime sessionDate = Convert.ToDateTime(txtSessionDate.Text);
                string sessionTime = ddlSessionTime.SelectedValue;

                bool success = sessionDb.MarkDoctorAttendance(doctorId, sessionDate, sessionTime);
                if (success)
                {
                    lblMessage.Text = "Attendance marked successfully.";
                    lblMessage.CssClass = "text-success";
                }
                else
                {
                    lblMessage.Text = "Failed to mark attendance.";
                    lblMessage.CssClass = "text-danger";
                }

                lblMessage.Visible = true;
                LoadSessions();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.CssClass = "text-danger";
                lblMessage.Visible = true;
            }
        }


        private void LoadDoctors()
        {
            try
            {
               

                // Get doctors who have sessions
                DataTable dtDoctorsWithSessions = sessionDb.GetDoctorsWithSessions();
                List<int> doctorsWithSessions = new List<int>();

                // Add doctor_ids to a list for comparison
                foreach (DataRow row in dtDoctorsWithSessions.Rows)
                {
                    doctorsWithSessions.Add(Convert.ToInt32(row["doctor_id"]));
                }

                // Now load all doctors into the dropdown, but exclude those with existing sessions
                DataTable dtAllDoctors = sessionDb.GetAllDoctors(); // Assume this fetches all doctors
                var filteredDoctors = dtAllDoctors.AsEnumerable()
                                                  .Where(row => !doctorsWithSessions.Contains(Convert.ToInt32(row["doctor_id"])))
                                                  .CopyToDataTable();

                ddlDoctors.DataSource = filteredDoctors;
                ddlDoctors.DataTextField = "doctor_name"; // Assuming doctor_name is in the table
                ddlDoctors.DataValueField = "doctor_id";
                ddlDoctors.DataBind();

                // Optionally add a default "Select" option
                ddlDoctors.Items.Insert(0, new ListItem("Select Doctor", "0"));
            }
            catch (Exception ex)
            {
                // Handle exception
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.Visible = true;
            }
        }






    }
}
