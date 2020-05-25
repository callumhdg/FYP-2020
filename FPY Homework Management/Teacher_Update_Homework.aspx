<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Update_Homework.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Update_Homework" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Homework</title>

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
    
    <form id="frmUpdateHomework" runat="server" style="margin:0px; border:0px;">

        
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

             
        <div style="margin-bottom:40px">


            <div runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row" style="margin-top:8px">
                        <span id="lblHomeworkTitle"><b>Homework Title*</b></span><br/>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtHomeworkTitle" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
                        <span id="lblHomeworkDuration"><b>Homework time to complete (Minutes)*</b></span><br/>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtHomeworkDuration" runat="server" class="form-control"></asp:TextBox>
                    </div>

                </div>
            </div>



	        <div id="q1Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 1:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ1Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 1 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ1Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



            <div id="q2Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 2:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ2Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 2 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ2Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



	        <div id="q3Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 3:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ3Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 3 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ3Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



	        <div id="q4Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 4:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ4Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 4 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ4Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



	        <div id="q5Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 5:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ5Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 5 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ5Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



	        <div id="q6Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 6:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ6Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 16 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ6Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



	        <div id="q7Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 7:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ7Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 7 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ7Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



	        <div id="q8Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 8:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ8Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 8 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ8Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



	        <div id="q9Conainer" runat="server" class="container" style="background-color:white; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 9:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ9Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 9 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ9Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



	        <div id="q10Conainer" runat="server" class="container" style="background-color:#e6ffff; padding:8px;">
                <div class="container" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:12px; margin-left:0px; margin-right:0px; margin-top:8px">
                    
                    <div class="row">
                        <span><b>Question 10:</b></span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ10Text" runat="server" class="form-control"></asp:TextBox>
                    </div>


                    <div class="row" style="margin-top:8px">
		                <span><b>Question 10 Marks:</b> </span>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="txtQ10Marks" runat="server" class="form-control"></asp:TextBox>                    
                    </div>
		        </div>
            </div>



            <div class="container" style="padding:0px; margin-top:20px">                
                <asp:Button ID="btnUpdateHomework" runat="server" Text="Update" OnClick="btnUpdateHomework_Click" CssClass="btn btn-success btn-block" style="width:100%; padding-left:5%; padding-right:5%; margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:8px"/>
            </div>
                    
            
            <div class="container alert-danger" style="padding:8px; margin-top:40px;">  
                <span style="width:100%"><b>WARNING. Deleting this homework will delete any issued homework deriving from this original version.</b></span>
                <div class="container alert-danger" style="padding-left:40%; padding-right:40%; margin-bottom:20px">
                    <asp:Button ID="btnDeleteHomework" runat="server" Text="Delete" OnClick="btnDeleteHomework_Click" CssClass="btn btn-danger btn-block" style="text-align:center; width:100%; margin-bottom:0px; margin-top:8px;"/>
                </div>
            </div>

            
        </div>
               
        
    </form>
</body>
</html>
