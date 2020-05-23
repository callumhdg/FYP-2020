using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management.Classes
{
    public class Question
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        public string coreQuestionID { get; set; }
        public string fkCoreHWID { get; set; }
        public string questionNumber { get; set; }
        public string questionText { get; set; }
        public string maxMarksForQuestion { get; set; }


        public Question(string qID, string hwID, string qNum, string qText, string marks)
        {
            coreQuestionID = qID;
            fkCoreHWID = hwID;
            questionNumber = qNum;
            questionText = qText;
            maxMarksForQuestion = marks;
        }

        public Question(string hwID, string qNum, string qText, string marks)
        {
            fkCoreHWID = hwID;
            questionNumber = qNum;
            questionText = qText;
            maxMarksForQuestion = marks;
        }

        public Question()
        {
        }


        public ArrayList readAllCoreQuestions()
        {
            ArrayList allCoreQuestions = new ArrayList();
            string query = "SELECT * from CoreQuestions";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Question q = new Question(re["CoreQuestionID"].ToString(), re["CoreHomeworkParent"].ToString(), re["QuestionNumber"].ToString(), re["QuestionToAnswer"].ToString(), re["MaximumMarksForQuestion"].ToString());
                allCoreQuestions.Add(q);
            }

            conn.Close();
            return allCoreQuestions;
        }


        public Question readSingleCoreQuestion(string id)
        {
            string query = "SELECT * from CoreQuestions where CoreQuestionID = @id";
            Question selectedQuestion = new Question();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedQuestion = new Question(re["CoreQuestionID"].ToString(), re["CoreHomeworkParent"].ToString(), re["QuestionNumber"].ToString(), re["QuestionToAnswer"].ToString(), re["MaximumMarksForQuestion"].ToString());
            }

            conn.Close();
            return selectedQuestion;
        }


        public void createCoreQuestion()
        {
            string query = "INSERT into CoreQuestions (CoreHomeworkParent, QuestionNumber, QuestionToAnswer, MaximumMarksForQuestion) VALUES (@CoreHomeworkParent, @QuestionNumber, @QuestionToAnswer, @MaximumMarksForQuestion)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@CoreHomeworkParent", this.fkCoreHWID);
            cmd.Parameters.AddWithValue("@QuestionNumber", this.questionNumber);
            cmd.Parameters.AddWithValue("@QuestionToAnswer", this.questionText);
            cmd.Parameters.AddWithValue("@MaximumMarksForQuestion", this.maxMarksForQuestion);

            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public ArrayList readSelectedQuestionInHomework(string id)
        {
            string query = "SELECT * FROM CoreQuestions WHERE CoreHomeworkParent = '" + id + "'";
            ArrayList selectedQuestionToAnswer = new ArrayList();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Question thisQuestion = new Question(re["CoreQuestionID"].ToString(), re["CoreHomeworkParent"].ToString(), re["QuestionNumber"].ToString(), re["QuestionToAnswer"].ToString(), re["MaximumMarksForQuestion"].ToString());
                selectedQuestionToAnswer.Add(thisQuestion);
            }

            conn.Close();
            return selectedQuestionToAnswer;
        }

        public Question readQuestionsInOrder(string id, string num)
        {
            string query = "SELECT * FROM CoreQuestions WHERE CoreHomeworkParent = '" + id + "' AND QuestionNumber = '" + num + "'";
            Question selectedQuestionToAnswer = new Question();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@id", id);
            //cmd.Parameters.AddWithValue("@num", num);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedQuestionToAnswer = new Question(re["CoreQuestionID"].ToString(), re["CoreHomeworkParent"].ToString(), re["QuestionNumber"].ToString(), re["QuestionToAnswer"].ToString(), re["MaximumMarksForQuestion"].ToString());
            }

            conn.Close();
            return selectedQuestionToAnswer;
        }

        
        public void updateQuestion(string parentID, string qNum, string answer, string maxMarks)
        {
            string query = "UPDATE CoreQuestions SET QuestionToAnswer = '" + answer + "', MaximumMarksForQuestion = '" + maxMarks + "' WHERE CoreHomeworkParent = '" + parentID + "' AND QuestionNumber = '" + qNum + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();

        }


        public void deleteQuestions(string id)
        {
            string query = "DELETE FROM CoreQuestions WHERE CoreHomeworkParent = '" + id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();


        }





    }
}