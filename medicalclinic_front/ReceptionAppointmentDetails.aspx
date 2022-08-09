<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceptionAppointmentDetails.aspx.cs" Inherits="medicalclinic.ReceptionAppointmentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <script>     
        function CancelAlertFunction() {
            if (confirm('Are you sure you want to cancel this appointment?')) {
                $('#ConfirmMessageResponseDelete').val('Yes');
            }
            else {
                $('#ConfirmMessageResponseDelete').val('No');
            }
        }
        function ResheduleAlertFunction() {
            if (confirm('Are you sure you want to edit data of this appointment?')) {
                $('#ConfirmMessageResponseModify').val('Yes');
            }
            else {
                $('#ConfirmMessageResponseModify').val('No');
            }
        }
    </script>

<center>
 <div style="height: 92.4vh; width: 80vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white">
    <div style=""height: 500px">
        <asp:Label CssClass="Title" ID="Label_appointment" runat="server" Text="Appoitment details:" Font-Names="Arial" Font-Size="18pt"></asp:Label>
        <div style="margin-left: 26vw; border: solid; border-color: #EDF1F9; width: 35%; float: left";>

     <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_id" runat="server" Text="ID: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
         <asp:Label CssClass="Label_value" ID="Label_id_value" runat="server" Text="Label"></asp:Label>
         </div>
    <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_date" runat="server" Text="Date: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label CssClass="Label_value" ID="Label_date_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_time" runat="server" Text="Time: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label CssClass="Label_value" ID="Label_time_value" runat="server" Text="Label"></asp:Label>
    </div>
     <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_status" runat="server" Text="Status: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label CssClass="Label_value" ID="Label_status_value" runat="server" Text="Label"></asp:Label>
    </div>
     <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_description" runat="server" Text="Description: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label CssClass="Label_value" ID="Label_description_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_doctor" runat="server" Text="Doctor: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label CssClass="Label_value" ID="Label_doctor_value" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label_doctor_id" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
     <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_patient" runat="server" Text="Patient: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label CssClass="Label_value" ID="Label_patient_value" runat="server" Text="Label"></asp:Label>
         <asp:Label ID="Label_patient_id" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
    <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_office" runat="server" Text="Office number: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label CssClass="Label_value" ID="Label_office_value" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label_office_id" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
     <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_payment" runat="server" Text="Payment: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label CssClass="Label_value" ID="Label_payment_value" runat="server" Text="Label"></asp:Label>
    </div>
    </div>
    <div>
    </div>
        <asp:Label CssClass="Title" ID="Label_reshedule" runat="server" Text="Reschedule appointment:" Font-Names="Arial" Font-Size="18pt"></asp:Label>
        <div style="margin-left: 26vw; border: solid; border-color: #EDF1F9; width: 35%; float: left";>
    <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_ndate" runat="server" Text="New date of appoitment: " Font-Names="Arial" Font-Size="12pt" width="200pt"></asp:Label>
        <asp:TextBox CssClass="TextBox" ID="TextBox_ndate" runat="server" MaxLength="10" TextMode="Date" OnTextChanged="TextBox_ndateTextChanged"></asp:TextBox>
    </div>
     <div style="clear: both">
        <asp:Label CssClass="Label" ID="Label_ntime" runat="server" Text="New time of appoitment: " Font-Names="Arial" Font-Size="12pt" width="200pt"></asp:Label>
        <asp:DropDownList CssClass="DropDownList" ID="DropDownList_Available_hours" runat="server"></asp:DropDownList>
    </div>
    </div>
     <div style="clear: both">
        <asp:Button CssClass="Button" ID="Button_cancel" runat="server" OnClick="Button_Cancel_Click" OnClientClick ="return CancelAlertFunction()" Text="Cancel Appointment" />
        <asp:HiddenField ID="ConfirmMessageResponseDelete" runat="server" ClientIDMode="Static" />
    </div>
    <div style="clear: both">
        <asp:Button CssClass="Button" ID="Button_reshedule" runat="server" OnClientClick ="return ResheduleAlertFunction()" Text="Reschedule" OnClick="Button_Reshedule_Click" />
        <asp:HiddenField ID="ConfirmMessageResponseModify" runat="server" ClientIDMode="Static" />
    </div>
    <div style="clear: both">
       <asp:Button CssClass="Button" ID="Button_close" runat="server" OnClick="Button_close_Click" Text="Close" />
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
        .LabelValue
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
