<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Home.aspx.cs" Inherits="FPY_Homework_Management.Student_Home" %>

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
<body style="background-color:#F8F8F8;">

    <form id="frmStudentHome" runat="server" style="margin:0px; border:0px;">

    <div id="NavBarDiv"><!-- NavBar -->
            <nav class="navbar navbar-expand-lg navbar-light bg-white">
                <a class="navbar-brand">
                    <img src="Media/SCHOOLMATE-01.jpg" height="60" width="60" alt=""/>
                </a>
                <%--<a class="navbar-brand" href="Student_Home.aspx">Home</a>--%>
                <%--<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>  --%>  
                <ul class="nav navbar-nav navbar-right" style="margin-left:90%">
                    <asp:button id="btnLogout" runat="server" class="btn btn-outline-danger " OnClick="btnLogout_Click" Text="Logout"></asp:button>
                </ul>
            </nav>
        </div>
       

        <div id="displayHomework" runat="server" class="container" style="margin-left:3%; margin-bottom:5%; margin-top:3%; margin-right:3%; width:70%;">
            <%--<form id="frmStudentHome" runat="server" class="container" style="margin-left:3%; margin-bottom:5%; margin-top:3%; margin-right:3%; width:70%;">--%>
                

                <%--<asp:SqlDataSource ID="listCurrentHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM IssuedHomework WHERE StudentID = (logged in student) AND DueDate > (CURDATE(), INTERVAL 1 DAY)"></asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="listCurrentHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM IssuedHomework WHERE DueDate > (CURDATE(), INTERVAL 1 DAY)"></asp:SqlDataSource>
                <%-- SELECT * FROM IssuedHomework WHERE DueDate >= CURRENT_TIMESTAMP; --%>
                <%--<span style="font-weight:bold; text-decoration: underline; background-color:white">Current Homework</span><br/>--%>
                <span style="font-weight:bold; text-decoration: underline;">Current Homework</span><br/>
                
                
                <div id="activeHomework" runat="server">
                <!-- submited yes/no -->
                <asp:GridView ID="selectActiveHomework" DataSourceID="listCurrentHomework" runat="server" DataKeyNames="IssuedHomeworkID" AutoGenerateColumns="false"  RowStyle-BackColor="White" HeaderStyle-BackColor="White">
                    <Columns>
                        <asp:BoundField DataField="IssuedHomeworkID" ReadOnly="true"/>
                        <%--<asp:BoundField- DataField="StudentID" ReadOnly="true" Visible="false"/>--%>
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" ReadOnly="true"/>
                        <asp:BoundField DataField="TimeToComplete" HeaderText="Estemated Homework Duration" ReadOnly="true"/>
                        
                        <asp:TemplateField>
                            <ItemTemplate>                                
                                <asp:Button ID="btnSelectDueHomework" runat="server" CssClass="btn-primary" OnClick="btnSelectDueHomework_Click" HeaderText="Select Homework" ShowHeader="True" Text="Select" ItemStyle-HorizontalAlign="Center" CommandArgument="Container.DataItemIndex"/> <%--CommandName="Select"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView> <br/>
                </div>


                <div id="overdueHomework" runat="server">
                <asp:SqlDataSource ID="listOverdueHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM IssuedHomework"></asp:SqlDataSource>
                <!-- (graded homework) - SELECT UNIQUE IssuedHomeworkID FROM QuestionsToAnswer WHERE Results != NULL -->
                <%--<span style="font-weight:bold; text-decoration: underline; background-color:white">Previous Homework</span><br/>--%>
                <span style="font-weight:bold; text-decoration: underline;">Overdue Homework</span><br/>
                <asp:GridView ID="selectPastHomework" DataSourceID="listOverdueHomework" runat="server" DataKeyNames="IssuedHomeworkID" AutoGenerateColumns="false" RowStyle-BackColor="White" HeaderStyle-BackColor="White">
                    <Columns>
                        <asp:BoundField DataField="IssuedHomeworkID" ReadOnly="true"/>
                        <%--<asp:BoundField DataField="StudentID" ReadOnly="true" Visible="false"/>--%>
                        <%--<asp:BoundField DataField="DueDate" HeaderText="Due Date" ReadOnly="true"/>--%>
                        <%--<asp:BoundField DataField="TimeToComplete" HeaderText="Estemated Homework Duration" ReadOnly="true"/>--%>
                        <asp:TemplateField>
                            <ItemTemplate>                                
                                <asp:Button ID="btnViewMarkedHomework" runat="server" CssClass="btn-primary" CommandName="Select" OnClick="btnSelectDueHomework_Click" HeaderText="Select Homework" ShowHeader="True" Text="Select" ItemStyle-HorizontalAlign="Center" /> <%--CommandArgument="Container.DataItemIndex"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    </div>


                <div id="markedHomework" runat="server">
                <asp:SqlDataSource ID="listMarkedHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM IssuedHomework"></asp:SqlDataSource>
                <!-- (graded homework) - SELECT UNIQUE IssuedHomeworkID FROM QuestionsToAnswer WHERE Results != NULL -->
                <%--<span style="font-weight:bold; text-decoration: underline; background-color:white">Previous Homework</span><br/>--%>
                <span style="font-weight:bold; text-decoration: underline;">Marked Homework</span><br/>
                <asp:GridView ID="selectMarkedHomework" DataSourceID="listMarkedHomework" runat="server" DataKeyNames="IssuedHomeworkID" AutoGenerateColumns="false" RowStyle-BackColor="White" HeaderStyle-BackColor="White">
                    <Columns>
                        <asp:BoundField DataField="IssuedHomeworkID" ReadOnly="true"/>
                        <%--<asp:BoundField DataField="StudentID" ReadOnly="true" Visible="false"/>--%>
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" ReadOnly="true"/>
                        <asp:BoundField DataField="TimeToComplete" HeaderText="Estemated Homework Duration" ReadOnly="true"/>
                        <asp:TemplateField>
                            <ItemTemplate>                                
                                <asp:Button ID="btnSelectOldHomework" runat="server" CssClass="btn-primary" OnClick="btnViewMarkedHomework_Click" CommandName="Select" HeaderText="Select Homework" ShowHeader="True" Text="Select" ItemStyle-HorizontalAlign="Center" /> <%--CommandArgument="Container.DataItemIndex"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    </div>

            </div>
            </form>
        
</body>
</html>
