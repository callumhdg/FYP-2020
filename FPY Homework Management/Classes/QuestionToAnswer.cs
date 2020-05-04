using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace FPY_Homework_Management.Classes
{
    public class QuestionToAnswer
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        public string QuestionToAnswerID { get; set; }
        public string IssuedHomeworkID { get; set; }
        //public int IssuedHomeworkID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionNumber { get; set; }
        public string MarksForQuestion { get; set; }
        public string Results { get; set; }
        public string Feedback { get; set; }


        public QuestionToAnswer(string qID, string parentHWID, string qText, string qNum, string qMarks, string res, string qFeedback)
        {
            QuestionToAnswerID = qID;
            IssuedHomeworkID = parentHWID;
            QuestionText = qText;
            QuestionNumber = qNum;
            MarksForQuestion = qMarks;
            Results = res;
            Feedback = qFeedback;
        }

        public QuestionToAnswer(string qID, string parentHWID, string qText, string qNum, string qMarks)
        {
            QuestionToAnswerID = qID;
            IssuedHomeworkID = parentHWID;
            QuestionText = qText;
            QuestionNumber = qNum;
            MarksForQuestion = qMarks;
        }

        public QuestionToAnswer(string parentHWID, string qText, string qNum, string qMarks)
        {
            IssuedHomeworkID = parentHWID;
            QuestionText = qText;
            QuestionNumber = qNum;
            MarksForQuestion = qMarks;
        }


        public QuestionToAnswer()
        { }


        public ArrayList readAllQuestionsToAnswer()
        {
            ArrayList allQTA = new ArrayList();
            string query = "SELECT * FROM QuestionsToAnswer";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                QuestionToAnswer qta = new QuestionToAnswer(re["QuestionToAnswerID"].ToString(), re["IssuedHomeworkID"].ToString(), re["QuestionText"].ToString(), re["QuestionNumber"].ToString(), re["MarksForQuestion"].ToString(), re["Results"].ToString(), re["Feedback"].ToString());
            }
            conn.Close();
            return allQTA;
        }


        public QuestionToAnswer readSelectedQuestionToAnswer(string id)
        {
            string query = "SELECT * FROM QuestionToAnswer WHERE QuestionToAnswerID = @id";
            QuestionToAnswer selectedQuestionToAnswer = new QuestionToAnswer();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedQuestionToAnswer = new QuestionToAnswer(re["QuestionToAnswerID"].ToString(), re["IssuedHomeworkID"].ToString(), re["QuestionText"].ToString(), re["QuestionNumber"].ToString(), re["MarksForQuestion"].ToString(), re["Results"].ToString(), re["Feedback"].ToString());
            }

            conn.Close();
            return selectedQuestionToAnswer;
        }


        public void createQuestionToAnswer()
        {
            string query = "INSERT into QuestionsToAnswer (IssuedHomeworkID, QuestionText, QuestionNumber, MarksForQuestion) VALUES (@IssuedHomeworkID, @QuestionText, @QuestionNumber, @MarksForQuestion)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@IssuedHomeworkID", this.IssuedHomeworkID);
            cmd.Parameters.AddWithValue("@QuestionText", this.QuestionText);
            cmd.Parameters.AddWithValue("@QuestionNumber", this.QuestionNumber);
            cmd.Parameters.AddWithValue("@MarksForQuestion", this.MarksForQuestion);

            cmd.ExecuteNonQuery();
            conn.Close();
        }









    }
}