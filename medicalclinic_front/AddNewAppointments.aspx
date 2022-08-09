<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewAppointments.aspx.cs" Inherits="medicalclinic.Formularz_internetowy1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<center>
       <div style="height: 92.4vh; width: 80vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white"> 
            <div style="margin-left: 5vw; margin-top: 5vh">
                <asp:Label CssClass="Title" ID="LabelTitle" runat="server" Text="Add New Appointment"></asp:Label>
           </div> 
           <div style="margin-left: 26vw; border: solid; border-color: #EDF1F9; width: 40%; float: left";>
                <div style="margin-top: 1vh; clear: both">
                    <asp:Label CssClass="Label" ID="LabelPatient" runat="server" Text="Patient:"></asp:Label>
                    <asp:DropDownList CssClass="DropDownList" ID="DropDownList_Patient" runat="server" OnSelectedIndexChanged="DropDownList_Patient_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label1" runat="server" Text="Date:"></asp:Label>
                    <asp:TextBox CssClass="TextBox" ID="TextBox_Date" TextMode="Date" runat="server" OnTextChanged="TextBox_Date_TextChanged"></asp:TextBox>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label3" runat="server" Text="Specialization:"></asp:Label>
                    <asp:DropDownList CssClass="DropDownList" ID="DropDownList_Specialization" runat="server" OnSelectedIndexChanged="DropDownList_Specialization_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div>
                    <asp:Label CssClass="Label" ID="Label4" runat="server" Text="Doctor:"></asp:Label>
                    <asp:DropDownList CssClass="DropDownList" ID="DropDownList_Doctor" runat="server" OnSelectedIndexChanged="DropDownList_Doctor_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label5" runat="server" Text="Office:"></asp:Label>
                    <asp:DropDownList CssClass="DropDownList" ID="DropDownList_Office" runat="server" OnSelectedIndexChanged="DropDownList_Office_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label2" runat="server" Text="Time:"></asp:Label>
                    <asp:DropDownList CssClass="DropDownList" ID="DropDownList_Available_hours" runat="server"></asp:DropDownList>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label7" runat="server" Text="Payment:"></asp:Label>
                    <asp:TextBox CssClass="TextBox" MinValue="0" ID="TextBox_Payment" runat="server"></asp:TextBox>
                </div>                
                <div style="margin-top: 2vh">
                <asp:Button CssClass="Button" ID="Button_AddNewAppointment" runat="server" Text="Add an appointment" width="250px" OnClick="Button_AddNewAppointment_Click"/>
                
                <asp:Button CssClass="Button" ID="Button_Cancel" runat="server" Text="Cancel" width="250px" OnClick="Button_Cancel_Click"/>
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
