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
    public partial class AddAppointment : System.Web.UI.Page
    {
        Appointments_DB Appoint = new Appointments_DB();
        Main main = new Main();
        Doctors_DB Doctorsdb = new Doctors_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
                LoadDepartments();
                // Ensure doctors dropdown starts empty
                ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", ""));
            }
        }

        //private void LoadPatients()
        //{
        //    if (Session["PatientId"] != null)
        //    {

        //    }


        //    DataTable patients = main.GetAllPatients();
        //    ddlPatient.DataSource = patients;
        //    ddlPatient.DataTextField = "first_name";
        //    ddlPatient.DataValueField = "patient_id";
        //    ddlPatient.DataBind();

        //    ddlPatient.Items.Insert(0, new ListItem("-- Select Patient --", ""));


        //}

        private void LoadPatients()
        {
           
            if (Session["PatientId"] != null)
            {
                int patientId = Convert.ToInt32(Session["PatientId"]);

                
                DataTable patientDetails = main.GetPatientByID(patientId);

                if (patientDetails.Rows.Count > 0)
                {
                    
                    ddlPatient.Items.Clear();
                    ddlPatient.DataSource = patientDetails;
                    ddlPatient.DataTextField = "first_name"; 
                    ddlPatient.DataValueField = "patient_id"; 
                    ddlPatient.DataBind();

                    
                    ddlPatient.Items.Insert(0, new ListItem("-- Select Patient --", ""));

                    
                    ddlPatient.SelectedValue = patientId.ToString();
                    ddlPatient.Enabled = false; 
                }
            }
            else
            {
                
                DataTable patients = main.GetAllPatients();
                ddlPatient.DataSource = patients;
                ddlPatient.DataTextField = "first_name"; 
                ddlPatient.DataValueField = "patient_id"; 
                ddlPatient.DataBind();

                ddlPatient.Items.Insert(0, new ListItem("-- Select Patient --", ""));
            }
        }

        private void LoadDepartments()
        {
            DataTable dtDepartments = Doctorsdb.GetDepartments();
            ddlDepartments.DataSource = dtDepartments;
            ddlDepartments.DataTextField = "department_name";
            ddlDepartments.DataValueField = "department_id";
            ddlDepartments.DataBind();

            ddlDepartments.Items.Insert(0, new ListItem("-- Select Department --", ""));
        }

        private void LoadDoctors(int departmentId)
        {
            if (departmentId > 0)
            {
                DataTable doctors = Doctorsdb.GetDoctorsByDepartment(departmentId);
                ddlDoctor.Items.Clear(); 

                if (doctors.Rows.Count > 0)
                {
                    ddlDoctor.DataSource = doctors;
                    ddlDoctor.DataTextField = "first_name";
                    ddlDoctor.DataValueField = "doctor_id";
                    ddlDoctor.DataBind();
                }
                else
                {
                    ddlDoctor.Items.Insert(0, new ListItem("No doctors found", ""));
                }

                ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", ""));
            }
            else
            {
                ddlDoctor.Items.Clear();
                ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", ""));
            }
        }


        protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ddlDepartments.SelectedValue, out int departmentId) && departmentId > 0)
            {
                LoadDoctors(departmentId);
            }
            else
            {
                ddlDoctor.Items.Clear();
                ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", ""));
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPatient.SelectedIndex == 0 || ddlDoctor.SelectedIndex == 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please select both patient and doctor.";
                    lblMessage.CssClass = "text-danger";
                    return;
                }

                int patientId = Convert.ToInt32(ddlPatient.SelectedValue);
                int doctorId = Convert.ToInt32(ddlDoctor.SelectedValue);
                //DateTime appointmentDate = Convert.ToDateTime(txtAppointmentDate.Text);
                DateTime appointmentDate = DateTime.Parse(txtAppointmentDate.Text);
                TimeSpan appointmentTime = TimeSpan.Parse(txtAppointmentTime.Text);
                DateTime appointmentDateTime = appointmentDate.Add(appointmentTime);

                // Debugging line
                lblMessage.Visible = true;
                lblMessage.Text = "Combined DateTime: " + appointmentDateTime.ToString();
                lblMessage.CssClass = "text-info";



                string reasonForVisit = txtReason.Text.Trim();

                // Insert appointment
                bool success = Appoint.InsertAppointment(patientId, doctorId, appointmentDateTime, reasonForVisit);

                lblMessage.Visible = true;
                lblMessage.Text = success ? "Appointment created successfully!" : "Failed to create appointment.";
                lblMessage.CssClass = success ? "text-success" : "text-danger";

                if (success)
                {
                    Session.Remove("PatientId");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

        private void ClearForm()
        {
            ddlPatient.SelectedIndex = 0;
            ddlDepartments.SelectedIndex = 0;
            ddlDoctor.Items.Clear();
            ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", ""));
            txtAppointmentDate.Text = "";
            txtAppointmentTime.Text = "";
            txtReason.Text = "";
        }

    }
}

