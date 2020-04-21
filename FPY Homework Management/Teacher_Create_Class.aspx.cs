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
    public partial class Teacher_Create_Class : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateClass_Click(object sender, EventArgs e)
        {
            string teachID = drpSelectTeacher.Text;
            string clsSubj = classSubjectIn.Text;
            string clsYea = classYearGroupIn.Text;

            SchoolClass cls = new SchoolClass(teachID, clsSubj, clsYea);
            cls.createSchoolClass();                                              

        }



    }
}