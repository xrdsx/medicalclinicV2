<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOfficeData.aspx.cs" Inherits="medicalclinic.EditOfficeData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="office-show">
        <div class="office-show__item">
            <asp:Label ID="LabelID" runat="server" Text="Office ID"></asp:Label>
            <asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox>
        </div>
        <div class="office-show__item">
            <asp:Label ID="LabelNumberOfOffice" runat="server" Text="Number Of Office"></asp:Label>
            <asp:TextBox ID="TextBoxNumberOfOffice" runat="server" AutoPostBack="true" OnTextChanged="TextBoxNumberOfOffice_TextChanged1"></asp:TextBox>
        </div>
        <div class="office-show__item">
            <asp:Label ID="LabelAvailibility" runat="server" Text="Availibility"></asp:Label>
            <asp:CheckBox ID="CheckBoxAvailibility" runat="server" />
        </div>
        <div class="office-show__item">
            <asp:Label ID="LabelSpecialization" runat="server" Text="Office Specialization"></asp:Label>
            <asp:DropDownList ID="DropDownListSpecializations" runat="server">
            </asp:DropDownList>
        </div>
        <div class="office-show__item">
            <asp:Label ID="LabelRole" runat="server" Text="Office Role"></asp:Label>
            <asp:DropDownList ID="DropDownListRoles" runat="server">
            </asp:DropDownList>
        </div>
        <asp:Button ID="ButtonEdit" runat="server" Text="Edit Data" CssClass="btn btn-default" OnClick="ButtonEdit_Click" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="ButtonCancel_Click" />
    </div>
</asp:Content>
