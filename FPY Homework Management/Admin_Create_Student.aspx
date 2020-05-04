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
<body style="background-color:lightgray">
    <%--<div>--%>



        <div id="NavBarDiv"><!-- NavBar -->
            <nav class="navbar navbar-expand-lg navbar-light bg-dark">
                <a class="navbar-brand">
                    <img src="Media/SCHOOLMATE-01.jpg" height="60" width="60" alt=""/>
                </a>
                <a class="text-light navbar-brand" href="Admin_Home.aspx">Home</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>    
                
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="text-light nav-link" href="Admin_Create_Student.aspx">Create Student</a>
                        </li>
                    
                        <li class="nav-item active">
                            <a class="text-light nav-link" href="Admin_Create_Teacher.aspx">Create Teacher</a>
                        </li>
                    </ul>

                </div>

            </nav>
        </div>


            <div id="divSuccessMessage" runat="server" class="row alert-success" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px; margin:0px">                
                <asp:label ID="lblSuccessMessage" runat="server" style="font-weight:bold">Student creation successful</asp:label>
            </div><br/>

            <div id="divErrorMessage" runat="server" class="row alert-danger" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px; margin:0px">                
                <asp:label ID="lblErrorMessage" runat="server" style="font-weight:bold">Invalid Input, please check all input fields</asp:label>
            </div><br/>


        <form id="frmCreateStudent" runat="server">
        <div>
                      

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Student First-Name*</span><br/>
                <asp:TextBox ID="StudentFirstNameIn" runat="server" class="form-control" placeholder="FirstName"></asp:TextBox>
            </div><br/>

	        <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Student Last-Name*</span><br/>
                <asp:TextBox ID="StudentLastNameIn" runat="server" class="form-control" placeholder="Surname"></asp:TextBox>
            </div><br/>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Student Password*</span><br/>
                <asp:TextBox ID="StudentPasswordIn" runat="server" class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div><br/>
            
            <%--<div class="row" style="width:20%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Due Date*</span><br/>
                <asp:TextBox ID="StudentDateOfBirth" runat="server" placeholder="From" type="date"></asp:TextBox>
            </div>--%>

            <div class="container" style="background-color:white">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">
                    <span style="font-weight:bold">Student Date of Birth* (DD/MM/YYYY)</span><br/>
                    <div class="col-sm">
                        <asp:TextBox ID="StudentDateOfBirthDay" runat="server" class="form-control" placeholder="DD"></asp:TextBox>
                    </div>
                    <div class="col-sm">
                        <asp:TextBox ID="StudentDateOfBirthMonth" runat="server" class="form-control" placeholder="MM"></asp:TextBox>
                    </div>
                    <div class="col-sm">
                        <asp:TextBox ID="StudentDateOfBirthYear" runat="server" class="form-control" placeholder="YYYY"></asp:TextBox>
                    </div>
                </div><br/>
            </div>
            
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Parent Email Address</span><br/>
                <asp:TextBox ID="StudentParEmailIn" runat="server" class="form-control" placeholder="Parent Email" ></asp:TextBox>
            </div><br/><br/>


            <asp:Button ID="btnCreateStudent" class="btn btn-primary" Width="100%" runat="server" Text="Create" OnClick="btnCreateStudent_Click"></asp:Button>



        </div>
    </form>
    <%--</div>--%>
</body>
</html>