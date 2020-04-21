<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Create_Class.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Create_Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>
</head>
<body>
        <div>
            <form id="frmCreateClass" runat="server">
                <h1 id="tCreateClassHeadder">Create a Class</h1>
                <asp:SqlDataSource ID="ViewAllTeachers" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [TeacherID], [TeacherFirstName], [TeacherLastName], [TeacherUsername] FROM [Teachers] ORDER BY [TeacherFirstName] DESC, [TeacherLastName] DESC"></asp:SqlDataSource>


                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class Teacher*</span><br/>
                    <asp:DropDownList ID="drpSelectTeacher" runat="server" DataSourceID="ViewAllTeachers" DataTextField="TeacherUsername" DataValueField="TeacherID" class="custom-select"></asp:DropDownList>
                </div><br/>


                <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class Subject*</span><br/>
                    <asp:TextBox ID="classSubjectIn" runat="server" class="form-control" placeholder="Subject" ></asp:TextBox>
                </div><br/>


	            <div class="row" style="width:100%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class Year Group*</span><br/>
                    <asp:TextBox ID="classYearGroupIn" runat="server" class="form-control" placeholder="Year Group" ></asp:TextBox>
                </div><br/>


                <asp:Button ID="btnCreateClass" class="btn btn-primary" Width="100%" runat="server" Text="Create" OnClick="btnCreateClass_Click"></asp:Button>

            </form>
        </div>
</body>
</html>
