<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateNewUser.aspx.cs" Inherits="medicalclinic.WebForm2" %>

<asp:Content ID="AddUser" ContentPlaceHolderID="MainContent" runat="server">

    <div class="new-user-wrapper">
        <div class="new-user">
            <h2>Create new user</h2>
            <asp:Label ID="Label1" CssClass="new-user__info" runat="server" Text="Info"></asp:Label>                    
            <div class="new-user__dropdown-box">
                <asp:DropDownList ID="DropDownList1" CssClass="new-user__dropdown" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>

            <div class="new-user__btns-box">
                <asp:Button ID="ButtonOK" runat="server" Text="Ok" CssClass="new-user__btn-ok" OnClick="ButtonOK_Click" />
                <asp:Button ID="ButtonSKIP" runat="server" Text="Cancel" CssClass="new-user__btn-cancel" OnClick="ButtonSKIP_Click" />               
            </div>            
        </div>
    </div>
</asp:Content>
