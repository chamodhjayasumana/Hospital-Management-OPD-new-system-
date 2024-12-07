using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class ViewBilling : System.Web.UI.Page
    {

        Paiment_DB main = new Paiment_DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBillingData();
            }
        }

        private void LoadBillingData(string searchPatient = "", string paymentStatus = "")
        {
            // Assume main.GetBillingRecords is a method that fetches billing data based on filters.
            DataTable dtBilling = main.GetBillingRecords(searchPatient, paymentStatus);
            gvBilling.DataSource = dtBilling;
            gvBilling.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchPatient = txtSearchPatient.Text.Trim();
            string paymentStatus = ddlPaymentStatus.SelectedValue;
            LoadBillingData(searchPatient, paymentStatus);
        }

        protected void gvBilling_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int billId = Convert.ToInt32(e.CommandArgument);
                //Response.Redirect($"BillingDetails.aspx?billId={billId}");
                Session["billID"] = billId;
                Response.Redirect("SummoryReport.aspx");
            }
        }
    }
}