<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopupConfirmOfficeDeletion.aspx.cs" Inherits="medicalclinic.PopupConfirmOfficeDeletion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please confirm that you want to delete this office"></asp:Label>
            <br />
            <br />
        </div>
        <asp:Button CssClass="btn btn-default" ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="Confirm" />
    </form>
</body>
</html>
