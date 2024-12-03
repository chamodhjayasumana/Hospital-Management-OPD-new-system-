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
    public partial class UpdateDoctor : System.Web.UI.Page
    {

        Doctors_DB main = new Doctors_DB();
        int doctorId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //doctorId = Convert.ToInt32(Request.QueryString["doctorId"]);
                doctorId = GetdoctorIdFromSession();
                LoadDoctorDetails(doctorId);
                LoadDepartments();  // Populate the dropdown
            }
        }

        private int GetdoctorIdFromSession()
        {
            if (Session["doctorId"] != null)
            {
                return Convert.ToInt32(Session["doctorId"]);
            }
            return 0;
        }

        private void LoadDoctorDetails(int id)
        {
            DataTable doctorData = main.GetDoctorByID(id);
            if (doctorData.Rows.Count > 0)
            {

                txtFirstName.Text = doctorData.Rows[0]["first_name"].ToString();
                txtLastName.Text = doctorData.Rows[0]["last_name"].ToString();
                txtSpecialization.Text = doctorData.Rows[0]["specialization"].ToString();
                txtPhoneNumber.Text = doctorData.Rows[0]["phone_number"].ToString();
                txtEmail.Text = doctorData.Rows[0]["email"].ToString();
                ddlDepartment.SelectedValue = doctorData.Rows[0]["department_id"].ToString();
            }
        }

        private void LoadDepartments()
        {
            DataTable dtDepartments = main.GetDepartments();
            ddlDepartment.DataSource = dtDepartments;
            ddlDepartment.DataTextField = "department_name";
            ddlDepartment.DataValueField = "department_id";
            ddlDepartment.DataBind();
        }

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    doctorId = Convert.ToInt32(Request.QueryString["doctorId"]);
        //    bool success = main.UpdateDoctor(
        //        doctorId,
        //        txtFirstName.Text,
        //        txtLastName.Text,
        //        txtSpecialization.Text,
        //        txtPhoneNumber.Text,
        //        txtEmail.Text,
        //        Convert.ToInt32(ddlDepartment.SelectedValue)
        //    );

        //    lblMessage.Text = success ? "Doctor updated successfully!" : "Update failed. Please try again.";
        //}
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            doctorId = GetdoctorIdFromSession();
            if (doctorId > 0)
            {
                // Validate all fields before update
                if (ValidateFields())
                {
                    bool success = main.UpdateDoctor(
                        doctorId,
                        txtFirstName.Text.Trim(),
                        txtLastName.Text.Trim(),
                        txtSpecialization.Text.Trim(),
                        txtPhoneNumber.Text.Trim(),
                        txtEmail.Text.Trim(),
                        Convert.ToInt32(ddlDepartment.SelectedValue)
                    );

                    lblMessage.Text = success ? "Doctor updated successfully!" : "Update failed. Please try again.";
                }
                else
                {
                    lblMessage.Text = "Please fill in all required fields correctly.";
                }
            }
            else
            {
                lblMessage.Text = "Invalid Doctor ID.";
            }
        }

        private bool ValidateFields()
        {
            // Simple field validation logic
            return !string.IsNullOrEmpty(txtFirstName.Text) &&
                   !string.IsNullOrEmpty(txtLastName.Text) &&
                   !string.IsNullOrEmpty(txtSpecialization.Text) &&
                   !string.IsNullOrEmpty(txtPhoneNumber.Text) &&
                   !string.IsNullOrEmpty(txtEmail.Text) &&
                   ddlDepartment.SelectedValue != "0";
        }
    }

}


