using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Renci.SshNet;

namespace Hospital_Management_OPD
{
    public partial class UpdateDSession : System.Web.UI.Page
    {
        DoctorSession_DB main = new DoctorSession_DB();
        Doctors_DB doctorDb = new Doctors_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDoctors();
               
            }
        }



        private void LoadDoctors()
        {
            DataTable dtDoctors = doctorDb.GetAllDoctors();
            ddlDoctors.DataSource = dtDoctors;
            ddlDoctors.DataTextField = "full_name"; // Adjust based on your column name
            ddlDoctors.DataValueField = "doctor_id";
            ddlDoctors.DataBind();
            ddlDoctors.Items.Insert(0, new ListItem("Select Doctor", ""));
        }



        protected void ddlDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDoctors.SelectedValue != "")
            {
                LoadSessions();
            }
        }

        private void LoadSessions()
        {
            if (ddlDoctors.SelectedValue != "")
            {
                int doctorId = Convert.ToInt32(ddlDoctors.SelectedValue);
                DataTable sessions = main.GetDoctorSessionsById(doctorId);
                gvSessions.DataSource = sessions;
                gvSessions.DataBind();
            }
        }


        protected void btnAddSession_Click(object sender, EventArgs e)
        {
            try
            {
                int doctorId = Convert.ToInt32(ddlDoctors.SelectedValue);
                DateTime sessionDate = Convert.ToDateTime(txtSessionDate.Text);
                string sessionTime = ddlSessionTime.SelectedValue;
                bool isPresent = ddlAttendanceStatus.SelectedValue == "1";

                if (main.AddDoctorSession(doctorId, sessionDate, sessionTime, isPresent))
                {
                    lblMessage.Text = "Session added successfully!";
                    lblMessage.CssClass = "text-success";
                    LoadSessions();
                    
                }
                else
                {
                    lblMessage.Text = "Failed to add session.";
                    lblMessage.CssClass = "text-danger";
                }

                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.CssClass = "text-danger";
                lblMessage.Visible = true;
            }
        }

        protected void gvSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int sessionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteSession")
            {
                //if (main.DeleteDoctorSession(sessionId))
                //{
                    main.DeleteDoctorSession(sessionId);
                    lblMessage.Text = "Session deleted successfully.";
                    lblMessage.CssClass = "text-success";
                    LoadSessions(); // Auto-refresh the GridView
                    lblMessage.Visible = true;
                //}
                //else
                //{
                //    lblMessage.Text = "Failed to delete session.";
                //    lblMessage.CssClass = "text-danger";
                //}
                //lblMessage.Visible = true;
            }
            else if (e.CommandName == "ToggleAttendance")
            {
                if (main.ToggleAttendance(sessionId))
                {
                    lblMessage.Text = "Attendance toggled successfully.";
                    lblMessage.CssClass = "text-success";
                    LoadSessions(); // Auto-refresh the GridView
                }
                else
                {
                    lblMessage.Text = "Failed to toggle attendance.";
                    lblMessage.CssClass = "text-danger";
                }
                lblMessage.Visible = true;
            }
        }

        protected void btnViewSession_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageDoctorSessions.aspx");

        }
    }
}

