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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateHomework_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList hwCount = new ArrayList();
                Homework hw = new Homework();
                hwCount = hw.readAllCoreHomework();
                int idNum = hwCount.Count + 1;

                Homework homework = new Homework(idNum.ToString(), "teacher id here", minutesToCompleteInput.Text, CoreHomeworkTitleInput.Text);//change teacher id field to teacher id
                homework.createCoreHomework();


                Question question1 = new Question(idNum.ToString(), "1", Qtext1.Text, QMaxMarks1.Text);
                //question1.createCoreQuestion();
                Question question2 = new Question(idNum.ToString(), "2", Qtext2.Text, QMaxMarks2.Text);
                //question2.createCoreQuestion();
                Question question3 = new Question(idNum.ToString(), "3", Qtext3.Text, QMaxMarks3.Text);
                //question3.createCoreQuestion();
                Question question4 = new Question(idNum.ToString(), "4", Qtext4.Text, QMaxMarks4.Text);
                //question4.createCoreQuestion();
                Question question5 = new Question(idNum.ToString(), "5", Qtext5.Text, QMaxMarks5.Text);
                //question5.createCoreQuestion();
                Question question6 = new Question(idNum.ToString(), "6", Qtext6.Text, QMaxMarks6.Text);
                //question6.createCoreQuestion();
                Question question7 = new Question(idNum.ToString(), "7", Qtext7.Text, QMaxMarks7.Text);
                //question7.createCoreQuestion();
                Question question8 = new Question(idNum.ToString(), "8", Qtext8.Text, QMaxMarks8.Text);
                //question8.createCoreQuestion();
                Question question9 = new Question(idNum.ToString(), "9", Qtext9.Text, QMaxMarks9.Text);
                //question9.createCoreQuestion();
                Question question10 = new Question(idNum.ToString(), "10", Qtext10.Text, QMaxMarks10.Text);
                //question10.createCoreQuestion();



                //check to see if questions are empty so they dont have to be created if they arent filled in
                if (Qtext1.Text == "" || QMaxMarks1.Text == ""){}
                else
                { question1.createCoreQuestion(); }

                if (Qtext2.Text == "" || QMaxMarks2.Text == "") {}
                else
                { question2.createCoreQuestion(); }

                if (Qtext3.Text == "" || QMaxMarks3.Text == "") {}
                else
                { question3.createCoreQuestion(); }

                if (Qtext4.Text == "" || QMaxMarks4.Text == "") {}
                else
                { question4.createCoreQuestion(); }

                if (Qtext5.Text == "" || QMaxMarks5.Text == "") {}
                else
                { question5.createCoreQuestion(); }

                if (Qtext6.Text == "" || QMaxMarks6.Text == "") {}
                else
                { question6.createCoreQuestion(); }

                if (Qtext7.Text == "" || QMaxMarks7.Text == "") {}
                else
                { question7.createCoreQuestion(); }

                if (Qtext8.Text == "" || QMaxMarks8.Text == "") {}
                else
                { question8.createCoreQuestion(); }

                if (Qtext9.Text == "" || QMaxMarks9.Text == "") {}
                else
                { question9.createCoreQuestion(); }

                if (Qtext10.Text == "" || QMaxMarks10.Text == "") {}
                else
                { question10.createCoreQuestion(); }


                                             
                submissionFeedback.Text = "Homework was sucsesfully created";


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
            catch
            {
                submissionFeedback.Text = "Homework creation failed, please fill all fields";
            }


        }

        protected void CoreHomeworkTitleInput_TextChanged(object sender, EventArgs e)
        {
            string title = CoreHomeworkTitleInput.Text;
            string time = minutesToCompleteInput.Text;
            if (title == "" & time == "")
            {
                btnCreateHomework.Enabled = false;
                btnCreateHomework.CssClass = "bg-warning";
            }
            else
            {
                btnCreateHomework.Enabled = true;
                btnCreateHomework.CssClass = "bg-primary";
            }
        }

        protected void minutesToCompleteInput_TextChanged(object sender, EventArgs e)
        {
            string title = CoreHomeworkTitleInput.Text;
            string time = minutesToCompleteInput.Text;
            if (title == "" & time == "")
            {
                btnCreateHomework.Enabled = false;
                btnCreateHomework.CssClass = "bg-warning";
            }
            else
            {
                btnCreateHomework.Enabled = true;
                btnCreateHomework.CssClass = "bg-primary";
            }
        }
    }
}