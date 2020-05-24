<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Home.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Home" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
        
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
  
</head>
<body style="background-color:#F8F8F8">

<form id="frmViewIssuedHomework" runat="server" style="margin:0px; border:0px;">

    
    <!-- NavBar -->
    <div id="NavBarDiv">
        <nav class="navbar navbar-expand-lg navbar-light bg-white">
            <a class="navbar-brand">
                <img src="Media/SCHOOLMATE-01.jpg" height="60" width="60" alt=""/>
            </a> 
            <ul class="navbar-nav">
		    <li class="nav-item">
		        <a class="navbar-brand" href="Teacher_Home.aspx">Home</a>
			</li>
			<li class="nav-item dropdown">                        
                <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">Homework</a>
                <div class="dropdown-menu">
                    <a class="dropdown-item" href="TeacherCreateHW.aspx">Create Homework</a>
                    <a class="dropdown-item" href="Teacher_View_All_Homework.aspx">View Homework Templates</a>
                    <a class="dropdown-item" href="Teacher_Homework_Assign.aspx">Allocate Homework</a>
                    <a class="dropdown-item" href="Teacher_Home.aspx">View Completed Homework</a>
                </div>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbardrop1" data-toggle="dropdown">Classes</a>
                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="Teacher_Create_Class.aspx">Create A Class</a>
                        <a class="dropdown-item" href="Teacher_Assign_Students_To_Class.aspx">Assign Students To Class</a>
                    </div>
                </li>
            </ul>
            <ul class="nav navbar-nav navbar-right" style="margin-left:75%">
                <li>
                    <asp:button id="btnLogout" runat="server" class="btn btn-outline-danger" OnClick="btnLogout_Click" Text="Logout"></asp:button>
                </li>
            </ul>
        </nav>
    </div>
       

        <div style="margin-left:3%; margin-bottom:5%; margin-top:3%; margin-right:3%; width:70%;">
            
                
                <asp:SqlDataSource ID="listDueHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM IssuedHomework WHERE DueDate < CURRENT_TIMESTAMP AND SetByTeacherID = 1"></asp:SqlDataSource>


                <!-- only shows homework after due date -->
                <asp:GridView ID="viewIssuedHomework" runat="server" DataSourceID="listDueHomework" DataKeyNames="IssuedHomeworkID" AutoGenerateColumns="false" RowStyle-BackColor="White" HeaderStyle-BackColor="White">
                    <Columns>
                        <asp:BoundField DataField="IssuedHomeworkID" ReadOnly="true"/>
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" ReadOnly="true"/>
                        <asp:BoundField DataField="SubmissionDate" HeaderText="Submission Date" ReadOnly="true"/>


                        <asp:TemplateField>
                            <ItemTemplate>                                
                                <asp:Button ID="btnSelectHomework" runat="server" CssClass="btn-primary" HeaderText="Select Homework" OnClick="btnSelectHomework_Click" ShowHeader="True" Text="Select" ItemStyle-HorizontalAlign="Center" CommandArgument="Container.DataItemIndex"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>






            </div>
            </form>
        
</body>
</html>
