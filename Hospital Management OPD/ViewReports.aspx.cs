using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace Hospital_Management_OPD
{
    public partial class ViewReports : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                
                ConfigureReportViewer("1"); // Default patient_id as 1
            }
        }
        
        
        private void ConfigureReportViewer(string patientId)
        {   
            
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;

            ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://life-ho-it-11:81/reportserver/");


            ReportViewer1.ServerReport.ReportPath = "/MyReports/PatientReport"; 

            
            ReportParameter[] reportParameters = new ReportParameter[1];
            reportParameters[0] = new ReportParameter("Patient_ID", patientId); 
            ReportViewer1.ServerReport.SetParameters(reportParameters);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        

            
            ReportViewer1.ServerReport.Refresh();
        }

        
        protected void btnLoadReport_Click(object sender, EventArgs e)
        {
           
            string patientId = txtPatientID.Text.Trim();

            if (!string.IsNullOrEmpty(patientId))
            {

                ConfigureReportViewer(patientId);
            }
            else
            {
                
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a valid Patient ID.');", true);
            }
        }

    }
}

