using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management.Classes
{
    public class Utility
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        string utilityID { get; set; }
        string allCoreHomeworkCount { get; set; }


        public Utility(string utilID, string hwCount)
        {
            utilityID = utilID;
            allCoreHomeworkCount = hwCount;
        }

        public Utility()
        {
        }


        public string readCurrentCoreHomeworkCount()
        {
            string hwCount = "";
            string query = "SELECT AllCoreHomeworkCount FROM Utilities WHERE UtilityID = '1'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                hwCount = re["AllCoreHomeworkCount"].ToString();
            }

            conn.Close();
            return hwCount;
        }


        public void addCoreHomework()
        {
            Utility utility = new Utility();
            int currentCount = Convert.ToInt32(utility.readCurrentCoreHomeworkCount());
            currentCount++;

            string query = "UPDATE Utilities SET AllCoreHomeworkCount = '" + currentCount + "' WHERE UtilityID = '1'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }



    }
}