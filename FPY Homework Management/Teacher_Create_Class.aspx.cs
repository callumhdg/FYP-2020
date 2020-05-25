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
    public partial class Teacher_Create_Class : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { }

            lblErrorMessage.Visible = false;
            divErrorMessage.Visible = false;
            lblSuccessMessage.Visible = false;
            divSuccessMessage.Visible = false;
        }

        protected void btnCreateClass_Click(object sender, EventArgs e)
        {
            string teachID = drpSelectTeacher.Text;
            string clsSubj = classSubjectIn.Text;
            string clsYea = classYearGroupIn.Text;
            //string clsName = clsSubj.Substring(0, 3).ToUpper() + clsYea;
            
            bool validate = false;
            validate = inputChecker(validate);


            if (validate == true)
            {

                string clsSubject = clsSubj.Substring(0, 1).ToUpper() + clsSubj.Substring(1, clsSubj.Length - 1).ToLower();

                //year will always be 2 chars
                if (clsYea.Length == 1)
                {
                    clsYea = "0" + clsYea;
                }

                Teacher teach = new Teacher();
                teach = teach.readSingleTeacher(teachID);
                string tInitials = teach.teacherFirstname.Substring(0, 1).ToUpper() + teach.teacherLastname.Substring(0, 1).ToUpper();
                string className = clsSubj.Substring(0, 3).ToUpper() + clsYea + tInitials;

                //if class name exists + 1
                string cName = checkUniqueName(className);
                                 
                SchoolClass cls = new SchoolClass(teachID, clsSubject, clsYea, cName);
                cls.createSchoolClass();


                clearInputs();
                lblErrorMessage.Visible = false;
                divErrorMessage.Visible = false;
                lblSuccessMessage.Visible = true;
                divSuccessMessage.Visible = true;
            }
            else
            {

                lblErrorMessage.Visible = true;
                divErrorMessage.Visible = true;
                lblSuccessMessage.Visible = false;
                divSuccessMessage.Visible = false;

            }

        }


        private string checkUniqueName(string name)
        {
            SchoolClass c = new SchoolClass();
            ArrayList allClassNames = c.readClassNames();
            string nameOut = name;

            for (int i = 0; i < allClassNames.Count; i++)
            {
                string testName = allClassNames[i].ToString();
                if (name.Length != 7)//default name length will always be 7, if longer then there are dupelicates
                {
                    string indicator = name.Substring(name.Length - 1, 1);
                    int endNum = Convert.ToInt32(indicator);
                    endNum = endNum + 1;

                    nameOut = name.Substring(0, 7) + endNum.ToString();
                }
                else if (name == testName)
                {
                    name = name + "1";
                    checkUniqueName(name);
                }

            }
            
            return nameOut;
        }//end of Check


        protected void clearInputs()
        {
            classSubjectIn.Text = "";
            classYearGroupIn.Text = "";
        }
        
        private bool inputChecker(bool validate)
        {
            if (classSubjectIn.Text != "" && classYearGroupIn.Text != "")
            {
                validate = true;
            }
            else
            {
                validate = false;
            }

            return validate;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }


    }
}