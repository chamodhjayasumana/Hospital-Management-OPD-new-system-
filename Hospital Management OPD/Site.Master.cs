using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFooterContent();
                if (Session["Username"] == null || string.IsNullOrEmpty(Session["Username"].ToString()))
                {
                    Response.Redirect("Login.aspx");
                }

            }

        }

        private void LoadFooterContent()
        {
            GlobalSettings_DB main = new GlobalSettings_DB(); 
            DataTable dtSettings = main.GetGlobalSettings();

            string footerContent = "";
            foreach (DataRow row in dtSettings.Rows)
            {
                footerContent += $"{row["setting_key"].ToString().Replace('_', ' ')}: {row["setting_value"]}<br />";
            }

            litFooterContent.Text = footerContent;
        }


    }
}