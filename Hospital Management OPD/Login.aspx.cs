using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_OPD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        GlobalSettings_DB main = new GlobalSettings_DB(); 


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            DataTable adminData = main.AuthenticateAdmin(username, password);

            if (adminData.Rows.Count > 0)
            {
                Session["AdminID"] = adminData.Rows[0]["admin_id"];
                Session["Username"] = adminData.Rows[0]["username"];
                Response.Redirect("~/"); 
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid username or password.";
            }
        }
    
    }
}