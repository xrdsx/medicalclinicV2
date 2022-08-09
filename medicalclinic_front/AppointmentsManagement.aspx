<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppointmentsManagement.aspx.cs" Inherits="medicalclinic.AppointmentManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<center>
    <div style="height: 92.4vh; width: 80vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white">
        <div style="margin-top: 5vh">
            <asp:Label CssClass="Title" ID="LabelMessage" runat="server" Text="Appointments Management"></asp:Label>
            <br />
            <div style="width: 70vw; height: 50vw; border: solid; border-color: #EDF1F9;">
                <asp:Calendar CssClass="Calendar" ID="Calendar_appointments" runat="server" BackColor="#507CD1" CellPadding="1" CellSpacing="5" Height="100%" Width="100%" OnDayRender="Calendar_appointments_DayRender" OnSelectionChanged="Calendar_appointments_SelectionChanged">
                    <DayHeaderStyle CssClass="DayHeader"/>
                    <DayStyle CssClass="DayBlock"/>
                    <NextPrevStyle CssClass="NextPrevButton" ForeColor="White"/>  
                    <OtherMonthDayStyle CssClass="OtherMonthDayBlock" ForeColor="#ADADAD"/>
                    <SelectedDayStyle BackColor="#C7E8F8" ForeColor="White"/>
                    <SelectorStyle Font-Underline ="false"/>
                    <TitleStyle CssClass="TitleBlock" ForeColor="White" Font-Bold="true" Font-Size="150%" Height="12pt" />
                    <TodayDayStyle CssClass="TodayDay" ForeColor="White"/>
                    <WeekendDayStyle CssClass="WeekendDayBlock"/>
                </asp:Calendar>
            </div>
            <div style="width: 70vw">
                <div style="border: solid; border-color: #EDF1F9; width: 65%; float: left">
                    <asp:Label CssClass="Label" ID="Label10" runat="server" Text="Filter values"></asp:Label>
                    <br />
                    <div style="clear: both">
                        <asp:Label CssClass="LabelFilter" ID="Label_Doctor" runat="server" Text="Doctor: "></asp:Label>
                        <asp:DropDownList CssClass="TextBox" ID="DropDownList_doctor" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="clear: both">
                        <asp:Label CssClass="LabelFilter" ID="Label_Patient" runat="server" Text="Patient: "></asp:Label>
                        <asp:DropDownList CssClass="TextBox" ID="DropDownList_patient" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="clear: both">
                        <asp:Label CssClass="LabelFilter" ID="Label_Office" runat="server" Text="Office: "></asp:Label>
                        <asp:DropDownList CssClass="TextBox" ID="DropDownList_office" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="clear: both">
                        <asp:Label CssClass="LabelFilter" ID="Label9" runat="server" Text="Date: "></asp:Label>
                        <asp:TextBox CssClass="TextBox" ID="TextBox_date" runat="server" MaxLength="10" TextMode="Date" style="width: 25%"></asp:TextBox>
                        <asp:Button CssClass="Button" ID="Button_change_date" runat="server" Text="Change date" OnClick="Button_change_date_Click"/>
                    </div>     
                </div>
                <div style="border: solid; border-color: #EDF1F9; width: 35%; float: left">
                    <asp:Label CssClass="Label" ID="LabelFilterMethod" runat="server" Text="Other"></asp:Label>
                    <br />
                    <div style="clear: both">
                        <asp:Label CssClass="Legend" ID="Label5" runat="server" Text="[.]" style="background-color:#507CD1; color:#507CD1"></asp:Label>
                        <asp:Label CssClass="LabelFilter" ID="Label1" runat="server" Text="Today"></asp:Label>
                    </div>
                    <div style="clear: both">
                        <asp:Label CssClass="Legend" ID="Label6" runat="server" Text="[.]" style="background-color:#E5E5E5; color:#E5E5E5"></asp:Label>
                        <asp:Label CssClass="LabelFilter" ID="Label2" runat="server" Text="Other Months"></asp:Label>
                    </div>
                    <div style="clear: both">
                        <asp:Label CssClass="Legend" ID="Label7" runat="server" Text="[.]" style="background-color:#E8EBF2; color:#E8EBF2"></asp:Label>
                        <asp:Label CssClass="LabelFilter" ID="Label3" runat="server" Text="Weekend"></asp:Label>
                    </div>
                    <div style="clear: both">
                        <asp:Label CssClass="Legend" ID="Label8" runat="server" Text="[.]" style="background-color:#82A3E0; color:#82A3E0"></asp:Label>
                        <asp:Label CssClass="LabelFilter" ID="Label4" runat="server" Text="Appointment"></asp:Label>
                    </div>
                    <asp:Button CssClass="Button" ID="Button_close" runat="server" Text="Close" OnClick="Button_close_Click"/>
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
        float: left;
        background-color: #507CD1;
        border: 2px solid;
        border-color: #507CD1;
        border-radius: 3px;
        width: 25%; 
        font-size: 1.7vmin;
        color: white;
        font-weight: bold;
        margin: 0.2vw;
        margin-top: 0.5vh;
        text-overflow: ellipsis;
        white-space:nowrap;
        overflow:hidden;
    }
    .Button:hover
    {
        background-color: white;
        color: #507CD1;
    }
    .TextBox
    {
        margin-left: 2vw;
        float: left;
        width: 50%;
        font-size: 1.7vmin;
        margin-top: 0.5vh;
        height: 2.9vmin;
        text-overflow: ellipsis;
            
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
    .LabelFilter
    {
        margin-left: 1vw;
        text-align: left;
        float: left;
        width: 12vw;
        font-size: 1.7vmin;
        font-weight: lighter;
        height: 2.9vmin;
        margin-top: 0.5vh;
        white-space:nowrap;
        overflow:hidden;
        text-overflow: ellipsis;
    }
     .Legend
    {
        margin-left: 0.5vw;
        margin-right: 1vw;
        text-align: left;
        float: left;
        font-size: 1.7vmin;
        font-weight: lighter;
        height: 2.1vmin;
        width: 2.1vmin;
        margin-top: 0.5vh;
    }
    /*Calendar Style*/
    .TitleBlock
    {
        background-color: #507CD1;
        text-align: Center;
    }

    .DayHeader
    {
        border-bottom: 5px Solid;
        border-color: White;
        color: white;
        text-align: Center;
        font-weight: bold;
        font-size: 1.6vw;
        height: 10px;
    }
    .DayBlock
    {
        background-color: #EFF3FB;
        border: 5px Solid;
        border-color: White;
        border-radius: 5px;
        font-weight: bold;
        font-size: 1.6vw;
        text-align: Center;
    }
    .DayBlock:hover
    {
        background-color: #DEE4EF;
        text-decoration: none;
    }
    .TodayDay
    {
        background-color: #507CD1;
        border: 5px Solid;
        border-color: White;
        border-radius: 5px;
        font-weight: bold;
        font-size: 1.6vw;
        text-align: Center;
    }
    .OtherMonthDayBlock
    {
        background-color: #E5E5E5;
        border: 5px Solid;
        border-color: White;
        border-radius: 5px;
        font-weight: bold;
        font-size: 1.6vw;
        text-align: Center;
    }
    .OtherMonthDayBlock:hover
    {
        background-color: #D8D8D8;
        text-decoration: none;
    }
    .WeekendDayBlock
    {
        background-color: #E8EBF2;
        border: 5px Solid;
        border-color: White;
        border-radius: 5px;
        font-weight: bold;
        font-size: 1.6vw;
        text-align: Center;
    }
    .WeekendDayBlock:hover
    {
        background-color: #DEE4EF;
        text-decoration: none;
    }
    .NextPrevButton
    {
        font-size: 2.5vw;
        font-weight: bold;
        text-align: Center;
        text-decoration: none;
    }
   
</style> 
</asp:Content>
