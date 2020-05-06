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

            homeworkTitle.InnerText = originalHomework.hwTitle;
            timeEstemate.InnerText = thisHomework.TimeToComplete;


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








            Session["SelectedHomework"] = null;
            Response.Redirect("Student_Home.aspx");
        }



        //public void readThisIssuedHomework()
        //{
        //    IssuedHomework thisHomework = new IssuedHomework();
        //    thisHomework = thisHomework.readSelectedIssuedHomework(currentIssuedHomeworkID);

        //    Homework originalHomework = new Homework();
        //    originalHomework.readSingleCoreHomework(thisHomework.CoreHomeworkID);

        //    homeworkTitle.InnerText = originalHomework.hwTitle;
        //    timeEstemate.InnerText = thisHomework.TimeToComplete;
        //}

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
            QMaxMarks1.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion2()
        {
            q2Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "2");

            q2Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks2.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion3()
        {
            q3Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "3");

            q3Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks3.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion4()
        {
            q4Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "4");

            q4Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks4.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion5()
        {
            q5Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "5");

            q5Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks5.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion6()
        {
            q6Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "6");

            q6Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks6.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion7()
        {
            q7Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "7");

            q7Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks7.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion8()
        {
            q8Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "8");

            q8Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks8.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion9()
        {
            q9Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "9");

            q9Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks9.InnerText = thisQuestion.MarksForQuestion;
        }

        public void fillQuestion10()
        {
            q10Conainer.Visible = true;
            currentIssuedHomeworkID = Session["SelectedHomework"].ToString();
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(currentIssuedHomeworkID, "10");

            q10Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks10.InnerText = thisQuestion.MarksForQuestion;
        }



    }
}