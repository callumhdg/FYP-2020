using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FPY_Homework_Management.Classes;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management
{
    public partial class TeacherCreateHW : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());
        string username, userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { }

            username = Session["user"].ToString();
            userID = findTeacherID();


            lblErrorMessage.Visible = false;
            divErrorMessage.Visible = false;
            lblSuccessMessage.Visible = false;
            divSuccessMessage.Visible = false;
        }

        protected void btnCreateHomework_Click(object sender, EventArgs e)
        {


            Utility utility = new Utility();
            string homeworkID = utility.readCurrentCoreHomeworkCount();


            Homework homework = new Homework(homeworkID, userID, minutesToCompleteInput.Text, CoreHomeworkTitleInput.Text);
            try
            {


                bool validate = false;
                validate = validateInput();

                if (validate == true)
                {
                    
                    homework.createCoreHomework();
                    utility.addCoreHomework();


                    //check to see if questions are empty so they dont have to be created if they arent filled in, sets the number of questions to the next question
                    //e.g., if numbers: 1,2,3,5 were filled in the question numbers will be saved as: 1,2,3,4
                    int qCount = 1;

                    if (Qtext1.Text == "" || QMaxMarks1.Text == "") { }
                    else
                    {
                        Question question1 = new Question(homeworkID, qCount.ToString(), Qtext1.Text, QMaxMarks1.Text);
                        question1.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext2.Text == "" || QMaxMarks2.Text == "") { }
                    else
                    {
                        Question question2 = new Question(homeworkID, qCount.ToString(), Qtext2.Text, QMaxMarks2.Text);
                        question2.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext3.Text == "" || QMaxMarks3.Text == "") { }
                    else
                    {
                        Question question3 = new Question(homeworkID, qCount.ToString(), Qtext3.Text, QMaxMarks3.Text);
                        question3.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext4.Text == "" || QMaxMarks4.Text == "") { }
                    else
                    {
                        Question question4 = new Question(homeworkID, qCount.ToString(), Qtext4.Text, QMaxMarks4.Text);
                        question4.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext5.Text == "" || QMaxMarks5.Text == "") { }
                    else
                    {
                        Question question5 = new Question(homeworkID, qCount.ToString(), Qtext5.Text, QMaxMarks5.Text);
                        question5.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext6.Text == "" || QMaxMarks6.Text == "") { }
                    else
                    {
                        Question question6 = new Question(homeworkID, qCount.ToString(), Qtext6.Text, QMaxMarks6.Text);
                        question6.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext7.Text == "" || QMaxMarks7.Text == "") { }
                    else
                    {
                        Question question7 = new Question(homeworkID, qCount.ToString(), Qtext7.Text, QMaxMarks7.Text);
                        question7.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext8.Text == "" || QMaxMarks8.Text == "") { }
                    else
                    {
                        Question question8 = new Question(homeworkID, qCount.ToString(), Qtext8.Text, QMaxMarks8.Text);
                        question8.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext9.Text == "" || QMaxMarks9.Text == "") { }
                    else
                    {
                        Question question9 = new Question(homeworkID, qCount.ToString(), Qtext9.Text, QMaxMarks9.Text);
                        question9.createCoreQuestion();
                        qCount++;
                    }

                    if (Qtext10.Text == "" || QMaxMarks10.Text == "") { }
                    else
                    {
                        Question question10 = new Question(homeworkID, qCount.ToString(), Qtext10.Text, QMaxMarks10.Text);
                        question10.createCoreQuestion();
                        qCount++;
                    }


                    //utility.addCoreHomework();
                    //submissionFeedback.Text = "Homework was sucsesfully created";
                    clearInputs();
                    lblErrorMessage.Visible = false;
                    divErrorMessage.Visible = false;
                    lblSuccessMessage.Visible = true;
                    divSuccessMessage.Visible = true;

                }
                else
                {

                    lblErrorMessage.Visible = true;
                    divErrorMessage.Visible = true;
                    lblSuccessMessage.Visible = false;
                    divSuccessMessage.Visible = false;
                }

            }
            catch
            {

                lblErrorMessage.Visible = true;
                divErrorMessage.Visible = true;
                lblSuccessMessage.Visible = false;
                divSuccessMessage.Visible = false;
            }


        }

        protected void CoreHomeworkTitleInput_TextChanged(object sender, EventArgs e)
        {
            string title = CoreHomeworkTitleInput.Text;
            string time = minutesToCompleteInput.Text;
            if (title == "" || time == "")
            {
                btnCreateHomework.Enabled = false;
                //btnCreateHomework.CssClass = "bg-warning";
            }
            else
            {
                btnCreateHomework.Enabled = true;
                //btnCreateHomework.CssClass = "bg-primary";
            }
        }

        protected void minutesToCompleteInput_TextChanged(object sender, EventArgs e)
        {
            string title = CoreHomeworkTitleInput.Text;
            string time = minutesToCompleteInput.Text;
            if (title == "" || time == "")
            {
                btnCreateHomework.Enabled = false;
                //btnCreateHomework.CssClass = "bg-warning";
            }
            else
            {
                btnCreateHomework.Enabled = true;
                //btnCreateHomework.CssClass = "bg-primary";
            }
        }

        private bool validateInput()
        {
            bool validate;

            if (CoreHomeworkTitleInput.Text != "" && minutesToCompleteInput.Text != "")
            {
                validate = true;
            }
            else
            {
                validate = false;
            }

            return validate;
        }

        private void clearInputs()
        {

            minutesToCompleteInput.Text = "";
            CoreHomeworkTitleInput.Text = "";

            Qtext1.Text = "";
            QMaxMarks1.Text = "";
            Qtext2.Text = "";
            QMaxMarks2.Text = "";
            Qtext3.Text = "";
            QMaxMarks3.Text = "";
            Qtext4.Text = "";
            QMaxMarks4.Text = "";
            Qtext5.Text = "";
            QMaxMarks5.Text = "";
            Qtext6.Text = "";
            QMaxMarks6.Text = "";
            Qtext7.Text = "";
            QMaxMarks7.Text = "";
            Qtext8.Text = "";
            QMaxMarks8.Text = "";
            Qtext9.Text = "";
            QMaxMarks9.Text = "";
            Qtext10.Text = "";
            QMaxMarks10.Text = "";

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
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


    }
}