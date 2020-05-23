<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Assign_Students_To_Class.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Assign_Students_To_Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assign To Class</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    
</head>
<body style="background-color:#F8F8F8;">



<form id="frmAssignToClass" runat="server" style="margin:0px; border:0px;">
        <div>
            


     <div id="NavBarDiv"><!-- NavBar -->
            <nav class="navbar navbar-expand-lg navbar-light bg-white">
                <a class="navbar-brand">
                    <img src="Media/SCHOOLMATE-01.jpg" height="60" width="60" alt=""/>
                </a> 
                <ul class="navbar-nav">
			        <li class="nav-item">
				        <a class="navbar-brand" href="Teacher_Home.aspx">Home</a>
			        </li>
			        <li class="nav-item dropdown">
                        <%--<a aria-expanded="false" aria-haspopup="true" class="nav-link dropdown-toggle text-white" data-toggle="dropdown" href="#" id="navHWDropDown" role="button">Homework</a>--%>
                        <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">Homework</a>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="TeacherCreateHW.aspx">Create Homework</a>
                            <a class="dropdown-item" href="Teacher_View_All_Homework.aspx">View Homework Templates</a>
                            <a class="dropdown-item" href="Teacher_Homework_Assign.aspx">Allocate Homework</a>
                            <a class="dropdown-item" href="Teacher_Home.aspx">View Completed Homework</a>
                        </div>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right" style="margin-left:75%">
                    <li >
                        <asp:button id="btnLogout" runat="server" class="btn btn-outline-danger" OnClick="btnLogout_Click" Text="Logout"></asp:button>
                    </li>
                </ul>
            </nav>
        </div>


                <%--<asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [ClassID], [ClassTeacherID], [ClassSubject], [ClassYearGroup], [ClassName] FROM [Class] ORDER BY [ClassName] DESC"></asp:SqlDataSource>--%>
                <%--<asp:SqlDataSource ID="ViewAllStudents" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [StudentID], [StudentFirstName], [StudentLastName], [StudentUsername] FROM [Students] ORDER BY [StudentFirstName] DESC, [StudentLastName] DESC"></asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="ViewAllStudents" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT StudentID, StudentFirstName, StudentLastName, StudentUsername FROM Students ORDER BY StudentFirstName DESC, StudentLastName DESC"></asp:SqlDataSource>

            

                <%--<asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [ClassID], [ClassTeacherID], [ClassSubject], [ClassYearGroup], [ClassName] FROM [Class] ORDER BY [ClassName] DESC"></asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM Class ORDER BY ClassName DESC"></asp:SqlDataSource>

                <div class="row" style="width:20%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class*</span><br/>
                    <asp:DropDownList ID="drpSelectClass" runat="server" DataSourceID="ViewAllClasses" DataTextField="ClassName" DataValueField="ClassID" class="custom-select"></asp:DropDownList>
                    <asp:Button ID="btnSelectClass" runat="server" Text="Select" OnClick="btnSelectClass_Click"/>
                </div>
                
                <br/>

                <!-- students in selected class -->
                <!-- select student.username, student.name, StudentsInClass.ClassID from student join studentsInClass where (selected ClassID) == StudentsInClass.ClassID -->
                
                <!-- students not in selected class -->
                <!-- select student.username, student.name, StudentsInClass.ClassID from student join studentsInClass where StudentsInClass.ClassID != (selected ClassID) -->
                

                <div id="gridViews">

                <span style="font-weight:bold">Students Not In Selected Class</span><br/>
                <asp:GridView ID="allOtherStudents" DataSourceID="ViewAllStudentsNotInClass" runat="server" DataKeyNames="StudentID" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="StudentID" ReadOnly="true"/>
                        <asp:BoundField DataField="StudentUsername" HeaderText="Student Username" ReadOnly="true" SortExpression="StudentUsername"/>
                        <asp:BoundField DataField="StudentFirstName" HeaderText="Student First Name" ReadOnly="true" SortExpression="StudentFirstName"/>
                        <asp:BoundField DataField="StudentLastName" HeaderText="Student Last Name" ReadOnly="true" SortExpression="StudentLastName"/>
                        <asp:BoundField DataField="StudentDOB" HeaderText="Student DOB" ReadOnly="true" SortExpression="StudentDOB"/>
                        <%--<asp:ButtonField HeaderText="Add Student to class" Text="Add" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Add Student To Class" ShowHeader="True" Text="Add" ItemStyle-HorizontalAlign="Center" />--%>
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" HeaderText="Add Student To Class" ShowHeader="True" Text="Add" ItemStyle-HorizontalAlign="Center" CommandArgument="Container.DataItemIndex" />  <%--CommandArgument="Container.DataItemIndex"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView><br/><br/>
                
                <span style="font-weight:bold">Students In Selected Class</span><br/>
                <asp:GridView ID="allStudentsInClass" DataSourceID="ViewAllStudentsInClass" runat="server" DataKeyNames="StudentID" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="StudentID" ReadOnly="true"/>
                        <asp:BoundField DataField="StudentUsername" HeaderText="Student Username" ReadOnly="true" SortExpression="StudentUsername"/>
                        <asp:BoundField DataField="StudentFirstName" HeaderText="Student First Name" ReadOnly="true" SortExpression="StudentFirstName"/>
                        <asp:BoundField DataField="StudentLastName" HeaderText="Student Last Name" ReadOnly="true" SortExpression="StudentLastName"/>
                        <asp:BoundField DataField="StudentDOB" HeaderText="Student DOB" ReadOnly="true" SortExpression="StudentDOB"/>
                        <%--<asp:ButtonField HeaderText="Remove Student from class" Text="Remove" />--%>
                        <%--<asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Remove Student From Class" ShowHeader="True" Text="Remove" ItemStyle-HorizontalAlign="Center" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>                                
                                <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" CommandName="Select" HeaderText="Remove Student From Class" ShowHeader="True" Text="Remove" ItemStyle-HorizontalAlign="Center" /> <%--CommandArgument="Container.DataItemIndex"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                </div>

                <asp:SqlDataSource ID="ViewAllStudentsNotInClass" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT StudentID, StudentUsername, StudentFirstName, StudentLastName, StudentDOB FROM Students"></asp:SqlDataSource>
                <asp:SqlDataSource ID="ViewAllStudentsInClass" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT StudentID, StudentUsername, StudentFirstName, StudentLastName, StudentDOB FROM Students"></asp:SqlDataSource>


</div>
            </form>
        
</body>
</html>
