<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Login.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Login</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
</head>
<body>
        <div>

            <form ID="tLoginForm" runat="server">
            <div class="form-group">
                <label for="exampleUsernameInput">Username</label>
                <asp:TextBox class="form-control" ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="examplePasswordInput">Password</label>
                <asp:TextBox type="password" class="form-control" ID="txtPassword" runat="server" placeholder="Password"></asp:TextBox>
            </div>

            <div class="row">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary btn-block m-3" Style="background-color: #00b359" />
            </div>
                        
            <asp:Label ID="txtNotify" runat="server"></asp:Label>
            </form>

        </div>
</body>
</html>