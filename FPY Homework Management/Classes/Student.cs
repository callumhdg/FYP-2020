﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management.Classes
{
    public class Student
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());


        public string studentID { get; set; }

        public string studentUsername { get; set; }

        public string studentPassword { get; set; }



        public Student(string sID, string sUsername, string sPassword)
        {
            studentID = sID;
            studentID = sUsername;
            studentID = sPassword;
        }

        public Student()
        {
        }



        public ArrayList readStudents()
        {
            ArrayList allStudents = new ArrayList();
            string query = "SELECT * from Students";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Student student = new Student(re["StudentID"].ToString(), re["StudentUsername"].ToString(), re["StudentPassword"].ToString());
                allStudents.Add(student);
            }
            conn.Close();
            return allStudents;
        }


        public Student readSingleStudent(string id)
        {
            string query = "SELECT * from Student where StudentID = @id";
            Student seclectedStudent = new Student();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                seclectedStudent = new Student(re["StudentID"].ToString(), re["StudentUsername"].ToString(), re["StudentPassword"].ToString());
            }

            conn.Close();
            return seclectedStudent;
        }




    }
}