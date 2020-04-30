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

        public QuestionToAnswer()
        { }






    }
}