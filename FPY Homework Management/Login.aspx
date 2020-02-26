<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FPY_Homework_Management.Login" %>

<!DOCTYPE html>

<html lang="en">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
    </head>
<body>
        <div>

            <form ID="loginForm" runat="server">
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
