<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeReview.aspx.cs" Inherits="medicalclinic.WebForm4" %>

<asp:Content ID="EmployeeReview" ContentPlaceHolderID="MainContent" runat="server">
    <div class="employee-show">
        <div class="employee-show__item">
            <asp:Label ID="IdLabel" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="TextBoxID" placeholder="ID" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <div class="employee-show__item">
            <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TextBoxName" placeholder="Name*" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
        </div>
        <div class="employee-show__item">
            <asp:Label ID="SurnameLabel" runat="server" Text="Surname"></asp:Label>
            <asp:TextBox ID="TextBoxSurname" placeholder="Surname*" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
        </div>
        <div class="employee-show__item">
            <asp:Label ID="PESELLabel" runat="server" Text="PESEL"></asp:Label>
            <asp:TextBox ID="TextBoxPESEL" placeholder="PESEL*" runat="server" MaxLength="11" AutoPostBack="True" Enabled="False"></asp:TextBox>
        </div>
        <div class="employee-show__item">
            <asp:Label ID="DateOfBirthLabel" runat="server" Text="Date of birth"></asp:Label>
            <asp:TextBox ID="TextBoxDateOfBirth" placeholder="DateOfBirth*" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <div class="employee-show__item">
            <asp:Label ID="RoleLabel" runat="server" Text="Role"></asp:Label>
            <asp:TextBox ID="TextBoxRole" placeholder="Role*" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <div class="employee-show__item">
            <asp:Label ID="SpecializationLabel" runat="server" Text="Specialization"></asp:Label>
            <asp:TextBox ID="TextBoxSpecialization" placeholder="Specialization*" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <asp:Panel ID="AddressPanel" runat="server" CssClass="employee-show__address">
            <div class="employee-show__item">
                <asp:Label ID="CountryLabel" runat="server" Text="Country"></asp:Label>
                <asp:TextBox ID="TextBoxCountry" placeholder="Country" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div class="employee-show__item">
                <asp:Label ID="StateLabel" runat="server" Text="State"></asp:Label>
                <asp:TextBox ID="TextBoxState" placeholder="State" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div class="employee-show__item">
                <asp:Label ID="CityLabel" runat="server" Text="City"></asp:Label>
                <asp:TextBox ID="TextBoxCity" placeholder="City" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div class="employee-show__item">
                <asp:Label ID="PostalCodeLabel" runat="server" Text="Postal code"></asp:Label>
                <asp:TextBox ID="TextBoxPostalCode" placeholder="Postal Code" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div class="employee-show__item">
                <asp:Label ID="StreetLabel" runat="server" Text="Street"></asp:Label>
                <asp:TextBox ID="TextBoxStreet" placeholder="Street" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div class="employee-show__item">
                <asp:Label ID="HouseNumerLabel" runat="server" Text="House humber"></asp:Label>
                <asp:TextBox ID="TextBoxHouseNumber" placeholder="House Number" runat="server" Enabled="False"></asp:TextBox>
            </div>

        </asp:Panel>
        <div class="employee-show__item">
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <div class="employee-show__item">
            <asp:Label ID="PhoneNumberLabel" runat="server" Text="Phone number"></asp:Label>
            <asp:TextBox ID="TextBoxPhoneNumber" placeholder="Phone Number" runat="server" MaxLength="9" Enabled="False"></asp:TextBox>
        </div>

        <div class="employee-show__item">
            <asp:Label ID="SexLabel" runat="server" Text="Sex"></asp:Label>
            <asp:TextBox ID="TextBoxSex" placeholder="Sex" runat="server" Enabled="False"></asp:TextBox>
        </div>

        <div class="employee-show__item">
            <asp:Label ID="IsActiveStatusLabel" runat="server" Text="Status"></asp:Label>
            <asp:TextBox ID="TextBoxIsAcitve" placeholder="IsActive" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <asp:Button ID="ButtonEdit" CssClass="btn btn-default" runat="server" Text="Edit" OnClick="ButtonEdit_Click" />
        <asp:Button ID="ButtonCancel" CssClass="btn btn-default" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />

    </div>
</asp:Content>
