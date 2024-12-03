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
    public partial class ManageDoctors : System.Web.UI.Page
    {
        Doctors_DB main = new Doctors_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDoctors();
                LoadDepartments();
            }
        }

        private void LoadDepartments()
        {
            DataTable dtDepartments = main.GetDepartments();
            ddlDepartments.DataSource = dtDepartments;
            ddlDepartments.DataTextField = "department_name";
            ddlDepartments.DataValueField = "department_id";
            ddlDepartments.DataBind();

            ddlDepartments.Items.Insert(0, new ListItem("-- Select Department --", ""));
        }


        private void LoadDoctors()
        {
            DataTable doctors = main.GetAllDoctorsWithDepartments();
            gvDoctors.DataSource = doctors;
            gvDoctors.DataBind();
        }



        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string specialization = txtSpecialization.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            int departmentId = Convert.ToInt32(ddlDepartments.SelectedValue);

            bool success = main.InsertDoctor(firstName, lastName, specialization, phoneNumber, email, departmentId);

            lblMessage.Visible = true;
            lblMessage.Text = success ? "Doctor added successfully!" : "Failed to add doctor.";
            lblMessage.CssClass = success ? "text-success" : "text-danger";

            LoadDoctors(); 
        }


 

        protected void gvDoctors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateDoctor")
            {
                int doctorId = Convert.ToInt32(e.CommandArgument);

                Session["doctorId"] = doctorId;
                Response.Redirect("UpdateDoctor.aspx");

            }
        }



    }

}



