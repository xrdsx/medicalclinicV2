<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="medicalclinic.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Odzyskiwanie hasła</title>
    <script src="https://kit.fontawesome.com/714b427abb.js" crossorigin="anonymous"></script>
    <link href="./Content/Login.css" rel="stylesheet" />
    <script type="text/javascript">
        window.history.forward(-1);
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div class="back-to-home">
        <a href="./HomePage.html">powrót</a>
    </div>
        <div class="container">
            <div class="text-section">
                <h2>Odzyskanie hasła</h2>
                <p>medical clinic</p>
            </div>
            <div class="inputs">
                <asp:TextBox ID="email" runat="server" placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="login" runat="server" placeholder="Login"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Wyślij" OnClick="Button1_Click" class="check-email"/>
                <asp:Label ID="SendedMail" runat="server" Text=""></asp:Label>
                <asp:Label ID="IncorrectDataLabel" runat="server" Text="Niepoprawne dane"></asp:Label>
            </div>
        </div>
        </div>
    </form>
    <script src="./Scripts/checkEmail.js"></script>
</body>
</html>
