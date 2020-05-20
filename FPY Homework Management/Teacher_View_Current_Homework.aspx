<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_View_Current_Homework.aspx.cs" Inherits="FPY_Homework_Management.Teacher_View_Current_Homework" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Issued Homework</title>
        
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

<form id="frmViewIssuedHomework" runat="server" style="margin:0px; border:0px;">

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


    
        <div style="margin-bottom:40px">



            <div id="q1Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle1"><b>Question 1:</b> </label><br/>
                    <label id="q1Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 1 Answer</span>
                    <asp:TextBox ID="txtQ1StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks1" runat="server">Question 1 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 1 Marks*</b></span>
                    <asp:TextBox ID="txtQ1Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 1 Feedback</span>
                    <asp:TextBox ID="txtQ1Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>


            <div id="q2Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle2"><b>Question 2:</b> </label><br/>
                    <label id="q2Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 2 Answer</span>
                    <asp:TextBox ID="txtQ2StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks2" runat="server">Question 2 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 2 Marks*</b></span>
                    <asp:TextBox ID="txtQ2Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 2 Feedback</span>
                    <asp:TextBox ID="txtQ2Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>



            <div id="q3Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle3"><b>Question 3:</b> </label><br/>
                    <label id="q3Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 3 Answer</span>
                    <asp:TextBox ID="txtQ3StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks3" runat="server">Question 3 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 3 Marks*</b></span>
                    <asp:TextBox ID="txtQ3Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 3 Feedback</span>
                    <asp:TextBox ID="txtQ3Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>



            <div id="q4Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle4"><b>Question 4:</b> </label><br/>
                    <label id="q4Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 4 Answer</span>
                    <asp:TextBox ID="txtQ4StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks4" runat="server">Question 4 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 4 Marks*</b></span>
                    <asp:TextBox ID="txtQ4Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 4 Feedback</span>
                    <asp:TextBox ID="txtQ4Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>



            <div id="q5Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle5"><b>Question 5:</b> </label><br/>
                    <label id="q5Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 5 Answer</span>
                    <asp:TextBox ID="txtQ5StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks5" runat="server">Question 5 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 5 Marks*</b></span>
                    <asp:TextBox ID="txtQ5Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 5 Feedback</span>
                    <asp:TextBox ID="txtQ5Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>



            <div id="q6Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle6"><b>Question 6:</b> </label><br/>
                    <label id="q6Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 6 Answer</span>
                    <asp:TextBox ID="txtQ6StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks6" runat="server">Question 6 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 6 Marks*</b></span>
                    <asp:TextBox ID="txtQ6Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 6 Feedback</span>
                    <asp:TextBox ID="txtQ6Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>



            <div id="q7Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle7"><b>Question 7:</b> </label><br/>
                    <label id="q7Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 7 Answer</span>
                    <asp:TextBox ID="txtQ7StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks7" runat="server">Question 7 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 7 Marks*</b></span>
                    <asp:TextBox ID="txtQ7Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 7 Feedback</span>
                    <asp:TextBox ID="txtQ7Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>



            <div id="q8Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle8"><b>Question 8:</b> </label><br/>
                    <label id="q8Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 8 Answer</span>
                    <asp:TextBox ID="txtQ8StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks8" runat="server">Question 8 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 8 Marks*</b></span>
                    <asp:TextBox ID="txtQ8Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 8 Feedback</span>
                    <asp:TextBox ID="txtQ8Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>



            <div id="q9Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle9"><b>Question 9:</b> </label><br/>
                    <label id="q9Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 9 Answer</span>
                    <asp:TextBox ID="txtQ9StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks9" runat="server">Question 9 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 9 Marks*</b></span>
                    <asp:TextBox ID="txtQ9Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 9 Feedback</span>
                    <asp:TextBox ID="txtQ9Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>



            <div id="q10Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px">
                    <label id="qNumTitle10"><b>Question 10:</b> </label><br/>
                    <label id="q10Text" runat="server"></label><br/>
                </div>                               

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 10 Answer</span>
                    <asp:TextBox ID="txtQ10StudentAnswer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-top:30px; padding-bottom:10px; margin:0px">
                    <span id="QMaxMarks10" runat="server">Question 10 Marks: </span>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">                    
                    <span><b>Quesion 10 Marks*</b></span>
                    <asp:TextBox ID="txtQ10Marks" runat="server" class="form-control" placeholder="Question marks"></asp:TextBox>
                </div><br/>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; margin:0px">
                    <span>Quesion 10 Feedback</span>
                    <asp:TextBox ID="txtQ10Feedback" runat="server" class="form-control" placeholder="Feedback"></asp:TextBox>
                </div><br/>
            </div>


                                 
            <div class="container" style="padding:8px;">                
                <asp:Button ID="btnSubmitMarkedHomework" runat="server" Text="Submit" OnClick="btnSubmitMarkedHomework_Click" CssClass="btn btn-success btn-block" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px"/>
            </div>
        </div>
    </form>
</body>
</html>
