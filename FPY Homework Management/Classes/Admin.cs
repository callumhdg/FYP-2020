using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management.Classes
{
    public class Admin
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        public string adminID { get; set; }

        public string adminUsername { get; set; }

        public string adminPassword { get; set; }


        public Admin(string aID, string aUsername, string aPassword)
        {
            adminID = aID;
            adminUsername = aUsername;
            adminPassword = aPassword;
        }

        public Admin()
        {
        }


        public ArrayList readAdmins()
        {
            ArrayList allAdmins = new ArrayList();
            string query = "SELECT * from Admin";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Admin admin = new Admin(re["AdminID"].ToString(), re["AdminUsername"].ToString(), re["AdminPassword"].ToString());
                allAdmins.Add(admin);
            }

            conn.Close();
            return allAdmins;
        }


        public Admin readSingleAdmin(string id)
        {
            string query = "SELECT * from Admin where AdminID = @id";
            Admin selectedAdmin = new Admin();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedAdmin = new Admin(re["AdminID"].ToString(), re["AdminUsername"].ToString(), re["AdminPassword"].ToString());
            }

            conn.Close();
            return selectedAdmin;
        }













    }
}