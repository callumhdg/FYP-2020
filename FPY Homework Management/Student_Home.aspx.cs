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
    public partial class Student_Home : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());
        string username, userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["user"].ToString();
            userID = findStudentID();


            listCurrentHomework.SelectCommand = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND DueDate > CURRENT_TIMESTAMP";
            //listCurrentHomework.SelectCommand = "SELECT * FROM IssuedHomework WHERE StudentID = " + username + " AND DueDate > (CURDATE(), INTERVAL 1 DAY)";
            //listPreviousHomework.SelectCommand = "SELECT * FROM IssuedHomework WHERE StudentID = " + username + " AND DueDate < (CURDATE(), INTERVAL 1 DAY)";
            listOverdueHomework.SelectCommand = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND DueDate < CURRENT_TIMESTAMP AND SubmissionDate = NULL";

            listMarkedHomework.SelectCommand = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND Marked = '1'";


            activeHomework.Visible = false;
            overdueHomework.Visible = false;
            markedHomework.Visible = false;

            //if grid != empty visible = true
            displayActive();
            displayOverdue();
            displayMarked();
            
        }


        protected void btnSelectDueHomework_Click(object sender, EventArgs e)
        {
            //have id hidden and make it visable here
            Button btnSelectDueHomework = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnSelectDueHomework.NamingContainer;
            string selectedID = selectedRow.Cells[0].Text;
            Session["SelectedHomework"] = selectedID;


            Response.Redirect("Student_View_Homework.aspx");

            //Button btnRemove = (Button)sender;
            //GridViewRow selectedRow = (GridViewRow)btnRemove.NamingContainer;
            //string selectedID = selectedRow.Cells[0].Text;
        }


        protected void btnSelectOldHomework_Click(object sender, EventArgs e)
        {
            Button btnHomework = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnHomework.NamingContainer;
            string selectedID = selectedRow.Cells[0].Text;
            Session["SelectedHomework"] = selectedID;

            Response.Redirect("Student_View_Homework.aspx");
                                                         
        }

        protected void btnViewMarkedHomework_Click(object sender, EventArgs e)
        {
            Button btnHomework = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnHomework.NamingContainer;
            string selectedID = selectedRow.Cells[0].Text;
            Session["SelectedHomework"] = selectedID;

            Response.Redirect("Student_View_Marked_Homework.aspx");


        }

        protected string findStudentID()
        {

            string query = "SELECT StudentID from Students where StudentUsername = '" + username + "'";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();
            string id = "";

            while (re.Read())
            {                
                id = re["StudentID"].ToString();
            }

            conn.Close();
            return id;
        }


        protected void displayGridviews()
        {

            //string queryCurentHomework = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND DueDate > CURRENT_TIMESTAMP";
            //string queryOverdueHomework = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND DueDate < CURRENT_TIMESTAMP AND SubmissionDate = NULL";
            //string queryMarkedHomework = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND Marked = '1'";

            //IssuedHomework homework1 = new IssuedHomework();
            //IssuedHomework homework2 = new IssuedHomework();
            //IssuedHomework homework3 = new IssuedHomework();
            //ArrayList queryCount = new ArrayList();
            //conn.Open();

            //SqlCommand cmd1 = new SqlCommand(queryCurentHomework, conn);
            //SqlDataReader re1 = cmd1.ExecuteReader();

            //while (re1.Read())
            //{
            //    homework1 = new IssuedHomework(re1["IssuedHomeworkID"].ToString());
            //    queryCount.Add(homework1);
            //}

            //if (queryCount.Count != 0)
            //{
            //    activeHomework.Visible = true;
            //}
            //else
            //{
            //    activeHomework.Visible = false;
            //}

            //queryCount.Clear();
            //conn.Close();
            //conn.Dispose();

            //conn.Open();
            //SqlCommand cmd2 = new SqlCommand(queryOverdueHomework, conn);
            //SqlDataReader re2 = cmd2.ExecuteReader();

            //while (re2.Read())
            //{
            //    homework2 = new IssuedHomework(re2["IssuedHomeworkID"].ToString());
            //    queryCount.Add(homework2);
            //}

            //if (queryCount.Count != 0)
            //{
            //    overdueHomework.Visible = true;
            //}
            //else
            //{
            //    overdueHomework.Visible = false;
            //}

            //queryCount.Clear();
            //conn.Close();
            //conn.Dispose();

            //conn.Open();
            //SqlCommand cmd3 = new SqlCommand(queryMarkedHomework, conn);
            //SqlDataReader re3 = cmd3.ExecuteReader();

            //while (re3.Read())
            //{
            //    homework3 = new IssuedHomework(re3["IssuedHomeworkID"].ToString());
            //    queryCount.Add(homework3);
            //}

            //if (queryCount.Count != 0)
            //{
            //    markedHomework.Visible = true;
            //}
            //else
            //{
            //    markedHomework.Visible = false;
            //}

            //queryCount.Clear();

            //conn.Close();
            
            
        }



        private void displayActive()
        {
            string query = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND DueDate > CURRENT_TIMESTAMP";

            ArrayList queryCount = new ArrayList();
            IssuedHomework homework = new IssuedHomework();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                homework = new IssuedHomework(re["IssuedHomeworkID"].ToString());
                queryCount.Add(homework);
            }

            if (queryCount.Count != 0)
            {
                activeHomework.Visible = true;
            }
            else
            {
                activeHomework.Visible = false;
            }
                        
            conn.Close();

        }



        private void displayOverdue()
        {
            string query = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND DueDate < CURRENT_TIMESTAMP AND SubmissionDate = NULL";

            ArrayList queryCount = new ArrayList();
            IssuedHomework homework = new IssuedHomework();
            conn.Open();
            
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                homework = new IssuedHomework(re["IssuedHomeworkID"].ToString());
                queryCount.Add(homework);
            }

            if (queryCount.Count != 0)
            {
                overdueHomework.Visible = true;
            }
            else
            {
                overdueHomework.Visible = false;
            }
                        
            conn.Close();
            

        }



        private void displayMarked()
        {
            string query = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND Marked = '1'";

            ArrayList queryCount = new ArrayList();
            IssuedHomework homework = new IssuedHomework();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                homework = new IssuedHomework(re["IssuedHomeworkID"].ToString());
                queryCount.Add(homework);
            }

            if (queryCount.Count != 0)
            {
                markedHomework.Visible = true;
            }
            else
            {
                markedHomework.Visible = false;
            }

            conn.Close();

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session["SelectedHomework"] = null;

            Response.Redirect("Student_Home.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }

    }
}