<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Create_Class.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Create_Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>
</head>
<body style="background-color:#F8F8F8;">




<form id="frmCreateClass" runat="server" style="margin:0px; border:0px;">
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



                <h1 id="tCreateClassHeadder">Create a Class</h1>
                <asp:SqlDataSource ID="ViewAllTeachers" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [TeacherID], [TeacherFirstName], [TeacherLastName], [TeacherUsername] FROM [Teachers] ORDER BY [TeacherFirstName] DESC, [TeacherLastName] DESC"></asp:SqlDataSource>


                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class Teacher*</span><br/>
                    <asp:DropDownList ID="drpSelectTeacher" runat="server" DataSourceID="ViewAllTeachers" DataTextField="TeacherUsername" DataValueField="TeacherID" class="custom-select"></asp:DropDownList>
                </div><br/>


                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class Subject*</span><br/>
                    <asp:TextBox ID="classSubjectIn" runat="server" class="form-control" placeholder="Subject" ></asp:TextBox>
                </div><br/>


	            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class Year Group*</span><br/>
                    <asp:TextBox ID="classYearGroupIn" runat="server" class="form-control" placeholder="Year Group" ></asp:TextBox>
                </div><br/>


                <asp:Button ID="btnCreateClass" class="btn btn-primary" Width="100%" runat="server" Text="Create" OnClick="btnCreateClass_Click"></asp:Button>

 </div>
            </form>
       
</body>
</html>
