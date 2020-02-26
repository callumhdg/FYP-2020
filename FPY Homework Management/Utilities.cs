using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace FPY_Homework_Management.Classes
{
    public class Utilities
    {

        public Utilities()
        {
        }


        public Boolean checkUsernameUnique(string username)
        {
            Teacher t = new Teacher();
            Student s = new Student();

            ArrayList allTeachers = t.readTeachers();
            ArrayList allStudents = s.readStudents();
            ArrayList allUsernames = new ArrayList();
            
            foreach(Teacher teacher in allTeachers)
            {
                allUsernames.Add(teacher.teacherUsername);
            }
            foreach(Student student in allStudents)
            {
                allUsernames.Add(student.studentUsername);
            }

            foreach(string uName in allUsernames)
            {
                if(uName == username)
                {
                    return false;
                }
            }
            return true;
        }

















    }
}