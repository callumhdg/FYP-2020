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
    public partial class Admin_Create_Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateStudent_Click(object sender, EventArgs e)
        {

            string firstName = StudentFirstNameIn.Text;
            string lastName = StudentLastNameIn.Text;
            string fName = firstName.Substring(0, 1).ToUpper();
            string lName1 = lastName.Substring(0, 1).ToUpper();
            string lName2 = lastName.Substring(1, lastName.Length - 1).ToLower();

            string username = fName + lName1 + lName2;


            bool b = false;
            int c = 0;

            while (b == false)
            {
                Student s = new Student();
                ArrayList tList = s.readStudentUsernames();
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


            string fn1 = StudentFirstNameIn.Text;
            string finFirstName = fn1.Substring(0, 1).ToUpper() + fn1.Substring(1, fn1.Length - 1).ToLower();

            string fn2 = StudentLastNameIn.Text;
            string finLastName = fn2.Substring(0, 1).ToUpper() + fn2.Substring(1, fn2.Length - 1).ToLower();

            string parEmail = "";
            if (StudentParEmailIn.Text != "")
            {
                parEmail = StudentParEmailIn.Text;
            }
            else { }
                                




            //Student student = new Student(finFirstName, finLastName, username, StudentPasswordIn.Text, parEmail, StudentDateOfBirth.Text);
            //student.createStudent();

            clearInputs();
        }





        public void clearInputs()
        {
            StudentFirstNameIn.Text = "";
            StudentLastNameIn.Text = "";
            StudentPasswordIn.Text = "";
            StudentParEmailIn.Text = "";
        }





    }
}