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
    public partial class Student_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnLogin_Click(object sender, EventArgs ea)
        {
            ArrayList stu = new ArrayList();
            Student storedStudent = new Student();
            stu = storedStudent.readStudents();

            foreach(Student s in stu)
            {
                //if(txtUsername.Text.Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))
                //(txtUsername.Text.ToLower().Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))

                string input = txtUsername.Text.ToLower();
                if (input.Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))
                {
                    s.studentPassword = null; //clears password 
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