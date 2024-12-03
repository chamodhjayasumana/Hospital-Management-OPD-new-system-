using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class AddMedicalRecord : System.Web.UI.Page
    {
        MedicalRecords_db main = new MedicalRecords_db();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Retrieve the session variables
                if (Session["AppointmentId"] != null && Session["PatientId"] != null && Session["DoctorId"] != null)
                {
                    int appointmentId = Convert.ToInt32(Session["AppointmentId"]);
                    int patientId = Convert.ToInt32(Session["PatientId"]);
                    int doctorId = Convert.ToInt32(Session["DoctorId"]);

                    // Populate form fields with session data
                    txtAppointmentId.Text = appointmentId.ToString();
                    txtPatientId.Text = patientId.ToString();
                    txtDoctorId.Text = doctorId.ToString();
                }
                else
                {
                    // Handle case where session data is missing
                    lblMessage.Text = "Session expired or no appointment selected.";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Retrieve values from form fields
            int appointmentId = Convert.ToInt32(txtAppointmentId.Text);
            int patientId = Convert.ToInt32(txtPatientId.Text);
            int doctorId = Convert.ToInt32(txtDoctorId.Text);
            DateTime visitDate = Convert.ToDateTime(txtVisitDate.Text);
            string diagnosis = txtDiagnosis.Text;
            string prescribedTreatment = txtTreatment.Text;

            // Call method to insert the medical record
            bool success = main.InsertMedicalRecord(patientId, doctorId, visitDate, diagnosis, prescribedTreatment);

            // Display success or failure message
            lblMessage.Visible = true;
            lblMessage.Text = success ? "Medical record added successfully." : "Failed to add medical record.";
            lblMessage.CssClass = success ? "text-success" : "text-danger";
            Session.Remove("PatientId");
            Session.Remove("DoctorId");
            Session.Remove("AppointmentId");



        }

    }
}

