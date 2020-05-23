<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Create_Student.aspx.cs" Inherits="FPY_Homework_Management.Admin_Create_Student" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Student</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
        
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
</head>
<body style="background-color:#F8F8F8;">
    <%--<div>--%>

    <form id="frmCreateStudent" runat="server" style="margin:0px; border:0px;">

        <div id="NavBarDiv"><!-- NavBar -->
            <nav class="navbar navbar-expand-lg navbar-light bg-white">
                <a class="navbar-brand">
                    <img src="Media/SCHOOLMATE-01.jpg" height="60" width="60" alt=""/>
                </a>
                <a class="navbar-brand" href="Admin_Home.aspx">Home</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>    
                
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="Admin_Create_Student.aspx">Create Student</a>
                        </li>
                    </ul>
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="Admin_Create_Teacher.aspx">Create Teacher</a>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right" style="margin-left:80%">
                        <asp:button id="btnLogout" runat="server" class="btn btn-outline-danger " OnClick="btnLogout_Click" Text="Logout"></asp:button>
                    </ul>
                </div>

            </nav>
        </div>



            <div id="divSuccessMessage" runat="server" class="row alert-success" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px; margin:0px">                
                <asp:label ID="lblSuccessMessage" runat="server" style="font-weight:bold">Student creation successful</asp:label>
            </div>

            <div id="divErrorMessage" runat="server" class="row alert-danger" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px; margin:0px">                
                <asp:label ID="lblErrorMessage" runat="server" style="font-weight:bold">Invalid Input, please check all input fields</asp:label>
            </div>


        
        <div style="width:60%; margin-left:20%; margin-right:20%; margin-top:3%;">
                      

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:25px; padding-top:25px; background-color:#e6ffff; margin-left:0px; margin-right:0px;">                
                <span style="font-weight:bold">Student First-Name*</span>
                <asp:TextBox ID="StudentFirstNameIn" runat="server" class="form-control" placeholder="FirstName"></asp:TextBox>
            </div>

	        <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:25px; padding-top:25px; background-color:white; margin-left:0px; margin-right:0px;">                
                <span style="font-weight:bold">Student Last-Name*</span>
                <asp:TextBox ID="StudentLastNameIn" runat="server" class="form-control" placeholder="Surname"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:25px; padding-top:25px; background-color:#e6ffff; margin-left:0px; margin-right:0px;">                
                <span style="font-weight:bold">Student Password*</span>
                <asp:TextBox ID="StudentPasswordIn" runat="server" class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div>
            
            <%--<div class="row" style="width:20%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Due Date*</span><br/>
                <asp:TextBox ID="StudentDateOfBirth" runat="server" placeholder="From" type="date"></asp:TextBox>
            </div>--%>

            <%--<div class="container" style="background-color:white">--%>
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:25px; padding-top:25px; background-color:white; margin-left:0px; margin-right:0px;">
                    <%--<span style="font-weight:bold">Student Date of Birth* (DD/MM/YYYY)</span>
                    <div class="col-sm">
                        <asp:TextBox ID="StudentDateOfBirthDay" runat="server" class="form-control" placeholder="DD"></asp:TextBox>
                    </div>
                    <div class="col-sm">
                        <asp:TextBox ID="StudentDateOfBirthMonth" runat="server" class="form-control" placeholder="MM"></asp:TextBox>
                    </div>
                    <div class="col-sm">
                        <asp:TextBox ID="StudentDateOfBirthYear" runat="server" class="form-control" placeholder="YYYY"></asp:TextBox>
                    </div>--%>

                    <span style="font-weight:bold">Date of Birth*</span>
                    <asp:TextBox ID="dobIn" runat="server" class="form-control" placeholder="From" type="date"></asp:TextBox>


                </div>
            <%--</div>--%>
            
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:25px; padding-top:25px; background-color:#e6ffff; margin-left:0px; margin-right:0px;">                
                <span style="font-weight:bold">Parent Email Address</span>
                <asp:TextBox ID="StudentParEmailIn" runat="server" class="form-control" placeholder="Parent Email" ></asp:TextBox>
            </div>


            <asp:Button ID="btnCreateStudent" class="btn btn-success" Width="100%" runat="server" Text="Create" OnClick="btnCreateStudent_Click" Style="margin-top:18px; margin-left:0px; margin-right:0px;"></asp:Button>



        </div>
    </form>
    <%--</div>--%>
</body>
</html>