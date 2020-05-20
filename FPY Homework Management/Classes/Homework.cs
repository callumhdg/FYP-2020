using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management.Classes
{
    public class Homework
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        public string coreHWID { get; set; }
        public string lastEditBy { get; set; }
        public string timeToComplete { get; set; }
        public string hwTitle { get; set; }
               

        public Homework(string id, string lastEdit, string timeToFin, string title)
        {
            coreHWID = id;
            lastEditBy = lastEdit;
            timeToComplete = timeToFin;
            hwTitle = title;
        }

        public Homework()
        {
        }


        public ArrayList readAllCoreHomework()
        {
            ArrayList allCoreHomework = new ArrayList();
            string query = "SELECT * from CoreHomework";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Homework hw = new Homework(re["CoreHomeworkID"].ToString(), re["LastEditBy"].ToString(), re["MinutesToComplete"].ToString(), re["HomeworkTitle"].ToString());
                allCoreHomework.Add(hw);
            }

            conn.Close();
            return allCoreHomework;
        }


        public Homework readSingleCoreHomework(string id)
        {
            string query = "SELECT * from CoreHomework where CoreHomeworkID = '" + id + "'";
            Homework selectedCoreHomework = new Homework();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedCoreHomework = new Homework(re["CoreHomeworkID"].ToString(), re["LastEditBy"].ToString(), re["MinutesToComplete"].ToString(), re["HomeworkTitle"].ToString());
            }

            conn.Close();
            return selectedCoreHomework;
        }


        public void createCoreHomework()
        {
            string query = "INSERT into CoreHomework (CoreHomeworkID, LastEditBy, MinutesToComplete, HomeworkTitle) VALUES (@CoreHomeworkID, @LastEditBy, @MinutesToComplete, @HomeworkTitle)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@CoreHomeworkID", this.coreHWID);
            cmd.Parameters.AddWithValue("@LastEditBy", this.lastEditBy);
            cmd.Parameters.AddWithValue("@MinutesToComplete", this.timeToComplete);
            cmd.Parameters.AddWithValue("@HomeworkTitle", this.hwTitle);

            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public void updateCoreHomework(string id, string teacherID, string timeToFin, string title)
        {
            string query = "UPDATE CoreHomework SET LastEditBy = '" + teacherID + "', MinutesToComplete = '" + timeToFin+ "', HomeworkTitle = '" + title + "' WHERE CoreHomeworkID = '" + id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }









    }
}