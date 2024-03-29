﻿using System;
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
    public partial class Teacher_View_Current_Homework : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());
        string username, userID, hwID;
        bool validateInputs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["SelectedHomework"] == null) 
            {
                Response.Redirect("Teacher_Home.aspx");
            }
            else { }

            username = Session["user"].ToString();
            userID = findTeacherID();

            hwID = Session["SelectedHomework"].ToString();

            hideAllQuestions();

            if (!IsPostBack)
            {

                fillAnswers();

            }
            else
            { }
            
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

        protected void btnSubmitMarkedHomework_Click(object sender, EventArgs e)
        {
            ArrayList allSelectedQuestions = new ArrayList();
            QuestionToAnswer question = new QuestionToAnswer();
            allSelectedQuestions = question.readSelectedQuestionInHomework(hwID);
            validateInputs = false;

            string totalMarks = "";


            if (allSelectedQuestions.Count == 1)
            {
                checkInput1();
            }
            else if (allSelectedQuestions.Count == 2)
            {
                checkInput1();
                checkInput2();
            }
            else if (allSelectedQuestions.Count == 3)
            {
                checkInput1();
                checkInput2();
                checkInput3();
            }
            else if (allSelectedQuestions.Count == 4)
            {
                checkInput1();
                checkInput2();
                checkInput3();
                checkInput4();
            }
            else if (allSelectedQuestions.Count == 5)
            {
                checkInput1();
                checkInput2();
                checkInput3();
                checkInput4();
                checkInput5();
            }
            else if (allSelectedQuestions.Count == 6)
            {
                checkInput1();
                checkInput2();
                checkInput3();
                checkInput4();
                checkInput5();
                checkInput6();
            }
            else if (allSelectedQuestions.Count == 7)
            {
                checkInput1();
                checkInput2();
                checkInput3();
                checkInput4();
                checkInput5();
                checkInput6();
                checkInput7();
            }
            else if (allSelectedQuestions.Count == 8)
            {
                checkInput1();
                checkInput2();
                checkInput3();
                checkInput4();
                checkInput5();
                checkInput6();
                checkInput7();
                checkInput8();
            }
            else if (allSelectedQuestions.Count == 9)
            {
                checkInput1();
                checkInput2();
                checkInput3();
                checkInput4();
                checkInput5();
                checkInput6();
                checkInput7();
                checkInput8();
                checkInput9();
            }
            else if (allSelectedQuestions.Count == 10)
            {
                checkInput1();
                checkInput2();
                checkInput3();
                checkInput4();
                checkInput5();
                checkInput6();
                checkInput7();
                checkInput8();
                checkInput9();
                checkInput10();
            }
            else { }




            if (validateInputs == false)
            {

                if (allSelectedQuestions.Count == 1)
                {
                    feedbackAnswer1();

                    totalMarks = totalMarks1Qs();
                }
                else if (allSelectedQuestions.Count == 2)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();

                    totalMarks = totalMarks2Qs();
                }
                else if (allSelectedQuestions.Count == 3)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();
                    feedbackAnswer3();

                    totalMarks = totalMarks3Qs();
                }
                else if (allSelectedQuestions.Count == 4)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();
                    feedbackAnswer3();
                    feedbackAnswer4();

                    totalMarks = totalMarks4Qs();
                }
                else if (allSelectedQuestions.Count == 5)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();
                    feedbackAnswer3();
                    feedbackAnswer4();
                    feedbackAnswer5();

                    totalMarks = totalMarks5Qs();
                }
                else if (allSelectedQuestions.Count == 6)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();
                    feedbackAnswer3();
                    feedbackAnswer4();
                    feedbackAnswer5();
                    feedbackAnswer6();

                    totalMarks = totalMarks6Qs();
                }
                else if (allSelectedQuestions.Count == 7)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();
                    feedbackAnswer3();
                    feedbackAnswer4();
                    feedbackAnswer5();
                    feedbackAnswer6();
                    feedbackAnswer7();

                    totalMarks = totalMarks7Qs();
                }
                else if (allSelectedQuestions.Count == 8)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();
                    feedbackAnswer3();
                    feedbackAnswer4();
                    feedbackAnswer5();
                    feedbackAnswer6();
                    feedbackAnswer7();
                    feedbackAnswer8();

                    totalMarks = totalMarks8Qs();
                }
                else if (allSelectedQuestions.Count == 9)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();
                    feedbackAnswer3();
                    feedbackAnswer4();
                    feedbackAnswer5();
                    feedbackAnswer6();
                    feedbackAnswer7();
                    feedbackAnswer8();
                    feedbackAnswer9();

                    totalMarks = totalMarks9Qs();
                }
                else if (allSelectedQuestions.Count == 10)
                {
                    feedbackAnswer1();
                    feedbackAnswer2();
                    feedbackAnswer3();
                    feedbackAnswer4();
                    feedbackAnswer5();
                    feedbackAnswer6();
                    feedbackAnswer7();
                    feedbackAnswer8();
                    feedbackAnswer9();
                    feedbackAnswer10();

                    totalMarks = totalMarks10Qs();
                }
                else { }


                IssuedHomework thisHomework = new IssuedHomework();
                thisHomework.updateMarkHomework(hwID);
                
                thisHomework.updateHomeworkTotal(hwID, totalMarks);

                Session["SelectedHomework"] = null;
                Response.Redirect("Teacher_Home.aspx");

            }
            else
            {
                //incorrect input please try again with correct input
                //problems could be; awarded marks are higher than maximum achivable


            }


        }

        private void fillAnswers()
        {
            //IssuedHomework thisHomework = new IssuedHomework();
            //thisHomework = thisHomework.readSelectedIssuedHomework(hwID);

            ArrayList allSelectedQuestions = new ArrayList();
            QuestionToAnswer question = new QuestionToAnswer();
            allSelectedQuestions = question.readSelectedQuestionInHomework(hwID);


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







        private void fillAnswer1()
        {
            q1Conainer.Visible = true;
            
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "1");

            q1Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks1.InnerText = "Question 1 maximum marks: " + thisQuestion.MarksForQuestion;
            
            txtQ1StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }



        private void fillAnswer2()
        {
            q2Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "2");

            q2Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks2.InnerText = "Question 2 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ2StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }


        private void fillAnswer3()
        {
            q3Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "3");

            q3Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks3.InnerText = "Question 3 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ3StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }


        private void fillAnswer4()
        {
            q4Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "4");

            q4Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks4.InnerText = "Question 4 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ4StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }


        private void fillAnswer5()
        {
            q5Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "5");

            q5Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks5.InnerText = "Question 5 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ5StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }


        private void fillAnswer6()
        {
            q6Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "6");

            q6Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks6.InnerText = "Question 6 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ6StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }


        private void fillAnswer7()
        {
            q7Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "7");

            q7Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks7.InnerText = "Question 7 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ7StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }


        private void fillAnswer8()
        {
            q8Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "8");

            q8Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks8.InnerText = "Question 8 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ8StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }


        private void fillAnswer9()
        {
            q9Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "9");

            q9Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks9.InnerText = "Question 9 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ9StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }


        private void fillAnswer10()
        {
            q10Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "10");

            q10Text.InnerText = thisQuestion.QuestionText;
            QMaxMarks10.InnerText = "Question 10 maximum marks: " + thisQuestion.MarksForQuestion;

            txtQ10StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);

        }






        private void feedbackAnswer1()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ1Marks.Text;
            feedback = txtQ1Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "1");
        }


        private void feedbackAnswer2()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ2Marks.Text;
            feedback = txtQ2Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "2");
        }


        private void feedbackAnswer3()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ3Marks.Text;
            feedback = txtQ3Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "3");
        }


        private void feedbackAnswer4()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ4Marks.Text;
            feedback = txtQ4Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "4");
        }


        private void feedbackAnswer5()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ5Marks.Text;
            feedback = txtQ5Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "5");
        }


        private void feedbackAnswer6()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ6Marks.Text;
            feedback = txtQ6Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "6");
        }


        private void feedbackAnswer7()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ7Marks.Text;
            feedback = txtQ7Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "7");
        }


        private void feedbackAnswer8()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ8Marks.Text;
            feedback = txtQ8Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "8");
        }


        private void feedbackAnswer9()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ9Marks.Text;
            feedback = txtQ9Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "9");
        }


        private void feedbackAnswer10()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();

            string marks = "", feedback = "";
            marks = txtQ10Marks.Text;
            feedback = txtQ10Feedback.Text;

            thisQuestion.updateGradedQuestion(marks, feedback, hwID, "10");
        }






        private void checkInput1()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "1");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput2()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "2");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput3()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "3");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput4()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "4");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput5()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "5");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput6()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "6");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput7()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "7");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput8()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "8");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput9()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "9");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private void checkInput10()
        {
            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readQuestionsInOrder(hwID, "10");

            double maxMarks = Convert.ToDouble(thisQuestion.MarksForQuestion);
            double inputMarks = Convert.ToDouble(txtQ1Marks.Text);

            if (maxMarks >= inputMarks)
            { }
            else { validateInputs = true; }


        }


        private string totalMarks1Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);


            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));

            string homeworkResults = q1In.ToString() + " / " + q1MaxMarks.ToString();
            return homeworkResults;
        }




        private string totalMarks2Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);


            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));


            double totalIn = q1In + q2In;
            double totalAvalable = q1MaxMarks + q2MaxMarks;

            //double totalOut = totalIn / 2;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;
        }




        private string totalMarks3Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);
            double q3In = Convert.ToDouble(txtQ3Marks.Text);


            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));
            double q3MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "3"));


            double totalIn = q1In + q2In + q3In;
            double totalAvalable = q1MaxMarks + q2MaxMarks + q3MaxMarks;

            //double totalOut = totalIn / 3;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;
        }




        private string totalMarks4Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);
            double q3In = Convert.ToDouble(txtQ3Marks.Text);
            double q4In = Convert.ToDouble(txtQ4Marks.Text);


            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));
            double q3MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "3"));
            double q4MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "4"));


            double totalIn = q1In + q2In + q3In + q4In;
            double totalAvalable = q1MaxMarks + q2MaxMarks + q3MaxMarks + q4MaxMarks;

            //double totalOut = totalIn / 4;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;
        }




        private string totalMarks5Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);
            double q3In = Convert.ToDouble(txtQ3Marks.Text);
            double q4In = Convert.ToDouble(txtQ4Marks.Text);
            double q5In = Convert.ToDouble(txtQ5Marks.Text);


            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));
            double q3MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "3"));
            double q4MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "4"));
            double q5MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "5"));


            double totalIn = q1In + q2In + q3In + q4In + q5In;
            double totalAvalable = q1MaxMarks + q2MaxMarks + q3MaxMarks + q4MaxMarks + q5MaxMarks;

            //double totalOut = totalIn / 5;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;
        }




        private string totalMarks6Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);
            double q3In = Convert.ToDouble(txtQ3Marks.Text);
            double q4In = Convert.ToDouble(txtQ4Marks.Text);
            double q5In = Convert.ToDouble(txtQ5Marks.Text);
            double q6In = Convert.ToDouble(txtQ6Marks.Text);


            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));
            double q3MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "3"));
            double q4MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "4"));
            double q5MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "5"));
            double q6MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "6"));


            double totalIn = q1In + q2In + q3In + q4In + q5In + q6In;
            double totalAvalable = q1MaxMarks + q2MaxMarks + q3MaxMarks + q4MaxMarks + q5MaxMarks + q6MaxMarks;

            //double totalOut = totalIn / 6;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;
        }




        private string totalMarks7Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);
            double q3In = Convert.ToDouble(txtQ3Marks.Text);
            double q4In = Convert.ToDouble(txtQ4Marks.Text);
            double q5In = Convert.ToDouble(txtQ5Marks.Text);
            double q6In = Convert.ToDouble(txtQ6Marks.Text);
            double q7In = Convert.ToDouble(txtQ7Marks.Text);


            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));
            double q3MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "3"));
            double q4MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "4"));
            double q5MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "5"));
            double q6MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "6"));
            double q7MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "7"));


            double totalIn = q1In + q2In + q3In + q4In + q5In + q6In + q7In;
            double totalAvalable = q1MaxMarks + q2MaxMarks + q3MaxMarks + q4MaxMarks + q5MaxMarks + q6MaxMarks + q7MaxMarks;

            //double totalOut = totalIn / 7;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;
        }




        private string totalMarks8Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);
            double q3In = Convert.ToDouble(txtQ3Marks.Text);
            double q4In = Convert.ToDouble(txtQ4Marks.Text);
            double q5In = Convert.ToDouble(txtQ5Marks.Text);
            double q6In = Convert.ToDouble(txtQ6Marks.Text);
            double q7In = Convert.ToDouble(txtQ7Marks.Text);
            double q8In = Convert.ToDouble(txtQ8Marks.Text);
            ;

            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));
            double q3MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "3"));
            double q4MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "4"));
            double q5MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "5"));
            double q6MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "6"));
            double q7MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "7"));
            double q8MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "8"));


            double totalIn = q1In + q2In + q3In + q4In + q5In + q6In + q7In + q8In;
            double totalAvalable = q1MaxMarks + q2MaxMarks + q3MaxMarks + q4MaxMarks + q5MaxMarks + q6MaxMarks + q7MaxMarks + q8MaxMarks;

            //double totalOut = totalIn / 8;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;
        }




        private string totalMarks9Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);
            double q3In = Convert.ToDouble(txtQ3Marks.Text);
            double q4In = Convert.ToDouble(txtQ4Marks.Text);
            double q5In = Convert.ToDouble(txtQ5Marks.Text);
            double q6In = Convert.ToDouble(txtQ6Marks.Text);
            double q7In = Convert.ToDouble(txtQ7Marks.Text);
            double q8In = Convert.ToDouble(txtQ8Marks.Text);
            double q9In = Convert.ToDouble(txtQ9Marks.Text);


            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));
            double q3MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "3"));
            double q4MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "4"));
            double q5MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "5"));
            double q6MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "6"));
            double q7MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "7"));
            double q8MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "8"));
            double q9MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "9"));


            double totalIn = q1In + q2In + q3In + q4In + q5In + q6In + q7In + q8In + q9In;
            double totalAvalable = q1MaxMarks + q2MaxMarks + q3MaxMarks + q4MaxMarks + q5MaxMarks + q6MaxMarks + q7MaxMarks + q8MaxMarks + q9MaxMarks;

            //double totalOut = totalIn / 9;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;
        }






        private string totalMarks10Qs()
        {
            double q1In = Convert.ToDouble(txtQ1Marks.Text);
            double q2In = Convert.ToDouble(txtQ2Marks.Text);
            double q3In = Convert.ToDouble(txtQ3Marks.Text);
            double q4In = Convert.ToDouble(txtQ4Marks.Text);
            double q5In = Convert.ToDouble(txtQ5Marks.Text);
            double q6In = Convert.ToDouble(txtQ6Marks.Text);
            double q7In = Convert.ToDouble(txtQ7Marks.Text);
            double q8In = Convert.ToDouble(txtQ8Marks.Text);
            double q9In = Convert.ToDouble(txtQ9Marks.Text);
            double q10In = Convert.ToDouble(txtQ10Marks.Text);

            QuestionToAnswer question = new QuestionToAnswer();

            double q1MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "1"));
            double q2MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "2"));
            double q3MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "3"));
            double q4MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "4"));
            double q5MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "5"));
            double q6MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "6"));
            double q7MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "7"));
            double q8MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "8"));
            double q9MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "9"));
            double q10MaxMarks = Convert.ToDouble(question.readAvailableMarks(hwID, "10"));


            double totalIn = q1In + q2In + q3In + q4In + q5In + q6In + q7In + q8In + q9In + q10In;
            double totalAvalable = q1MaxMarks + q2MaxMarks + q3MaxMarks + q4MaxMarks + q5MaxMarks + q6MaxMarks + q7MaxMarks + q8MaxMarks + q9MaxMarks + q10MaxMarks;

            //double totalOut = totalIn / 10;

            string homeworkResults = totalIn.ToString() + " / " + totalAvalable.ToString();
            return homeworkResults;           
        }


                                   
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }

    }
}