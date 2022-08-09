<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="medicalclinic.PasswordChange" %>

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
        <div class="container">
            <div class="text-section">
                <h2>Odzyskanie hasła</h2>
                <p>medical clinic</p>
            </div>
            <div class="inputs">
                <asp:Label ID="head_info" runat="server"></asp:Label>
                <asp:TextBox ID="new_passw" runat="server" placeholder="Nowe hasło" type="password"></asp:TextBox>
                <asp:TextBox ID="confirm_passw" runat="server" placeholder="Potwierdź nowe hasło" type="password"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Zmień" OnClick="Button2_Click" class="change-password"/>
                <asp:Button ID="returnBtn" runat="server" Text="Anuluj" OnClick="returnBtn_Click"/>
                <asp:Label ID="IncorrectDataLabel" runat="server" Text="Niepoprawne dane"></asp:Label>
            </div>
        </div>
    </form>

     <script src="./Scripts/check_password_change.js"></script>
</body>
</html>
