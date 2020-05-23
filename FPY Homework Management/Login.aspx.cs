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
            notify.Visible = false;
        }


        protected void btnLogin_Click(object sender, EventArgs ea)
        {
            string userType = txtUsername.Text.ToLower();
            string userMarker = userType.Substring(0, 1);

            ArrayList userList = new ArrayList();

            if (userMarker == "s")
            {
                
                Student storedStudent = new Student();
                userList = storedStudent.readStudents();

                foreach (Student s in userList)
                {
                    //if(txtUsername.Text.Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))
                    //(txtUsername.Text.ToLower().Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))

                    string input = txtUsername.Text;//.ToLower();
                    //if (input.Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))
                    //if (txtUsername.Text.Equals(s.studentUsername) && txtPassword.Text.Equals(s.studentPassword))
                    if (txtUsername.Text.ToLower().Equals(s.studentUsername.ToLower()) && txtPassword.Text.Equals(s.studentPassword))
                    {
                        s.studentPassword = null; //clears password 
                        Session["user"] = s.studentUsername;
                        Response.Redirect("Student_Home.aspx"); //login sucsessul, redirecting to Student landing page
                        //txtNotify.Text = "login succsessfull"; //testing
                        
                        //Session["username"] = ;
                    }
                    else
                    {
                        notify.Visible = true;
                        txtNotify.Text = "Username or Password is incorrect, please try again";
                    }
                    s.studentPassword = null; //clears password 
                }


            }
            else if (userMarker == "t")
            {
                //ArrayList tea = new ArrayList();
                Teacher storedTeacher = new Teacher();
                userList = storedTeacher.readTeachers();

                foreach (Teacher t in userList)
                {

                    string input = txtUsername.Text;//.ToLower();
                    //if (input.Equals(t.teacherUsername) && txtPassword.Text.Equals(t.teacherPassword))
                    //if (txtUsername.Text.Equals(t.teacherUsername) && txtPassword.Text.Equals(t.teacherPassword))
                    if (txtUsername.Text.ToLower().Equals(t.teacherUsername.ToLower()) && txtPassword.Text.Equals(t.teacherPassword))
                    {
                        t.teacherPassword = null; //clears password 
                        Session["user"] = t.teacherUsername;
                        Response.Redirect("Teacher_Home.aspx"); //login sucsessul, redirecting to Teacher landing page
                        //txtNotify.Text = "login succsessfull"; //testing
                        
                    }
                    else
                    {
                        notify.Visible = true;
                        txtNotify.Text = "Username or Password is incorrect, please try again";
                    }
                }
            }
            else if (userMarker == "a")
            {                
                Admin storedAdmin = new Admin();
                userList = storedAdmin.readAdmins();

                foreach (Admin a in userList)
                {

                    //string input = txtUsername.Text;//.ToLower();
                    //if (txtUsername.Text.Equals(a.adminUsername) && txtPassword.Text.Equals(a.adminPassword))
                    if (txtUsername.Text.ToLower().Equals(a.adminUsername.ToLower()) && txtPassword.Text.Equals(a.adminPassword))
                    {
                        a.adminPassword = null; //clears password 
                        Session["user"] = a.adminUsername;
                        Response.Redirect("Admin_Home.aspx"); //login sucsessul, redirecting to Teacher landing page
                        //txtNotify.Text = "login succsessfull"; //testing
                        
                    }
                    else
                    {
                        notify.Visible = true;
                        txtNotify.Text = "Username or Password is incorrect, please try again";
                    }
                }
            }
            else
            {
                notify.Visible = true;
                txtNotify.Text = "Username or Password is incorrect, please try again";
            }







        }

    }
}