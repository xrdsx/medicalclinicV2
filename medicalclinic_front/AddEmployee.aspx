<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddEmployee.aspx.cs" Inherits="medicalclinic.WebForm1" %>

<asp:Content ID="AddEmployee" ContentPlaceHolderID="MainContent" runat="server">
    <div class="employee-show">
        <asp:TextBox ID="TextBoxName" placeholder="Name*" runat="server" OnTextChanged="TexBoxName_TextChanged" AutoPostBack="True"> </asp:TextBox>
        <asp:TextBox ID="TextBoxSurname" placeholder="Surname*" runat="server" OnTextChanged="TextBoxSurname_TextChanged" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="TextBoxPESEL" placeholder="PESEL*" runat="server" MaxLength="11" OnTextChanged="TextBoxPESEL_TextChanged" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="CalendarTextBox" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="CalendarBirthDate" PopupButtonID="imgPopup" runat="server" TargetControlID="CalendarTextBox" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
        <asp:DropDownList ID="DropDownListRole" runat="server" OnSelectedIndexChanged="DropDownListRole_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListSpecialization" runat="server" Visible="False">
        </asp:DropDownList>
        <asp:Panel ID="AddressPanel" runat="server" CssClass="employee-show__address">
            <asp:TextBox ID="TextBoxCountry" placeholder="Country" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxState" placeholder="State" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxCity" placeholder="City" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxPostalCode" placeholder="Postal Code" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxStreet" placeholder="Street" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxHouseNumber" placeholder="House Number" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxPhoneNumber" placeholder="Phone Number" runat="server" MaxLength="9"></asp:TextBox>
        <asp:DropDownList ID="DropDownListSex" runat="server">
            <asp:ListItem>Female</asp:ListItem>
            <asp:ListItem>Male</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonNext" CssClass="btn btn-default" runat="server" Text="Next" Enabled="False" OnClick="ButtonNext_Click" />
        <asp:Button ID="ButtonCancel" CssClass="btn btn-default" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
    </div>
</asp:Content>