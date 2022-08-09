<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAppointments.aspx.cs" Inherits="medicalclinic.MyAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center><h3>List of appointments for today
        </h3>
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
            <center>
                <br />
                <br />
        </center>
        </center>
    <asp:GridView ID="GridView_todays" runat="server" AllowSorting="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="None" Height="85px" HorizontalAlign="Center" style="text-align: right;" Width="724px">
        <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" VerticalAlign="Middle" />
        <EditRowStyle BackColor="#7C6F57" />
        <EmptyDataRowStyle Font-Underline="True" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Width="5px" Wrap="True" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EDF1FA" BorderColor="Black" BorderStyle="Ridge" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Middle" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />


         <Columns>
                    <asp:TemplateField>
                <ItemTemplate>
       
            </ItemTemplate>
</asp:TemplateField>
</Columns>
    </asp:GridView>
    <center>
        <h4>Go to the calendar&nbsp; <asp:ImageButton ID="ImageButton_gocalendar" runat="server" Height="35px" ImageUrl="~/Content/img/calendar_icone.png" OnClick="ImageButton_gocalendar_Click" />
        </h4>
    </center>
  <center style="margin-left: 200px">
  </center>  
</asp:Content>
