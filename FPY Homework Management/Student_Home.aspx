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
<body>
        <div id="displayHomework">
            <form id="frmStudentHome" runat="server">
                

                <%--<asp:SqlDataSource ID="listCurrentHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM IssuedHomework WHERE StudentID = (logged in student) AND DueDate > (CURDATE(), INTERVAL 1 DAY)"></asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="listCurrentHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM IssuedHomework WHERE DueDate > (CURDATE(), INTERVAL 1 DAY)"></asp:SqlDataSource>
                <%-- SELECT * FROM IssuedHomework WHERE DueDate >= CURRENT_TIMESTAMP; --%>

                <span style="font-weight:bold">Current Homework</span><br/>
                <asp:GridView ID="selectActiveHomework" DataSourceID="listCurrentHomework" runat="server" DataKeyNames="IssuedHomeworkID" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="IssuedHomeworkID" ReadOnly="true" Visible="false"/>
                        <asp:BoundField DataField="StudentID" ReadOnly="true" Visible="false"/>
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" ReadOnly="true"/>
                        <asp:BoundField DataField="TimeToComplete" HeaderText="Estemated Homework Duration" ReadOnly="true"/>
                        <asp:TemplateField>
                            <ItemTemplate>                                
                                <asp:Button ID="btnSelectDueHomework" runat="server" OnClick="btnSelectDueHomework_Click" CommandName="Select" HeaderText="Select Homework" ShowHeader="True" Text="Select" ItemStyle-HorizontalAlign="Center" /> <%--CommandArgument="Container.DataItemIndex"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView> <br/>



                <asp:SqlDataSource ID="listPreviousHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM IssuedHomework WHERE StudentID = (logged in student) AND DueDate is before today"></asp:SqlDataSource>
                <!-- (graded homework) - SELECT UNIQUE IssuedHomeworkID FROM QuestionsToAnswer WHERE Results != NULL -->

                <span style="font-weight:bold">Previous Homework</span><br/>
                <asp:GridView ID="selectPastHomework" DataSourceID="listPreviousHomework" runat="server" DataKeyNames="IssuedHomeworkID" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="IssuedHomeworkID" ReadOnly="true" Visible="false"/>
                        <asp:BoundField DataField="StudentID" ReadOnly="true" Visible="false"/>
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" ReadOnly="true"/>
                        <asp:BoundField DataField="TimeToComplete" HeaderText="Estemated Homework Duration" ReadOnly="true"/>
                        <asp:TemplateField>
                            <ItemTemplate>                                
                                <asp:Button ID="btnSelectOldHomework" runat="server" OnClick="btnSelectOldHomework_Click" CommandName="Select" HeaderText="Select Homework" ShowHeader="True" Text="Select" ItemStyle-HorizontalAlign="Center" /> <%--CommandArgument="Container.DataItemIndex"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



            
            </form>
        </div>
</body>
</html>
