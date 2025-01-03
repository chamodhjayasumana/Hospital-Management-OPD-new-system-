﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class DashBoard : System.Web.UI.Page
    {
        Doctors_DB main = new Doctors_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDoctorAppointments();
            }
        }

        private void BindDoctorAppointments()
        {
            DataTable doctorsData = main.GetAllDoctorsWithDepartments(); 
            rptDoctors.DataSource = doctorsData;
            rptDoctors.DataBind();
        }

        
        protected void rptDoctors_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int doctorId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "doctor_id"));
                Repeater rptAppointments = (Repeater)e.Item.FindControl("rptAppointments");

                DataTable appointmentsData = main.GetAppointmentsByDoctor(doctorId);
                rptAppointments.DataSource = appointmentsData;
                rptAppointments.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewDahboard.aspx");
        }
    }
}