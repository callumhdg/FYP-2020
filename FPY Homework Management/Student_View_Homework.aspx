<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_View_Homework.aspx.cs" Inherits="FPY_Homework_Management.Student_View_Homework" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homework</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
  
</head>
<body>
    <form id="frmCompleteHomework" runat="server">

        <div id="studentHomeworkView" class="container">

        <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px">
                <!-- homework title -->
            <span id="homeworkTitle" runat="server" style="font-weight:bold">Homework</span><br/>
        </div>

        <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                <!-- minutes to complete -->
            <span id="timeEstemate" runat="server" style="font-weight:bold">This homework should take  minutes to complete</span><br/>
        </div><br/><br/>        

        </div>
        <div id="viewQuestions" class="container">

            
            <div id="q1Conainer" runat="server" class="container" style="background-color:lightgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle1">Question 1: </span><br/>
                    <span id="q1Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ1Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks1" runat="server">Question 1 Marks: </span><br/>
                </div><br/>
            </div>
            

            <div id="q2Conainer" runat="server" class="container" style="background-color:darkgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle2">Question 2: </span><br/>
                    <span id="q2Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ2Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks2" runat="server">Question 2 Marks: </span><br/>
                </div><br/>
            </div>


            <div id="q3Conainer" runat="server" class="container" style="background-color:lightgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle3">Question 3: </span><br/>
                    <span id="q3Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ3Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks3" runat="server">Question 3 Marks: </span><br/>
                </div><br/>
            </div>
            

            <div id="q4Conainer" runat="server" class="container" style="background-color:darkgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle4">Question 4: </span><br/>
                    <span id="q4Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ4Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks4" runat="server">Question 4 Marks: </span><br/>
                </div><br/>
            </div>

            <div id="q5Conainer" runat="server" class="container" style="background-color:lightgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle5">Question 5: </span><br/>
                    <span id="q5Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ5Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks5" runat="server">Question 5 Marks: </span><br/>
                </div><br/>
            </div>
            

            <div id="q6Conainer" runat="server" class="container" style="background-color:darkgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle6">Question 6: </span><br/>
                    <span id="q6Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width: 100%; padding-left: 5%; padding-right: 5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ6Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks6" runat="server">Question 6 Marks: </span><br/>
                </div><br/>
            </div>

            <div id="q7Conainer" runat="server" class="container" style="background-color:lightgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle7">Question 7: </span><br/>
                    <span id="q7Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ7Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks7" runat="server">Question 7 Marks: </span><br/>
                </div><br/>
            </div>
            

            <div id="q8Conainer" runat="server" class="container" style="background-color:darkgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle8">Question 8: </span><br/>
                    <span id="q8Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ8Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks8" runat="server">Question 8 Marks: </span><br/>
                </div><br/>
            </div>

            <div id="q9Conainer" runat="server" class="container" style="background-color:lightgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle9">Question 9: </span><br/>
                    <span id="q9Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ9Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks9" runat="server">Question 9 Marks: </span><br/>
                </div><br/>
            </div>
            

            <div id="q10Conainer" runat="server" class="container" style="background-color:darkgray; padding:8px;">
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="qNumTitle10">Question 10: </span><br/>
                    <span id="q10Text" runat="server"></span><br/>
                </div>

                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <%--<span>Answer here</span><br/>--%>
                    <asp:TextBox ID="txtQ10Answer" runat="server" class="form-control" placeholder="Answer here"></asp:TextBox>
                </div><br/>
            
                <div class="row" style="width:100%; padding-left:5%; padding-right:5%">
                    <span id="QMaxMarks10" runat="server">Question 10 Marks: </span><br/>
                </div><br/>
            </div>

            <asp:Button ID="btnSubmitHomework" runat="server" Text="Submit" OnClick="btnSubmitHomework_Click" />

        </div>
    </form>
</body>
</html>
