<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Assign_Students_To_Class.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Assign_Students_To_Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assign To Class</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>
</head>
<body>
        <div>
            <form id="frmAssignToClass" runat="server">
                <%--<asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [ClassID], [ClassTeacherID], [ClassSubject], [ClassYearGroup], [ClassName] FROM [Class] ORDER BY [ClassName] DESC"></asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="ViewAllStudents" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [StudentID], [StudentFirstName], [StudentLastName], [StudentUsername] FROM [Students] ORDER BY [StudentFirstName] DESC, [StudentLastName] DESC"></asp:SqlDataSource>

            

                <asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [ClassID], [ClassTeacherID], [ClassSubject], [ClassYearGroup], [ClassName] FROM [Class] ORDER BY [ClassName] DESC"></asp:SqlDataSource>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class*</span><br/>
                    <asp:DropDownList ID="drpSelectTeacher" runat="server" DataSourceID="ViewAllClasses" DataTextField="ClassName" DataValueField="ClassID" class="custom-select"></asp:DropDownList>
                </div><br/>

                <!-- students in selected class -->
                <!-- select student.username, student.name, StudentsInClass.ClassID from student join studentsInClass where (selected ClassID) == StudentsInClass.ClassID -->
                
                <!-- students not in selected class -->
                <!-- select student.username, student.name, StudentsInClass.ClassID from student join studentsInClass where StudentsInClass.ClassID != (selected ClassID) -->
                <asp:GridView ID="allStudents" runat="server" DataSourceID="ViewAllStudents" DataKeyNames="StudentID" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="StudentUsername" HeaderText="StudentUsername" ReadOnly="true" SortExpression="StudentUsername"/>
                        <asp:BoundField DataField="StudentFirstName" HeaderText="StudentFirstName" ReadOnly="true" SortExpression="StudentFirstName"/>
                        <asp:BoundField DataField="StudentLastName" HeaderText="StudentLastName" ReadOnly="true" SortExpression="StudentLastName"/>
                        <asp:BoundField DataField="StudentDOB" HeaderText="StudentDOB" ReadOnly="true" SortExpression="StudentDOB"/>
                        <asp:CheckBoxField/>
                    </Columns>
                </asp:GridView>




            </form>
        </div>
</body>
</html>
