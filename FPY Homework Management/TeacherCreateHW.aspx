<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherCreateHW.aspx.cs" Inherits="FPY_Homework_Management.TeacherCreateHW" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Homework</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <!--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
</head>
<body style="background-color:dimgray">
        <div id="NavBarDiv"><!-- NavBar -->
            <nav class="navbar navbar-expand-lg navbar-light bg-dark">
                <a class="navbar-brand">
                    <img src="Media/SCHOOLMATE-01.jpg" height="60" width="60" alt=""/>
                </a>
                <a class="text-light navbar-brand" href="Teacher_Home.aspx">Home</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>    
                
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="text-light nav-link" href="TeacherCreateHW.aspx">Create Homework</a>
                        </li>
                    </ul>

                </div>

            </nav>
        </div>

    <form id="frmCreateHW" runat="server">
        <div id="coreHWCreate" class="container bg-dark">

            <div style="background-color:dodgerblue; padding:8px;">
            <asp:Label ID="submissionFeedback" runat="server" Text="" Visible="false"></asp:Label><br/>

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
        <div id="coreQCreate" class="container bg-dark">

            <div style="background-color:lightgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle1">Question 1</span><br/>
                <asp:TextBox ID="Qtext1" runat="server" class="form-control" placeholder="Question"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks1" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:darkgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle2">Question 2</span><br/>
                <asp:TextBox ID="Qtext2" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks2" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:lightgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle3">Question 3</span><br/>
                <asp:TextBox ID="Qtext3" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks3" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:darkgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle4">Question 4</span><br/>
                <asp:TextBox ID="Qtext4" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks4" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:lightgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle5">Question 5</span><br/>
                <asp:TextBox ID="Qtext5" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks5" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:darkgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle6">Question 6</span><br/>
                <asp:TextBox ID="Qtext6" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks6" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:lightgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle7">Question 7</span><br/>
                <asp:TextBox ID="Qtext7" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks7" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:darkgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle8">Question 8</span><br/>
                <asp:TextBox ID="Qtext8" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks8" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:lightgray; padding:8px;">
            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span id="qNumTitle9">Question 9</span><br/>
                <asp:TextBox ID="Qtext9" runat="server" class="form-control" placeholder="Question Text"></asp:TextBox>
            </div>

            <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks9" runat="server" class="form-control" placeholder="Marks for question"></asp:TextBox>
            </div><br/>
            </div>

            <div style="background-color:darkgray; padding:8px;">
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

        </div>
        <div class="container">
            <div class="row" style="padding-bottom:50px">
                <asp:Button ID="btnCreateHomework" class="btn btn-primary" Width="100%" runat="server" Text="Create" OnClick="btnCreateHomework_Click"></asp:Button>
            </div>         
        </div>
    </form>




</body>
</html>

<footer style="width:100%; height:80px; background-color:darkgray">



</footer>

