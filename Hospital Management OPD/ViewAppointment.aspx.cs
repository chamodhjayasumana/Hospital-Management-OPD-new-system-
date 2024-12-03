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
    public partial class ViewAppointment : System.Web.UI.Page
    {
        Appointments_DB main = new Appointments_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int patientId = GetPatientIdFromSession(); 
                if (patientId > 0)
                {
                    LoadAppointments(patientId);
                }
                else
                {
                    lblMessage.Text = "Invalid patient ID.";
                }
                //Session.Remove("PatientId");

            }
        }

        private int GetPatientIdFromSession()
        {
            if (Session["PatientId"] != null)
            {
                return Session["PatientId"] != null ? Convert.ToInt32(Session["PatientId"]) : 0;
            }
            return 0;
            
        }

        private void LoadAppointments(int patientId)
        {
            DataTable appointments = main.GetPatientAppointments(patientId);
            if (appointments.Rows.Count > 0)
            {
                gvAppointments.DataSource = appointments;
                gvAppointments.DataBind();
            }
            else
            {
                lblMessage.Text = "No appointments found for this patient.";
            }
        }

        protected void btnAddMedicalRecord_Click(object sender, EventArgs e)
        {
            int selectedAppointmentId = 0;

            // Iterate through the GridView to find the selected appointment
            foreach (GridViewRow row in gvAppointments.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                if (chkSelect != null && chkSelect.Checked)
                {
                    selectedAppointmentId = Convert.ToInt32(gvAppointments.DataKeys[row.RowIndex].Value);
                    break;
                }
            }

            if (selectedAppointmentId > 0)
            {
                // Fetch appointment details
                DataTable appointmentDetails = main.GetAppointmentDetailsById(selectedAppointmentId);
                if (appointmentDetails.Rows.Count > 0)
                {
                    int patientId = Convert.ToInt32(appointmentDetails.Rows[0]["patient_id"]);
                    int doctorId = Convert.ToInt32(appointmentDetails.Rows[0]["doctor_id"]);

                    // Store the details in session and redirect
                    Session["AppointmentId"] = selectedAppointmentId;
                    Session["PatientId"] = patientId;
                    Session["DoctorId"] = doctorId;

                    Response.Redirect("AddMedicalRecord.aspx");
                }
                else
                {
                    lblMessage.Text = "Appointment details not found.";
                }
            }
            else
            {
                lblMessage.Text = "Please select an appointment to add a medical record.";
            }
        }

        protected void btnAddAppointment_Click(object sender, EventArgs e)
        {


            int patientId = GetPatientIdFromSession();
            Session["PatientId"] = patientId;
            Response.Redirect("AddAppointment.aspx");
        }
    }
}

