<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Homework_Assign.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Homework_Assign" %>

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
<body>
    <form id="frmAssignHomework" runat="server">
        <div>

            <div id="divSuccessMessage" runat="server" class="row alert-success" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px; margin:0px">                
                <asp:label ID="lblSuccessMessage" runat="server" style="font-weight:bold">Homework was allocated successfully</asp:label>
            </div><br/>

            <%--<asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM Class WHERE TeacherID = (loged in teacher) ORDER BY ClassName DESC"></asp:SqlDataSource>--%>
            <asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM Class ORDER BY ClassName DESC"></asp:SqlDataSource>

            <!-- change datasource to only select classes for the logged in teacher -->
            <div class="row" style="width:20%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Class*</span><br/>
                <asp:DropDownList ID="drpSelectClass" runat="server" DataSourceID="ViewAllClasses" DataTextField="ClassName" DataValueField="ClassID" class="custom-select"></asp:DropDownList>
                <%--<asp:Button ID="btnSelectClass" runat="server" Text="Select" OnClick="btnSelectClass_Click"/>--%>
            </div> <br/>

            

            <asp:SqlDataSource ID="ViewAllHomework" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM CoreHomework ORDER BY HomeworkTitle DESC"></asp:SqlDataSource>

            <div class="row" style="width:20%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Homework*</span><br/>
                <asp:DropDownList ID="dropSelectHomework" runat="server" DataSourceID="ViewAllHomework" DataTextField="HomeworkTitle" DataValueField="CoreHomeworkID" class="custom-select"></asp:DropDownList>
                <%--<asp:Button ID="btnSelectHomework" runat="server" Text="Select" OnClick="btnSelectHomework_Click"/>--%>
            </div> <br/>


            <div class="row" style="width:20%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                <span style="font-weight:bold">Due Date*</span><br/>
                <asp:TextBox ID="dueDateIn" runat="server" placeholder="From" type="date"></asp:TextBox>
            </div> <br/>


            <asp:Button ID="btnAssignHomework" runat="server" Text="Assign Homework" OnClick="btnAssignHomework_Click" />


        </div>
    </form>
</body>
</html>
