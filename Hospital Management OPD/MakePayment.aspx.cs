using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_Management_OPD.App_Code;

namespace Hospital_Management_OPD
{
    public partial class MakePayment : System.Web.UI.Page
    {
        Appointments_DB Appointments = new Appointments_DB();
        Paiment_DB Paiment_DB = new Paiment_DB();
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
            // Fetch patient data from the database
            DataTable patients = main.GetAllPatients();
            ddlPatients.DataSource = patients;
            ddlPatients.DataTextField = "first_name";
            ddlPatients.DataValueField = "patient_id";
            ddlPatients.DataBind();

            ddlPatients.Items.Insert(0, new ListItem("-- Select Patient --", ""));
        }

        


        protected void ddlPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load appointments based on selected patient
            int patientId;
            if (int.TryParse(ddlPatients.SelectedValue, out patientId) && patientId > 0)
            {
                LoadAppointments(patientId);
            }
            else
            {
                // Clear the appointments dropdown if no valid patient is selected
                ddlAppointments.Items.Clear();
                ddlAppointments.Items.Insert(0, new ListItem("Select Appointment", ""));
            }
        }

        private void LoadAppointments(int patientId)
        {
            // Fetch appointments for the selected patient
            DataTable appointments = Appointments.GetPatientAppointments(patientId);
            ddlAppointments.DataSource = appointments;
            ddlAppointments.DataTextField = "appointment_date"; // Adjust this field as per your column
            ddlAppointments.DataValueField = "appointment_id";
            ddlAppointments.DataBind();
            ddlAppointments.Items.Insert(0, new ListItem("Select Appointment", ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int patientId = Convert.ToInt32(ddlPatients.SelectedValue);
                int appointmentId = Convert.ToInt32(ddlAppointments.SelectedValue);
                decimal doctorCharges = Convert.ToDecimal(txtDoctorCharges.Text);
                decimal hospitalCharges = Convert.ToDecimal(txtHospitalCharges.Text);
                string paymentStatus = ddlpaymentStatus.SelectedValue;
                string paymentMethod = ddlPaymentMethod.SelectedValue;
                

                bool success = Paiment_DB.InsertBillingRecord(patientId, appointmentId, doctorCharges, hospitalCharges, paymentStatus, paymentMethod);

                if (success)
                {
                    lblMessage.Text = "Payment recorded successfully!";
                    lblMessage.CssClass = "text-success";
                }
                else
                {
                    lblMessage.Text = "Error recording payment.";
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
        protected void btnViewBilling_Click(object sender, EventArgs e)
        {
            // Redirect to the ViewBilling page
            Response.Redirect("ViewBilling.aspx");
        }
    }
}


