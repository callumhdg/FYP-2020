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
    public partial class Teacher_Update_Homework : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());
        string username, userID, hwID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["SelectedHomework"] == null)
            {
                Response.Redirect("Teacher_View_All_Homework.aspx");
            }
            else { }

            username = Session["user"].ToString();
            userID = findTeacherID();

            hwID = Session["SelectedHomework"].ToString();

            
            Homework homework = new Homework();
            homework = homework.readSingleCoreHomework(hwID);

                       
            if (!IsPostBack)
            {

                fillHomework();

            }
            else
            { }
                       
        }

        protected void btnUpdateHomework_Click(object sender, EventArgs e)
        {
            Homework homework = new Homework();
            homework.updateCoreHomework(hwID, userID, txtHomeworkDuration.Text, txtHomeworkTitle.Text);

            

            ArrayList originalSelectedQuestions = new ArrayList();
            Question question = new Question();
            originalSelectedQuestions = question.readSelectedQuestionInHomework(hwID);
            int originalQuestionCount = originalSelectedQuestions.Count;



            if (txtQ1Text.Text == "" || txtQ1Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 1)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "1", txtQ1Text.Text, txtQ1Marks.Text);
                }
                else if (originalQuestionCount < 1)
                {
                    Question q = new Question(hwID, "1", txtQ1Text.Text, txtQ1Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }


            if (txtQ2Text.Text == "" || txtQ2Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 2)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "2", txtQ2Text.Text, txtQ2Marks.Text);
                }
                else if (originalQuestionCount < 2)
                {
                    Question q = new Question(hwID, "2", txtQ2Text.Text, txtQ2Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }
            

            if (txtQ3Text.Text == "" || txtQ3Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 3)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "3", txtQ3Text.Text, txtQ3Marks.Text);
                }
                else if (originalQuestionCount < 3)
                {
                    Question q = new Question(hwID, "3", txtQ3Text.Text, txtQ3Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }

            
            if (txtQ4Text.Text == "" || txtQ4Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 4)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "4", txtQ4Text.Text, txtQ4Marks.Text);
                }
                else if (originalQuestionCount < 4)
                {
                    Question q = new Question(hwID, "4", txtQ4Text.Text, txtQ4Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }
            

            if (txtQ5Text.Text == "" || txtQ5Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 5)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "5", txtQ5Text.Text, txtQ5Marks.Text);
                }
                else if (originalQuestionCount < 5)
                {
                    Question q = new Question(hwID, "5", txtQ5Text.Text, txtQ5Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }

            
            if (txtQ6Text.Text == "" || txtQ6Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 6)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "6", txtQ6Text.Text, txtQ6Marks.Text);
                }
                else if (originalQuestionCount < 6)
                {
                    Question q = new Question(hwID, "6", txtQ6Text.Text, txtQ6Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }

            
            if (txtQ7Text.Text == "" || txtQ7Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 7)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "7", txtQ7Text.Text, txtQ7Marks.Text);
                }
                else if (originalQuestionCount < 7)
                {
                    Question q = new Question(hwID, "7", txtQ7Text.Text, txtQ7Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }
            

            if (txtQ8Text.Text == "" || txtQ8Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 8)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "8", txtQ8Text.Text, txtQ8Marks.Text);
                }
                else if (originalQuestionCount < 8)
                {
                    Question q = new Question(hwID, "8", txtQ8Text.Text, txtQ8Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }
            

            if (txtQ9Text.Text == "" || txtQ9Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 9)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "9", txtQ9Text.Text, txtQ9Marks.Text);
                }
                else if (originalQuestionCount < 9)
                {
                    Question q = new Question(hwID, "9", txtQ9Text.Text, txtQ9Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }
            

            if (txtQ10Text.Text == "" || txtQ10Marks.Text == "") { }
            else
            {
                if (originalQuestionCount >= 10)
                {
                    Question q = new Question();
                    q.updateQuestion(hwID, "10", txtQ10Text.Text, txtQ10Marks.Text);
                }
                else if (originalQuestionCount < 10)
                {
                    Question q = new Question(hwID, "10", txtQ10Text.Text, txtQ10Marks.Text);
                    q.createCoreQuestion();

                }
                else { }
            }


            Session["SelectedHomework"] = null;

            Response.Redirect("Teacher_View_All_Homework.aspx");

        }

        protected string findTeacherID()
        {

            string query = "SELECT TeacherID from Teachers where TeacherUsername = '" + username + "'";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();
            string id = "";

            while (re.Read())
            {
                id = re["TeacherID"].ToString();
            }

            conn.Close();
            return id;
        }
        
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }
        
        public void hideAllQuestions()
        {
            q1Conainer.Visible = false;
            q2Conainer.Visible = false;
            q3Conainer.Visible = false;
            q4Conainer.Visible = false;
            q5Conainer.Visible = false;
            q6Conainer.Visible = false;
            q7Conainer.Visible = false;
            q8Conainer.Visible = false;
            q9Conainer.Visible = false;
            q10Conainer.Visible = false;
        }


        private void fillHomework()
        {
            Homework thisHomework = new Homework();
            thisHomework = thisHomework.readSingleCoreHomework(hwID);


            ArrayList allSelectedQuestions = new ArrayList();
            Question question = new Question();
            allSelectedQuestions = question.readSelectedQuestionInHomework(hwID);


            txtHomeworkTitle.Text = thisHomework.hwTitle;
            txtHomeworkDuration.Text = thisHomework.timeToComplete;


            if (allSelectedQuestions.Count == 1)
            {
                fillAnswer1();
            }
            else if (allSelectedQuestions.Count == 2)
            {
                fillAnswer1();
                fillAnswer2();
            }
            else if (allSelectedQuestions.Count == 3)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
            }
            else if (allSelectedQuestions.Count == 4)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
            }
            else if (allSelectedQuestions.Count == 5)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
            }
            else if (allSelectedQuestions.Count == 6)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
            }
            else if (allSelectedQuestions.Count == 7)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
                fillAnswer7();
            }
            else if (allSelectedQuestions.Count == 8)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
                fillAnswer7();
                fillAnswer8();
            }
            else if (allSelectedQuestions.Count == 9)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
                fillAnswer7();
                fillAnswer8();
                fillAnswer9();
            }
            else if (allSelectedQuestions.Count == 10)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
                fillAnswer7();
                fillAnswer8();
                fillAnswer9();
                fillAnswer10();
            }
            else { }


        }


        private void fillAnswer1()
        {
            q1Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "1");

            txtQ1Text.Text = thisQuestion.questionText;
            txtQ1Marks.Text = thisQuestion.maxMarksForQuestion;
        }


        private void fillAnswer2()
        {
            q2Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "2");

            txtQ2Text.Text = thisQuestion.questionText;
            txtQ2Marks.Text = thisQuestion.maxMarksForQuestion;
        }
        

        private void fillAnswer3()
        {
            q3Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "3");

            txtQ3Text.Text = thisQuestion.questionText;
            txtQ3Marks.Text = thisQuestion.maxMarksForQuestion;
        }

        
        private void fillAnswer4()
        {
            q4Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "4");

            txtQ4Text.Text = thisQuestion.questionText;
            txtQ4Marks.Text = thisQuestion.maxMarksForQuestion;
        }

        
        private void fillAnswer5()
        {
            q5Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "5");

            txtQ5Text.Text = thisQuestion.questionText;
            txtQ5Marks.Text = thisQuestion.maxMarksForQuestion;
        }
        

        private void fillAnswer6()
        {
            q6Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "6");

            txtQ6Text.Text = thisQuestion.questionText;
            txtQ6Marks.Text = thisQuestion.maxMarksForQuestion;
        }

        
        private void fillAnswer7()
        {
            q7Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "7");

            txtQ7Text.Text = thisQuestion.questionText;
            txtQ7Marks.Text = thisQuestion.maxMarksForQuestion;
        }
        

        private void fillAnswer8()
        {
            q8Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "8");

            txtQ8Text.Text = thisQuestion.questionText;
            txtQ8Marks.Text = thisQuestion.maxMarksForQuestion;
        }

        
        private void fillAnswer9()
        {
            q9Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "9");

            txtQ9Text.Text = thisQuestion.questionText;
            txtQ9Marks.Text = thisQuestion.maxMarksForQuestion;
        }

        
        private void fillAnswer10()
        {
            q10Conainer.Visible = true;

            Question thisQuestion = new Question();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "10");

            txtQ10Text.Text = thisQuestion.questionText;
            txtQ10Marks.Text = thisQuestion.maxMarksForQuestion;
        }
















    }
}