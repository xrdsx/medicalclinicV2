<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewPatient.aspx.cs" Inherits="medicalclinic.AddNewPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <div style="height: 92.4vh; width: 80vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white">
        <div style="margin-left: 5vw; margin-top: 5vh">
            <asp:Label CssClass="Title" ID="LabelTitle" runat="server" Text="Add New Patient"></asp:Label>
        </div>  
        <div style="margin-left: 26vw; border: solid; border-color: #EDF1F9; width: 40%; float: left";>
            <div style="margin-top: 1vh; clear: both">
                <asp:Label CssClass="Label" ID="LabelName" runat="server" Text="First name:" ></asp:Label>
                <asp:TextBox CssClass="TextBox" ID="TextBoxName" runat="server" placeholder="Patient name" MaxLength="30"></asp:TextBox>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="Label" ID="LabelSurname" runat="server" Text="Surname:"></asp:Label>
                <asp:TextBox CssClass="TextBox" ID="TextBoxSurname" runat="server" placeholder="Patient surname" MaxLength="30"></asp:TextBox>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="Label" ID="Label3" runat="server" Text="Sex:"></asp:Label>
                <asp:DropDownList CssClass="DropDownList" ID="DropDownListSex" runat="server">
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="Label" ID="LabelPesel" runat="server" Text="Pesel number:"></asp:Label>
                <asp:TextBox CssClass="TextBox" ID="TextBoxPesel" runat="server" placeholder="Patient pesel number" MaxLength="11"></asp:TextBox>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="Label" ID="LabelDate" runat="server" Text="Date of birth:"></asp:Label>
                <asp:TextBox CssClass="TextBox" ID="TextBoxDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div style="clear: both;">
                <asp:Label CssClass="Label" ID="LabelPhoneNumber" runat="server" Text="Phone number:"></asp:Label>
                <asp:TextBox CssClass="TextBox" ID="TextBoxPhoneNumber" runat="server" placeholder="Patient phone number" MaxLength="9"></asp:TextBox>
            </div>
            <div>
                <asp:Label CssClass="Label" ID="LabelEmail" runat="server" Text="Email address:"></asp:Label>
                <asp:TextBox CssClass="TextBox" ID="TextBoxEmail" runat="server" placeholder="Patient e-mail address" MaxLength="100"></asp:TextBox>
            </div>
            <div style="margin-top: 2vh">
                <asp:Button CssClass="Button" ID="ButtonAddNewPatient" runat="server" Text="Add" OnClick="ButtonAddNewPatient_Click"/>
                <asp:Button CssClass="Button" ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click"/>
            </div>
        </div>
    </div>
    </center>
    

<style type="text/css">
        .Title
        {
            text-align: center;
            font-weight: bold;
            font-size: 3vw;
            color: #507CD1;
            width: 100%;
            float: right;
            margin: 5px;
        }
        .Button
        {
            background-color: #507CD1;
            border: 2px solid;
            border-color: #507CD1;
            border-radius: 3px;
            width: 12vw;
            font-size: 1.7vmin;
            color: white;
            font-weight: bold;
            margin: 0.2vmin;
            margin-top: 0.7vh;
            margin-bottom: 0.7vh;
            text-overflow: ellipsis;
        }
        .Button:hover
        {
            background-color: white;
            color: #507CD1;
        }
        .Label
        {
            text-align: left;
            font-size: 1.7vmin;
            font-weight: lighter;
            float: left;
            margin-left: 2vw;
            margin-top: 0.8vh;
            display: block;
            width: 10vw;
            height: 2.9vmin;
            text-overflow: ellipsis;
            white-space:nowrap;
            overflow:hidden;
        }
        .TextBox
        {
            font-size: 1.7vmin;
            font-weight: lighter;
            float: right;
            margin-right: 2vw;
            margin-top: 0.8vh;
            display: block;
            width: 15vw;
            height: 2.9vmin;
            text-overflow: ellipsis;
        }
        .DropDownList
        {
            width: 15vw;
            float: right;
            margin-right: 2vw;
            margin-top: 0.8vh;
            display: block;
            font-size: 1.7vmin;
            font-weight: lighter;
            height: 2.9vmin;
        }      
</style>
</asp:Content>