<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="medicalclinic.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LoginForm</title>
    <script src="https://kit.fontawesome.com/714b427abb.js" crossorigin="anonymous"></script>
    <link href="./Content/Login.css" rel="stylesheet" />
    <script type="text/javascript">
        window.history.forward(-1);
</script>

</head>

<body>
    <div class="back-to-home">
        <a href="./HomePage.html">back</a>
    </div>
    <div class="aspNetHidden">
        <input type="hidden" name="reference" id="reference" runat="server" />
    </div>
   <form id="form1" runat="server">
        <div class="container">
            <div class="text-section">
                <h2>Login form</h2>
                <p>medical clinic</p>
            </div>
            <div class="inputs">
                <asp:TextBox ID="TextBox1" runat="server" placeholder="Login"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" placeholder="Password" type="password"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Sign In" OnClick="Button1_Click" />
                <p class="forgot-pass"><a href="ForgetPassword.aspx">Forgot your password?</a></p>
                <asp:Label ID="IncorrectDataLabel" runat="server" Text="Wrong credentials"></asp:Label>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:Label ID="LabelSec" runat="server" Text="0"></asp:Label>
                    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick" />
                </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>

</html>
