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
        public string Answer { get; set; }
        public string Results { get; set; }
        public string Feedback { get; set; }


        public QuestionToAnswer(string qID, string parentHWID, string qText, string qNum, string qMarks, string ans, string res, string qFeedback)
        {
            QuestionToAnswerID = qID;
            IssuedHomeworkID = parentHWID;
            QuestionText = qText;
            QuestionNumber = qNum;
            MarksForQuestion = qMarks;
            Answer = ans;
            Results = res;
            Feedback = qFeedback;
        }

        public QuestionToAnswer(string qID, string parentHWID, string qText,  string qNum, string qMarks, string ans)
        {
            QuestionToAnswerID = qID;
            IssuedHomeworkID = parentHWID;
            QuestionText = qText;
            QuestionNumber = qNum;
            MarksForQuestion = qMarks;
            Answer = ans;
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
                QuestionToAnswer qta = new QuestionToAnswer(re["QuestionToAnswerID"].ToString(), re["IssuedHomeworkID"].ToString(), re["QuestionText"].ToString(), re["QuestionNumber"].ToString(), re["MarksForQuestion"].ToString(), re["Answer"].ToString(), re["Results"].ToString(), re["Feedback"].ToString());
                allQTA.Add(qta);
            }
            conn.Close();
            return allQTA;
        }


        public ArrayList readSelectedQuestionInHomework(string id)
        {
            string query = "SELECT * FROM QuestionsToAnswer WHERE IssuedHomeworkID = @id";
            ArrayList selectedQuestionToAnswer = new ArrayList();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                QuestionToAnswer thisQuestion = new QuestionToAnswer(re["QuestionToAnswerID"].ToString(), re["IssuedHomeworkID"].ToString(), re["QuestionText"].ToString(), re["QuestionNumber"].ToString(), re["MarksForQuestion"].ToString());
                selectedQuestionToAnswer.Add(thisQuestion);
            }

            conn.Close();
            return selectedQuestionToAnswer;
        }


        public QuestionToAnswer readQuestionsInOrder(string id, string num)
        {
            string query = "SELECT * FROM QuestionsToAnswer WHERE IssuedHomeworkID = @id AND QuestionNumber = @num";
            QuestionToAnswer selectedQuestionToAnswer = new QuestionToAnswer();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@num", num);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedQuestionToAnswer = new QuestionToAnswer(re["QuestionToAnswerID"].ToString(), re["IssuedHomeworkID"].ToString(), re["QuestionText"].ToString(), re["QuestionNumber"].ToString(), re["MarksForQuestion"].ToString());
            }

            conn.Close();
            return selectedQuestionToAnswer;
        }

        public string getAnswer(string id)
        {
            string query = "SELECT Answer From QuestionsToAnswer WHERE QuestionToAnswerID = " + id;
            string answer = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                answer = re["Answer"].ToString();
            }

            conn.Close();
            return answer;
        }
        
        public string readAvailableMarks(string id, string qNum)
        {
            string query = "SELECT MarksForQuestion From QuestionsToAnswer WHERE IssuedHomeworkID = '" + id + "' AND QuestionNumber = '" + qNum +"'";
            string marks = "";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                marks = re["MarksForQuestion"].ToString();
            }

            conn.Close();
            return marks;
        }


        public QuestionToAnswer readMarkedQuestion(string id, string qNum)
        {
            string query = "SELECT * FROM QuestionsToAnswer WHERE IssuedHomeworkID = " + id + " AND QuestionNumber = " + qNum;
            QuestionToAnswer selectedQuestionToAnswer = new QuestionToAnswer();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedQuestionToAnswer = new QuestionToAnswer(re["QuestionToAnswerID"].ToString(), re["IssuedHomeworkID"].ToString(), re["QuestionText"].ToString(), re["QuestionNumber"].ToString(), re["MarksForQuestion"].ToString(), re["Answer"].ToString(), re["Results"].ToString(), re["Feedback"].ToString());
            }

            conn.Close();
            return selectedQuestionToAnswer;
        }


        public QuestionToAnswer readSelectedQuestionToAnswer(string id)
        {
            string query = "SELECT * FROM QuestionsToAnswer WHERE QuestionToAnswerID = @id";
            QuestionToAnswer selectedQuestionToAnswer = new QuestionToAnswer();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedQuestionToAnswer = new QuestionToAnswer(re["QuestionToAnswerID"].ToString(), re["IssuedHomeworkID"].ToString(), re["QuestionText"].ToString(), re["QuestionNumber"].ToString(), re["MarksForQuestion"].ToString(), re["Answer"].ToString(), re["Results"].ToString(), re["Feedback"].ToString());
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

        public void updateAnsweredQuestion(string newAnswer, string parentID, string qNum)
        {
            string query = "UPDATE QuestionsToAnswer SET Answer = '" + newAnswer + "' WHERE IssuedHomeworkID = '" + parentID + "' AND QuestionNumber = '" + qNum + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();

        }


        public void updateGradedQuestion(string results, string feedback, string parentID, string qNum)
        {
            string query = "UPDATE QuestionsToAnswer SET Results = '" + results + "', Feedback = '" + feedback + "' WHERE IssuedHomeworkID = '" + parentID + "' AND QuestionNumber = '" + qNum + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void deleteIssuedQuestions(string id)
        {
            string query = "DELETE FROM QuestionsToAnswer WHERE IssuedHomeworkID = '" + id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();


        }

    }
}