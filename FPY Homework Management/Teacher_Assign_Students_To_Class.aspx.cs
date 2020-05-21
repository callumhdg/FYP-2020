using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FPY_Homework_Management.Classes;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace FPY_Homework_Management
{
    public partial class Teacher_Assign_Students_To_Class : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());
        string selectedClass = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { }

            allStudentsInClass.Visible = false;
            allOtherStudents.Visible = false;
        }

        public void populateInClassTable()
        {

            ArrayList arrStudentsInClass = SelectAllStudentsInAClass();

            if (arrStudentsInClass.Count != 0) {
                string inClassQuery = "SELECT StudentID, StudentUsername, StudentFirstName, StudentLastName, StudentDOB FROM Students WHERE ";
                for (int i = 0; i < arrStudentsInClass.Count; i++)
                {
                    inClassQuery = inClassQuery + "StudentID = " + arrStudentsInClass[i].ToString();
                    if (i != (arrStudentsInClass.Count - 1))
                    {
                        inClassQuery = inClassQuery + " OR ";
                    }
                }
                inClassQuery = inClassQuery + ";";
                ViewAllStudentsInClass.SelectCommand = inClassQuery;
                allStudentsInClass.Visible = true;
            }
            else
            {
                allStudentsInClass.Visible = false;
            }
        }


        public void populateNotInClassTable()
        {
            //allOtherStudents.DataBind();

            ArrayList arrStudentsNotInClass = selectStudentsNotInClass();

            if (arrStudentsNotInClass.Count != 0) {
                string inClassQuery = "SELECT StudentID, StudentUsername, StudentFirstName, StudentLastName, StudentDOB FROM Students WHERE ";
                for (int i = 0; i < arrStudentsNotInClass.Count; i++)
                {
                    //inClassQuery = inClassQuery + "WHERE StudentID = '" + arrStudentsNotInClass[i].ToString() + "'";
                    inClassQuery = inClassQuery + "StudentID = '" + arrStudentsNotInClass[i].ToString() + "'";
                    if (i != (arrStudentsNotInClass.Count - 1))
                    {
                        inClassQuery = inClassQuery + " OR ";
                    }
                }
                inClassQuery = inClassQuery + ";";
                ViewAllStudentsNotInClass.SelectCommand = inClassQuery;
                allOtherStudents.Visible = true;
            }
            else
            {
                allOtherStudents.Visible = false;
            }

        }



        //public ArrayList selectStudentsInClass() //fix this
        //{
        //    ArrayList arrAllInClass = new ArrayList();
        //    //string query = "SELECT StudentsInClassID, StudentID, ClassID FROM StudentsInClass WHERE ClassID = @ClassID";
        //    //string query = "SELECT StudentID FROM StudentsInClass WHERE ClassID = @ClassID";
        //    //string query = "SELECT StudentID FROM StudentsInClass WHERE ClassID = 1";
        //    //string query = "SELECT StudentID FROM StudentsInClass WHERE ClassID = " + selectedClass;
        //    //conn.Open();
        //    //SqlCommand cmd = new SqlCommand(query, conn);

        //    //cmd.Parameters.AddWithValue("@ClassID", drpSelectClass.DataValueField);

        //    //SqlDataReader re = cmd.ExecuteReader();

        //    //if (arrAllInClass.Count != 0)
        //    //    try
        //    //    {
        //    //        while (re.Read())
        //    //        {
        //    //            StudentsInClass stu = new StudentsInClass(re["StudentsInClassID"].ToString(), re["StudentID"].ToString(), re["ClassID"].ToString());
        //    //            arrAllInClass.Add(stu);
        //    //            allOtherStudents.Visible = true;
        //    //        }
        //    //    }
        //    //    catch
        //    //    {
        //    //        //no students in this class yet
        //    //        allOtherStudents.Visible = false;
        //    //    }

        //    //    //cmd.ExecuteNonQuery();                        
        //    //    conn.Close();

        //    Student student = new Student();
        //    ArrayList allStu = student.readAllStudentIDs();
        //    ArrayList allStuInClass = SelectAllStudentsInAClass();

        //    for (int i = 0; i < allStu.Count; i++)
        //    {
        //        for (int s = 0; s < allStuInClass.Count; s++)
        //        {
        //            if (allStu[i].ToString() == allStuInClass[s].ToString())
        //            {
        //                allStu.RemoveAt(i);
        //            }
        //        }
        //    }






        //    return arrAllInClass;
        //}



        public ArrayList selectStudentsNotInClass()
        {
            ArrayList arrAllNotInClass = new ArrayList();
            Student student = new Student();
            ArrayList allStu = student.readAllStudentIDs();
            ArrayList allStuInClass = SelectAllStudentsInAClass();

            for (int i = 0; i < allStu.Count; i++)
            {
                for (int s = 0; s < allStuInClass.Count; s++)
                {
                    if (allStu[i].ToString() == allStuInClass[s].ToString())
                    {
                        allStu.RemoveAt(i);
                    }
                }
            }

            for (int a = 0; a < allStu.Count; a++)
            {
                arrAllNotInClass.Add(allStu[a]);
            }

            return arrAllNotInClass;
        }


        public ArrayList SelectAllStudentsInAClass()
        {
            selectedClass = drpSelectClass.SelectedValue.ToString();
            string query = "SELECT StudentID FROM StudentsInClass WHERE ClassID = " + selectedClass;
            ArrayList allStudentsInThisClass = new ArrayList();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            try
            {
                while (re.Read())
                {
                    allStudentsInThisClass.Add(re["StudentID"].ToString());
                }
            }
            catch
            { }

            conn.Close();
            return allStudentsInThisClass;
        }


        protected void btnSelectClass_Click(object sender, EventArgs e)
        {
            selectedClass = drpSelectClass.SelectedValue.ToString();

            populateInClassTable();
            populateNotInClassTable();



        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            selectedClass = drpSelectClass.SelectedValue.ToString();

            Button btnAdd = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnAdd.NamingContainer;
            string selectedID = selectedRow.Cells[0].Text;

            StudentsInClass newListing = new StudentsInClass(selectedClass, selectedID);
            newListing.createStudentClassListing();

            populateInClassTable();
            populateNotInClassTable();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            selectedClass = drpSelectClass.SelectedValue.ToString();

            Button btnRemove = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnRemove.NamingContainer;
            string selectedID = selectedRow.Cells[0].Text;

            StudentsInClass removedStudent = new StudentsInClass();
            removedStudent.removeStudentFromClass(selectedID);

            populateInClassTable();
            populateNotInClassTable();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }


    }
}