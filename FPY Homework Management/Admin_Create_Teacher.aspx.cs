using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FPY_Homework_Management.Classes;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management
{
    public partial class Admin_Create_Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateTeacher_Click(object sender, EventArgs e)
        {

            string firstName = TeacherFirstNameIn.Text;
            string lastName = TeacherLastNameIn.Text;
            string fName = firstName.Substring(0, 1).ToUpper();
            string lName1 = lastName.Substring(0, 1).ToUpper();
            string lName2 = lastName.Substring(1, lastName.Length - 1).ToLower();

            string username = fName + lName1 + lName2;


            bool b = false;
            int c = 0;
            //if username already exists + 1
            //loop back to if

            while (b == false)
            {
                Teacher t = new Teacher();
                ArrayList tList = t.readTeachersUsernames();
                string selectedUsername = "";

                for (int i = 0; i < tList.Count; i++)
                {
                    selectedUsername = tList[i].ToString();

                    if (selectedUsername.Contains(username))
                    {
                        c++;
                    }
                    else if (!selectedUsername.Contains(username))
                    {
                    }

                }
                b = true;
            }

            if (c == 0)
            {
            }
            else
            {
                username = username + c.ToString();
            }


            string fn1 = TeacherFirstNameIn.Text;
            string finFirstName = fn1.Substring(0,1).ToUpper() + fn1.Substring(1, fn1.Length - 1).ToLower();

            string fn2 = TeacherLastNameIn.Text;
            string finLastName = fn2.Substring(0,1).ToUpper() + fn2.Substring(1, fn2.Length - 1).ToLower(); 

            Teacher teacher = new Teacher(finFirstName, finLastName, ("t" + username), TeacherPasswordIn.Text);
            teacher.createTeacher();

            clearInputs();
        }


        public void clearInputs()
        {
            TeacherFirstNameIn.Text = "";
            TeacherLastNameIn.Text = "";
            TeacherPasswordIn.Text = "";


        }



        //public void createTeacherUsername()
        //{
        //    string firstName = TeacherFirstNameIn.Text;
        //    string lastName = TeacherLastNameIn.Text;
        //    string fName = firstName.Substring(0, 1).ToUpper();
        //    string lName1 = lastName.Substring(0, 1).ToUpper();
        //    string lName2 = lastName.Substring(1, 20).ToLower();

        //    string username = fName + lName1 + lName2;


        //    bool b = false;
        //    int c = 0;
        //    //if username already exists + 1
        //    //loop back to if

        //    while (b == false)
        //    {
        //        Teacher t = new Teacher();
        //        ArrayList tList = t.readTeachersUsernames();
        //        string selectedUsername = "";

        //        for (int i = 0; i < tList.Count; i++)
        //        {
        //            selectedUsername = tList[i].ToString();

        //            if (selectedUsername.Contains(username))
        //            {
        //                c++;
        //            }
        //            else if (!selectedUsername.Contains(username))
        //            {
        //            }                    

        //        }
        //        b = true;
        //    }

        //    if (c == 0)
        //    {                
        //    }
        //    else
        //    {
        //        username = username + c.ToString();
        //    }

        //}

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }

    }
}