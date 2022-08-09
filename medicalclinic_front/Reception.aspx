<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reception.aspx.cs" Inherits="medicalclinic.Reception" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <div style="height: 92.4vh; width: 80vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white">
            <div style="margin-top: 5vh">
                <asp:Label CssClass="Title" ID="LabelMessage" runat="server" Text="Reception"></asp:Label>
                <br />
                <div style="width: 60%; height: 50%; border: solid; border-color: #EDF1F9;">
                    <div>
                        <asp:Button CssClass="Button" ID="Button_patients" runat="server" Text="Patients Management" OnClick="Button_patients_Click" />
                    </div>
                    <div>
                        <asp:Button CssClass="Button" ID="Button_appointments" runat="server" Text="Appointments Management" OnClick="Button_appointments_Click" style="margin-bottom: 5vh"/>
                    </div>
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
        margin: 5px;
    }
    .Button
    {
        background-color: #507CD1;
        border: 2px solid;
        border-color: #507CD1;
        border-radius: 3px;
        width: 40vw;
        height: 20vh;
        font-size: 2.1vmin;
        color: white;
        font-weight: bold;
        margin: 0.2vw;
        margin-top: 5vh;
        text-overflow: ellipsis;
        white-space:nowrap;
        overflow:hidden;
    }
    .Button:hover
    {
        background-color: white;
        color: #507CD1;
    }
</style>
</asp:Content>
