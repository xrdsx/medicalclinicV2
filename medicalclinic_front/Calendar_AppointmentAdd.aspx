<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar_AppointmentAdd.aspx.cs" Inherits="medicalclinic.Calendar_AppointmentAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

<center><h3> Add new appointment </h3></center>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
<asp:TextBox ID="TextBox_name" runat="server" Height="30px" Width="165px"></asp:TextBox>
&nbsp;&nbsp;<br />
<asp:Label ID="Label2" runat="server" Text="Surname:"></asp:Label>
    <br />
<asp:TextBox ID="TextBox_surname" runat="server" Height="30px" Width="165px"></asp:TextBox>
    <br />
<asp:Label ID="Label5" runat="server" Text="Pesel:"></asp:Label>
    <br />
<asp:TextBox ID="TextBox_surname0" runat="server" Height="30px" Width="165px"></asp:TextBox>
    <br />
<br />
<asp:Button ID="Button_show" runat="server" OnClick="Button_info_Click" Text="Show patient visits" Width="169px" BorderStyle="Solid" />
    <br />
<br />
<asp:GridView ID="GridView_infos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" Width="609px">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
<br />
<asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
<br />
<asp:TextBox ID="TextBox_date" runat="server" TextMode="Date"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="Time:"></asp:Label>
<br />
<asp:TextBox ID="TextBox_time" runat="server" TextMode="Time"></asp:TextBox>
<br />
<br />
<br />
<asp:Button ID="Button_accept_appo" runat="server" OnClick="Button_accept_appo_Click" Text="Accept" Width="160px" OnClientClick="return confirm ('Do you want to add new appointment?');"/>
<asp:Button ID="Button_cancel_appo" runat="server" OnClick="Button_cancel_appo_Click" style="height: 26px" Text="Cancel" Width="160px" OnClientClick="return confirm ('Do you want to cancel?');"/>
        <br />

</asp:Content>
