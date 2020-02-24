using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FPY_Homework_Management.Classes;
using System.Data.SqlClient;
using System.Net.Mail;

namespace FPY_Homework_Management
{
    public partial class Teacher_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }



        protected void btnLogin_Click(object sender, EventArgs ea)
        {
            ArrayList tea = new ArrayList();
            Teacher storedTeacher = new Teacher();
            tea = storedTeacher.readTeachers();

            foreach (Teacher t in tea)
            {

                string input = txtUsername.Text.ToLower();
                if (input.Equals(t.teacherUsername) && txtPassword.Text.Equals(t.teacherPassword))
                {
                    t.teacherPassword = null; //clears password 
                    Response.Redirect(""); //login sucsessul, redirecting to 
                }
                else
                {
                    txtNotify.Text = "Username or Password is incorrect, please try again";
                }
            }
        }




    }
}