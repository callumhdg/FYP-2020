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
    public partial class Student_View_Homework : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());
        string currentIssuedHomeworkID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["SelectedHomework"] == null)
            {
                Response.Redirect("Student_Home.aspx");
            }
            else { }

            hideAllQuestions();
            displayAllQuestions();
        }


        protected void displayAllQuestions()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();

            //read issued homework
            //read questions from homework
            //display questions

            IssuedHomework thisHomework = new IssuedHomework();
            thisHomework = thisHomework.readSelectedIssuedHomework(currentIssuedHomeworkID);

            Homework originalHomework = new Homework();
            originalHomework.readSingleCoreHomework(thisHomework.CoreHomeworkID);

            homeworkTitle.InnerText = originalHomework.hwTitle;//not sure if this is displaying
            timeEstemate.InnerText = "This homework should take " + thisHomework.TimeToComplete + " minutes to complete";


            ArrayList allSelectedQuestions = new ArrayList();
            QuestionToAnswer question = new QuestionToAnswer();
            allSelectedQuestions = question.readSelectedQuestionInHomework(currentIssuedHomeworkID);


            if (allSelectedQuestions.Count == 1)
            {
                fillQuestion1();
            }
            else if (allSelectedQuestions.Count == 2)
            {
                fillQuestion1();
                fillQuestion2();
            }
            else if (allSelectedQuestions.Count == 3)
            {
                fillQuestion1();
                fillQuestion2();
                fillQuestion3();
            }
            else if (allSelectedQuestions.Count == 4)
            {
                fillQuestion1();
                fillQuestion2();
                fillQuestion3();
                fillQuestion4();
            }
            else if (allSelectedQuestions.Count == 5)
            {
                fillQuestion1();
                fillQuestion2();
                fillQuestion3();
                fillQuestion4();
                fillQuestion5();
            }
            else if (allSelectedQuestions.Count == 6)
            {
                fillQuestion1();
                fillQuestion2();
                fillQuestion3();
                fillQuestion4();
                fillQuestion5();
                fillQuestion6();
            }
            else if (allSelectedQuestions.Count == 7)
            {
                fillQuestion1();
                fillQuestion2();
                fillQuestion3();
                fillQuestion4();
                fillQuestion5();
                fillQuestion6();
                fillQuestion7();
            }
            else if (allSelectedQuestions.Count == 8)
            {
                fillQuestion1();
                fillQuestion2();
                fillQuestion3();
                fillQuestion4();
                fillQuestion5();
                fillQuestion6();
                fillQuestion7();
                fillQuestion8();
            }
            else if (allSelectedQuestions.Count == 9)
            {
                fillQuestion1();
                fillQuestion2();
                fillQuestion3();
                fillQuestion4();
                fillQuestion5();
                fillQuestion6();
                fillQuestion7();
                fillQuestion8();
                fillQuestion9();
            }
            else if (allSelectedQuestions.Count == 10)
            {
                fillQuestion1();
                fillQuestion2();
                fillQuestion3();
                fillQuestion4();
                fillQuestion5();
                fillQuestion6();
                fillQuestion7();
                fillQuestion8();
                fillQuestion9();
                fillQuestion10();
            }
            else { }






        }


        protected void btnSubmitHomework_Click(object sender, EventArgs e)
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();

            ArrayList allSelectedQuestions = new ArrayList();
            QuestionToAnswer question = new QuestionToAnswer();
            allSelectedQuestions = question.readSelectedQuestionInHomework(currentIssuedHomeworkID);

            //bool allQsAnswered = false;// answerQuestion(){ if (txtAnswer == null) { allQAnsw = false } else { allQAnsw = true } }


            if (allSelectedQuestions.Count == 1)
            {
                answerQuestion1();
            }
            else if (allSelectedQuestions.Count == 2)
            {
                answerQuestion1();
                answerQuestion2();
            }
            else if (allSelectedQuestions.Count == 3)
            {
                answerQuestion1();
                answerQuestion2();
                answerQuestion3();
            }
            else if (allSelectedQuestions.Count == 4)
            {
                answerQuestion1();
                answerQuestion2();
                answerQuestion3();
                answerQuestion4();
            }
            else if (allSelectedQuestions.Count == 5)
            {
                answerQuestion1();
                answerQuestion2();
                answerQuestion3();
                answerQuestion4();
                answerQuestion5();
            }
            else if (allSelectedQuestions.Count == 6)
            {
                answerQuestion1();
                answerQuestion2();
                answerQuestion3();
                answerQuestion4();
                answerQuestion5();
                answerQuestion6();
            }
            else if (allSelectedQuestions.Count == 7)
            {
                answerQuestion1();
                answerQuestion2();
                answerQuestion3();
                answerQuestion4();
                answerQuestion5();
                answerQuestion6();
                answerQuestion7();
            }
            else if (allSelectedQuestions.Count == 8)
            {
                answerQuestion1();
                answerQuestion2();
                answerQuestion3();
                answerQuestion4();
                answerQuestion5();
                answerQuestion6();
                answerQuestion7();
                answerQuestion8();
            }
            else if (allSelectedQuestions.Count == 9)
            {
                answerQuestion1();
                answerQuestion2();
                answerQuestion3();
                answerQuestion4();
                answerQuestion5();
                answerQuestion6();
                answerQuestion7();
                answerQuestion8();
                answerQuestion9();
            }
            else if (allSelectedQuestions.Count == 10)
            {
                answerQuestion1();
                answerQuestion2();
                answerQuestion3();
                answerQuestion4();
                answerQuestion5();
                answerQuestion6();
                answerQuestion7();
                answerQuestion8();
                answerQuestion9();
                answerQuestion10();
            }
            else { }

            IssuedHomework thisHomework = new IssuedHomework();
            thisHomework.updateSubmittedHomework(currentIssuedHomeworkID);

            Session["SelectedHomework"] = null;
            Response.Redirect("Student_Home.aspx");
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


        public void fillQuestion1()
        {
            q1Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "1");

            q1Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks1.InnerText = "Question 1 Marks: " + thisQuestion.MarksForQuestion;


            try
            {
                txtQ1Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
            
        }

        public void fillQuestion2()
        {
            q2Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "2");

            q2Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks2.InnerText = "Question 2 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ2Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }

        public void fillQuestion3()
        {
            q3Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "3");

            q3Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks3.InnerText = "Question 3 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ3Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }

        public void fillQuestion4()
        {
            q4Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "4");

            q4Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks4.InnerText = "Question 4 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ4Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }

        public void fillQuestion5()
        {
            q5Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "5");

            q5Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks5.InnerText = "Question 5 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ5Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }

        public void fillQuestion6()
        {
            q6Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "6");

            q6Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks6.InnerText = "Question 6 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ6Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }

        public void fillQuestion7()
        {
            q7Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "7");

            q7Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks7.InnerText = "Question 7 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ7Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }

        public void fillQuestion8()
        {
            q8Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "8");

            q8Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks8.InnerText = "Question 8 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ8Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }

        public void fillQuestion9()
        {
            q9Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "9");

            q9Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks9.InnerText = "Question 9 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ9Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }

        public void fillQuestion10()
        {
            q10Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "10");

            q10Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks10.InnerText = "Question 10 Marks: " + thisQuestion.MarksForQuestion;

            try
            {
                txtQ10Answer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            }
            catch { }
        }





        public void answerQuestion1()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ1Answer.Text, currentIssuedHomeworkID, "1");
        }

        public void answerQuestion2()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ2Answer.Text, currentIssuedHomeworkID, "2");
        }

        public void answerQuestion3()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ3Answer.Text, currentIssuedHomeworkID, "3");
        }

        public void answerQuestion4()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ4Answer.Text, currentIssuedHomeworkID, "4");
        }

        public void answerQuestion5()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ5Answer.Text, currentIssuedHomeworkID, "5");
        }

        public void answerQuestion6()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ6Answer.Text, currentIssuedHomeworkID, "6");
        }

        public void answerQuestion7()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ7Answer.Text, currentIssuedHomeworkID, "7");
        }

        public void answerQuestion8()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ8Answer.Text, currentIssuedHomeworkID, "8");
        }

        public void answerQuestion9()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ9Answer.Text, currentIssuedHomeworkID, "9");
        }

        public void answerQuestion10()
        {
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion.updateAnsweredQuestion(txtQ10Answer.Text, currentIssuedHomeworkID, "10");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session["SelectedHomework"] = null;

            Response.Redirect("Student_Home.aspx");
        }


    }
}