<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar_AppointmentResults.aspx.cs" Inherits="medicalclinic.Calendar_AppointmentResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <asp:Panel ID="Panel1" runat="server" Height="797px" Width="573px" Font-Bold="False">

        <br />
                <asp:Label ID="Label1" runat="server" Text="Add result for patient" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <br />
        <div style="float=left;">


            <asp:Label ID="Label2" runat="server" Text="Date of appointment:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_date" runat="server" Enabled="False" Height="25px" TextMode="DateTime" Width="225px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_name" runat="server" Enabled="False" Height="25px" Width="225px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Surname:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_surname" runat="server" Enabled="False" Height="25px" Width="225px"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Pesel:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_pesel" runat="server" Enabled="False" Height="25px" Width="225px"></asp:TextBox>
            <br />

            <asp:Label ID="Label6" runat="server" Text="Result:"></asp:Label>

            <br />
            <textarea id="TextArea_result" name="textArea_result" aria-pressed="true" aria-required="True" aria-sort="none" lang="en"></textarea><br />
            <br />
            <asp:Button ID="Button_Accept" runat="server" Height="40px" Text="Accept" Width="60px" OnClick="Button_Accept_Click" OnClientClick="return confirm ('Are you sure to accept data?');" />

            &nbsp;<asp:Button ID="Button_Cancel" runat="server" Height="40px" Text="Cancel" Width="60px" OnClick="Button_Cancel_Click" OnClientClick="return confirm ('Are you sure to cancel?');" />
            <br />
            <asp:Button ID="Button_history" runat="server" Height="40px" OnClick="Button_History_Click" Text="Check history" Width="120px" />
            <br />
            <asp:GridView ID="GridView_patientHistory" runat="server">
            </asp:GridView>
            <br />
        </div>
    </asp:Panel>
    </center>
</asp:Content>

