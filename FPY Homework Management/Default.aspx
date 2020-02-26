<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FPY_Homework_Management._Default" %>

<!DOCTYPE html>

<html lang="en">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Select</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
</head>
<body>
    <asp:Button ID="StudentLink" OnClick="StudentLink_Click" runat="server" Text="I am a student." />

    <asp:Button ID="TeacherLink" OnClick="TeacherLink_Click" runat="server" Text="I am a Teacher." />

</body>
</html>