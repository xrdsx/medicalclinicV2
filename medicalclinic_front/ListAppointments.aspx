<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAppointments.aspx.cs" Inherits="medicalclinic.ListAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<center>
<div style="height: 92.4vh; width: 80vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white">
    <div style="margin-top: 5vh; margin-bottom: 3.5vw">
        <asp:Label CssClass="Title" ID="LabelMessage" runat="server" Text="List of Appointments"></asp:Label>
        <br />
    </div>
    <div style="border: solid; border-color: #EDF1F9; width: 85%;">
            <asp:Label CssClass="Label" ID="Label_date" runat="server" Text="Selected date: "></asp:Label>
            <asp:Panel runat="server" Height="250px" Width="100%"  ScrollBars="Vertical">
                <asp:GridView
                    CssClass="GridView"
                    ID="GridViewAppointments"
                    runat="server"
                    AutoGenerateColumns="False"
                    DataKeyNames="Id"
                    AllowSorting="True"
                    HeaderStyle ="position:absolute; font-weight: bold;"
                    Width="100%" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewAppointments_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true"/>
                        <asp:BoundField DataField="Employee" HeaderText="Doctor"/>
                        <asp:BoundField DataField="Patient" HeaderText="Patient"/>
                        <asp:BoundField DataField="Office_number" HeaderText="Office number"/>
                        <asp:BoundField DataField="Time_of_appointment" HeaderText="Appointment Hour"/>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
            </asp:Panel>
        </div>
        <div style="border: solid; border-color: #EDF1F9; width: 85%;">
            <asp:Label CssClass="Label" ID="Label1" runat="server" Text="Other options"></asp:Label>
            <br />
            <div style="width: 50%; margin-top: 5%; margin-bottom: 5%">
                <div style="margin-top: 5%">
                     <asp:Button CssClass="Button" ID="Button_addnewappointment" runat="server" Text="Add new appointment" OnClick="Button_addnewappointment_Click" />
                </div>
                <div style="margin-top: 5%">
                    <asp:Button CssClass="Button" ID="Button_close" runat="server" Text="Close" OnClick="Button_close_Click" />
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
        float: right;
        margin: 5px;
    }
    .GridView
    {
        font-size: 1.25vw;
    }
    .Button
    {
        background-color: #507CD1;
        border: 2px solid;
        border-color: #507CD1;
        border-radius: 3px;
        width: 15vw; 
        font-size: 1.7vmin;
        color: white;
        font-weight: bold;
        margin: 0.2vmin;
        text-overflow: ellipsis;
        white-space:nowrap;
        overflow:hidden;
    }
    .Button:hover
    {
        background-color: white;
        color: #507CD1;
    }
    .Label
    {
        text-align: center;
        color: #507CD1;
        font-weight: bold;
        font-size: 1.8vw;
        width: 100%;
        float: right;
        margin: 5px;
    }  
</style> 
</asp:Content>
