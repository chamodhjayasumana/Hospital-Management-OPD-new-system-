using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class NewDahboard : System.Web.UI.Page
    {
        Doctors_DB main = new Doctors_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DateTime selectedDate = DateTime.Now.Date; // Default to today's date
                BindDoctorAppointments(selectedDate);
            }
        }

        private void BindDoctorAppointments(DateTime date)
        {
            DataTable availableDoctors = main.GetAvailableDoctorsWithDepartments(date);
            rptDoctors.DataSource = availableDoctors;
            rptDoctors.DataBind();
        }

        protected void rptDoctors_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int doctorId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "doctor_id"));
                Repeater rptAppointments = (Repeater)e.Item.FindControl("rptAppointments");

                DateTime selectedDate = DateTime.Now.Date; // Use the same date as the dashboard filter
                DataTable appointmentsData = main.GetAppointmentsByDoctorAndDate(doctorId, selectedDate);
                rptAppointments.DataSource = appointmentsData;
                rptAppointments.DataBind();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime selectedDate;
            if (DateTime.TryParse(txtDate.Text, out selectedDate))
            {
                BindDoctorAppointments(selectedDate);
            }

        }
    }
}