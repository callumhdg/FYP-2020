﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace FPY_Homework_Management.Classes
{
    public class IssuedHomework
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        public string IssuedHomeworkID { get; set; }
        public string CoreHomeworkID { get; set; }
        public string StudentID { get; set; } 
        public string SetByTeacherID { get; set; }
        public string TimeToComplete { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string TotalMarks { get; set; }

        public IssuedHomework(string issHWID, string coreHWID, string stuID, string issuingTeacherID, string timeToFin, DateTime dDate, DateTime subDate, string totMarks)
        {
            IssuedHomeworkID = issHWID;
            CoreHomeworkID = coreHWID;
            StudentID = stuID;
            SetByTeacherID = issuingTeacherID;
            TimeToComplete = timeToFin;
            DueDate = dDate;
            SubmissionDate = subDate;
            TotalMarks = totMarks;
        }

        public IssuedHomework(string issHWID, string coreHWID, string stuID, string issuingTeacherID, string timeToFin, DateTime dDate, DateTime subDate)
        {
            IssuedHomeworkID = issHWID;
            CoreHomeworkID = coreHWID;
            StudentID = stuID;
            SetByTeacherID = issuingTeacherID;
            TimeToComplete = timeToFin;
            DueDate = dDate;
            SubmissionDate = subDate;
        }

        public IssuedHomework(string issHWID, string coreHWID, string stuID, string issuingTeacherID, string timeToFin, DateTime dDate)
        {
            IssuedHomeworkID = issHWID;
            CoreHomeworkID = coreHWID;
            StudentID = stuID;
            SetByTeacherID = issuingTeacherID;
            TimeToComplete = timeToFin;
            DueDate = dDate;
        }


        public IssuedHomework(string coreHWID, string stuID, string issuingTeacherID, string timeToFin, DateTime dDate)
        {
            CoreHomeworkID = coreHWID;
            StudentID = stuID;
            SetByTeacherID = issuingTeacherID;
            TimeToComplete = timeToFin;
            DueDate = dDate;
        }

        public IssuedHomework(string issHWID)
        {
            IssuedHomeworkID = issHWID;
        }

        public IssuedHomework()
        { }



        public ArrayList readAllIssuedHomework()
        {
            ArrayList allIssuedHomework = new ArrayList();
            string query = "SELECT * from IssuedHomework";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                IssuedHomework issuedHomework = new IssuedHomework(re["IssuedHomeworkID"].ToString(), re["CoreHomeworkID"].ToString(), re["StudentID"].ToString(), re["SetByTeacherID"].ToString(), re["TimeToComplete"].ToString(), Convert.ToDateTime(re["DueDate"]), Convert.ToDateTime(re["SubmissionDate"]));
                allIssuedHomework.Add(issuedHomework);
            }
            conn.Close();
            return allIssuedHomework;
        }


        public ArrayList readAllNewIssuedHomework()
        {
            ArrayList allIssuedHomework = new ArrayList();
            string query = "SELECT IssuedHomeworkID from IssuedHomework";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                //IssuedHomework issuedHomework = new IssuedHomework(re["IssuedHomeworkID"].ToString());
                //allIssuedHomework.Add(issuedHomework);
                allIssuedHomework.Add((re["IssuedHomeworkID"].ToString()));
            }
            conn.Close();
            return allIssuedHomework;
        }


        public IssuedHomework readSelectedIssuedHomework(string id)
        {
            string query = "SELECT * from IssuedHomework WHERE IssuedHomeworkID = @id";
            IssuedHomework seclectedIssuedHomework = new IssuedHomework();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                seclectedIssuedHomework = new IssuedHomework(re["IssuedHomeworkID"].ToString(), re["CoreHomeworkID"].ToString(), re["StudentID"].ToString(), re["SetByTeacherID"].ToString(), re["TimeToComplete"].ToString(), Convert.ToDateTime(re["DueDate"]));
            }

            conn.Close();
            return seclectedIssuedHomework;
        }


        public IssuedHomework readSelectedIssuedHomeworkForMarking(string id)//if submission date is null this cant be read
        {
            string query = "SELECT * from IssuedHomework WHERE IssuedHomeworkID = @id";
            IssuedHomework seclectedIssuedHomework = new IssuedHomework();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                seclectedIssuedHomework = new IssuedHomework(re["IssuedHomeworkID"].ToString(), re["CoreHomeworkID"].ToString(), re["StudentID"].ToString(), re["SetByTeacherID"].ToString(), re["TimeToComplete"].ToString(), Convert.ToDateTime(re["DueDate"]), Convert.ToDateTime(re["SubmissionDate"]));
            }

            conn.Close();
            return seclectedIssuedHomework;
        }


        public void createIssuedHomework()
        {            
            string query = "INSERT into IssuedHomework (CoreHomeworkID, StudentID, SetByTeacherID, TimeToComplete, DueDate) VALUES (@CoreHomeworkID, @StudentID, @SetByTeacherID, @TimeToComplete, @DueDate)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("@IssuedHomeworkID", this.IssuedHomeworkID);
            cmd.Parameters.AddWithValue("@CoreHomeworkID", this.CoreHomeworkID);
            cmd.Parameters.AddWithValue("@StudentID", this.StudentID);
            cmd.Parameters.AddWithValue("@SetByTeacherID", this.SetByTeacherID);
            cmd.Parameters.AddWithValue("@TimeToComplete", this.TimeToComplete);
            cmd.Parameters.AddWithValue("@DueDate", this.DueDate);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void updateSubmittedHomework(string id)
        {
            //string query = "UPDATE IssuedHomework SET SubmissionDate = 'CURRENT_TIMESTAMP' WHERE IssuedHomeworkID = '" + id + "'";
            string curentTime = DateTime.Now.ToString("yyyy-MM-dd");
            string query = "UPDATE IssuedHomework SET SubmissionDate = '" + curentTime +"' WHERE IssuedHomeworkID = '" + id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd"));

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void updateMarkHomework(string id)
        {
            //string query = "UPDATE IssuedHomework SET Results = '" + results + "', Feedback = '" + feedback + "', Marked = '1' WHERE IssuedHomeworkID = '" + id + "'";
            string query = "UPDATE IssuedHomework SET Marked = '1' WHERE IssuedHomeworkID = '" + id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateHomeworkTotal(string id, string marks)
        {
            string query = "UPDATE IssuedHomework SET TotalMarks = '" + marks + "' WHERE IssuedHomeworkID = '" + id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public ArrayList selectAllIssuedHomeworkFromCore(string id)
        {
            ArrayList selectedIDs = new ArrayList();
            string query = "SELECT IssuedHomeworkID FROM IssuedHomework WHERE CoreHomeworkID = '" + id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                IssuedHomework thisIssHw = new IssuedHomework(re["IssuedHomeworkID"].ToString());
                selectedIDs.Add(thisIssHw.IssuedHomeworkID);
            }

            //cmd.ExecuteNonQuery();
            conn.Close();
            return selectedIDs;
        }

        public void deleteIssuedHomework(string id)
        {
            string query = "DELETE FROM IssuedHomework WHERE CoreHomeworkID = '" + id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();


        }



    }
}