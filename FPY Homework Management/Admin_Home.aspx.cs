using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FPY_Homework_Management
{
    public partial class Admin_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }
    }
}