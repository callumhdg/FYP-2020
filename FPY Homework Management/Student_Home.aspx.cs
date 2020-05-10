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
            listPreviousHomework.SelectCommand = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND DueDate < CURRENT_TIMESTAMP";
            
            
            //listPreviousHomework.SelectCommand = "SELECT * FROM IssuedHomework WHERE StudentID = " + userID + " AND Marked = 1";
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



    }
}