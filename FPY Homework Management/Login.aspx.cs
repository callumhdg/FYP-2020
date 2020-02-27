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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnLogin_Click(object sender, EventArgs ea)
        {
            string userType = txtUsername.Text.ToLower();
            string userMarker = userType.Substring(0, 1);

            if (userMarker == "s")
            { 
            ArrayList stu = new ArrayList();
            Student storedStudent = new Student();
            stu = storedStudent.readStudents();

                foreach (Student s in stu)
                {
                //if(txtUsername.Text.Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))
                //(txtUsername.Text.ToLower().Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))

                    string input = txtUsername.Text.ToLower();
                    if (input.Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))
                    {
                        s.studentPassword = null; //clears password 
                        Response.Redirect("Student_Home.aspx"); //login sucsessul, redirecting to Student landing page
                        //txtNotify.Text = "login succsessfull"; //testing
                    }
                    else
                    {
                        txtNotify.Text = "Username or Password is incorrect, please try again";
                    }
                }


            }
            else if (userMarker == "t")
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
                        Response.Redirect("Teacher_Home.aspx"); //login sucsessul, redirecting to Teacher landing page
                        //txtNotify.Text = "login succsessfull"; //testing
                    }
                    else
                    {
                        txtNotify.Text = "Username or Password is incorrect, please try again";
                    }
                }
            }
            else
            {
                txtNotify.Text = "Username or Password is incorrect, please try again";
            }









    }
}