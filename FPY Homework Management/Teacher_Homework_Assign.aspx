﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Homework_Assign.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Homework_Assign" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assign Homework</title>

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
         

    <form id="frmAssignHomework" runat="server" style="margin:0px; border:0px;">

        
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

                    
            <div id="divSuccessMessage" runat="server" class="row alert-success" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px; margin:0px">                
                <asp:label ID="lblSuccessMessage" runat="server" style="font-weight:bold">Homework allocation was successful</asp:label>
            </div>

            <div id="divErrorMessage" runat="server" class="row alert-danger" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px; margin:0px">                
                <asp:label ID="lblErrorMessage" runat="server" style="font-weight:bold">Invalid Input, please check all input fields</asp:label>
            </div>


        <div class="container">

            <%--<asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM Class WHERE TeacherID = (loged in teacher) ORDER BY ClassName DESC"></asp:SqlDataSource>--%>
            <asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM Class ORDER BY ClassName DESC"></asp:SqlDataSource>

            <!-- change datasource to only select classes for the logged in teacher -->
            <div class="row" style="background-color:#e6ffff; padding-left:5%; padding-right:5%; padding-bottom:20px; padding-top:25px">                
                <span style="font-weight:bold">Class*</span><br/>
                <asp:DropDownList ID="drpSelectClass" runat="server" DataSourceID="ViewAllClasses" DataTextField="ClassName" DataValueField="ClassID" class="custom-select"></asp:DropDownList>
                <%--<asp:Button ID="btnSelectClass" runat="server" Text="Select" OnClick="btnSelectClass_Click"/>--%>
            </div>

            

            <asp:SqlDataSource ID="ViewAllHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM CoreHomework ORDER BY HomeworkTitle DESC"></asp:SqlDataSource>

            <div class="row" style="background-color:white; padding-left:5%; padding-right:5%; padding-bottom:20px; padding-top:25px">                
                <span style="font-weight:bold">Homework*</span><br/>
                <asp:DropDownList ID="dropSelectHomework" runat="server" DataSourceID="ViewAllHomework" DataTextField="HomeworkTitle" DataValueField="CoreHomeworkID" class="custom-select"></asp:DropDownList>
                <%--<asp:Button ID="btnSelectHomework" runat="server" Text="Select" OnClick="btnSelectHomework_Click"/>--%>
            </div>


            <div class="row" style="background-color:#e6ffff; padding-left:5%; padding-right:5%; padding-bottom:20px; padding-top:25px">                
                <span style="font-weight:bold">Due Date*</span><br/>
                <asp:TextBox ID="dueDateIn" runat="server" type="date" class="custom-select"></asp:TextBox>
            </div>

            <div class="row" style="padding:0px;">  
                <asp:Button ID="btnAssignHomework" runat="server" Text="Assign Homework" OnClick="btnAssignHomework_Click" CssClass="btn btn-success btn-block" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px"/>
            </div>

        </div>
    </form>
</body>
</html>
