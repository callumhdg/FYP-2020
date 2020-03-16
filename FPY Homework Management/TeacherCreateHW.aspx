<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherCreateHW.aspx.cs" Inherits="FPY_Homework_Management.TeacherCreateHW" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Homework</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <!--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
</head>
<body>
        <div id="NavBarDiv"><!-- NavBar -->
            <nav class="navbar navbar-expand-lg navbar-light bg-dark">
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
        <div id="coreHWCreate" class="container">

            <div class="row">
                <!-- homework title -->
                <span>Homework Title</span><br/>
                <asp:TextBox ID="CoreHomeworkTitleInput" runat="server" placeholder="Title"></asp:TextBox>
            </div>

            <div class="row">
                <!-- minutes to complete -->
                <span>Time to complete (minutes)</span><br/>
                <asp:TextBox ID="minutesToCompleteInput" runat="server" placeholder="Minutes to Complete"></asp:TextBox>
            </div>         

        </div>
        <div id="coreQCreate" class="container">

            <!-- question text -->
            <div class="row">
                <span id="qNumTitle">Question 1</span><br/>
                <asp:TextBox ID="Qtext"runat="server" placeholder="Question"></asp:TextBox>
            </div>

            <!-- question max marks -->
            <div class="row">
                <span>Question Marks</span><br/>
                <asp:TextBox ID="QMaxMarks"runat="server" placeholder="Marks for question"></asp:TextBox>
            </div>

            <asp:Button id="addQuestion" Text="Add Question" runat="server"></asp:Button>

        </div>
    </form>




</body>
</html>
