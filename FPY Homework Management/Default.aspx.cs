using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FPY_Homework_Management
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void StudentLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student_Login.aspx");
        }

        protected void TeacherLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Teacher_Login.aspx");
        }
    }
}