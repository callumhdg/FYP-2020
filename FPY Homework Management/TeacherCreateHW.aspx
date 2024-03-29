﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherCreateHW.aspx.cs" Inherits="FPY_Homework_Management.TeacherCreateHW" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Homework</title>

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

<form id="frmCreateHW" runat="server" style="margin:0px; border:0px;">

    
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
                <asp:label ID="lblSuccessMessage" runat="server" style="font-weight:bold">Homework creation successful</asp:label>
            </div>

            <div id="divErrorMessage" runat="server" class="row alert-danger" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px; margin:0px">                
                <asp:label ID="lblErrorMessage" runat="server" style="font-weight:bold">Invalid Input, please check all input fields</asp:label>
            </div>
    

        <div id="coreHWCreate" class="container">

            <div style="background-color:#e6ffff; padding:8px;">
            <%--<asp:Label ID="submissionFeedback" runat="server" Text="" Visible="false"></asp:Label><br/>--%>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px">
                <!-- homework title -->
                <span style="font-weight:bold">Homework Title*</span><br/>
                <asp:TextBox ID="CoreHomeworkTitleInput" runat="server" class="form-control" placeholder="Title" OnTextChanged="CoreHomeworkTitleInput_TextChanged"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <!-- minutes to complete -->
                <span style="font-weight:bold">Time to complete (minutes)*</span><br/>
                <asp:TextBox ID="minutesToCompleteInput" runat="server" class="form-control" placeholder="Minutes to Complete" OnTextChanged="minutesToCompleteInput_TextChanged"></asp:TextBox>
            </div><br/><br/>        
            </div>
        </div>
        <div id="coreQCreate" class="container">

            <div style="background-color:white; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle1">Question 1</span><br/>
                <asp:TextBox ID="Qtext1" runat="server" class="form-control" placeholder="Question"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks1" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:#e6ffff; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle2">Question 2</span><br/>
                <asp:TextBox ID="Qtext2" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks2" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:white; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle3">Question 3</span><br/>
                <asp:TextBox ID="Qtext3" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks3" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:#e6ffff; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle4">Question 4</span><br/>
                <asp:TextBox ID="Qtext4" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks4" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:white; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle5">Question 5</span><br/>
                <asp:TextBox ID="Qtext5" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks5" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:#e6ffff; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle6">Question 6</span><br/>
                <asp:TextBox ID="Qtext6" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks6" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:white; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle7">Question 7</span><br/>
                <asp:TextBox ID="Qtext7" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks7" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:#e6ffff; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle8">Question 8</span><br/>
                <asp:TextBox ID="Qtext8" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks8" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:white; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle9">Question 9</span><br/>
                <asp:TextBox ID="Qtext9" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks9" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:#e6ffff; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle10">Question 10</span><br/>
                <asp:TextBox ID="Qtext10" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks10" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>
                                                               
            <%--<asp:Button class="btnAddQuestion btn" id="btnAddQuestion" Text="Add Question" runat="server"></asp:Button>

            <div id="questionWrapper" class="wrapper">
            </div>--%>

        <%--</div>
        <div class="container">--%>
            <div class="row" style="padding-bottom:50px; margin-left:0px; margin-right:0px">
                <asp:Button ID="btnCreateHomework" class="btn btn-success btn-block" runat="server" Text="Create" OnClick="btnCreateHomework_Click" Style="margin-top:8px;"></asp:Button>
            </div>         
        </div>
    </form>




</body>
</html>


