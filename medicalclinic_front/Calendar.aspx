<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Calendar.aspx.cs" Inherits="medicalclinic.Calendar" %>

<asp:Content ID="Calendar" ContentPlaceHolderID="MainContent" runat="server">
        <div>                
            <center>
                <h1> 
                    <asp:Label ID="Label9" runat="server" Text="List of Appointments"></asp:Label>
                </h1>
                <asp:GridView ID="GridView_raportMonthly" runat="server" Height="85px" Width="724px" BorderColor="Black" CellPadding="6" CellSpacing="6" HorizontalAlign="Center" style="text-align: right;">
                        <EmptyDataRowStyle Font-Underline="True" />


                        <FooterStyle BackColor="Black" />
                        <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" Font-Italic="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="5px" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                    <asp:TemplateField>
                <ItemTemplate>
                 <asp:LinkButton ID="Appointment_DescriptionButton" OnClick="Appointment_Description_Click" runat="server" Text='Pick' Font-Bold="true"
                                   CommandArgument='
                                         <%# Eval("date") + ";" + Eval("Name") + ";" + Eval("Surname") + ";" + Eval("Pesel") + ";" + Eval("Time") %>' />
                                                
                            </asp:LinkButton>


                           <asp:LinkButton ID="Accept" OnClick="AcceptButton_Click" runat="server" Text='Accept'>
                            </asp:LinkButton>
                  
        <asp:DropDownList ID="DropDownList_status" runat="server" OnSelectedIndexChanged ="SelectedIndexChanged2">
            <asp:ListItem Enabled="true" Text="status" Value="-1"></asp:ListItem> 
              <asp:ListItem Text="Pending" Value="2"></asp:ListItem>
              <asp:ListItem Text="Accomplished" Value="3"></asp:ListItem>
              <asp:ListItem Text="Canceled" Value="4"></asp:ListItem>
              <asp:ListItem Text="Paid" Value="5"></asp:ListItem>
              <asp:ListItem Text="OutOfDate" Value="6"></asp:ListItem>
         </asp:DropDownList>
            </ItemTemplate>
</asp:TemplateField>
</Columns>
                    
                    </asp:GridView>
                <br />

                                    <asp:Button ID="Button_Cancel_all" runat="server" Text="Cancel all" OnClick="Button_Cancel_all_Click" Visible="False" />
                &nbsp;
                <br />
                <asp:Button ID="Button_new" runat="server" OnClick="Button_new_Click" Text="New appointment" />

                <h1> 

                    <asp:Label ID="Label10" runat="server" Text="Go to calendar"></asp:Label>
    &nbsp;<asp:ImageButton ID="ImageButton_gocalendar" runat="server" Height="35px" ImageUrl="~/Content/img/calendar_icone.png" OnClick="ImageButton_gocalendar1_Click" />
                </h1>

                <h1> 
                    <asp:Label ID="Label8" runat="server" Text="Calendar"></asp:Label>
                </h1>
                <asp:Calendar ID="Calendar_main" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellPadding="1" CellSpacing="5" Font-Names="MS UI Gothic" Font-Size="Large" ForeColor="Black" Height="900px" NextPrevFormat="ShortMonth" OnDayRender="Calendar_main_DayRender" Width="1200px" OnSelectionChanged="Calendar_main_SelectionChanged">
                    <DayHeaderStyle BorderStyle="Inset" Font-Bold="True" Font-Size="12pt" ForeColor="#333333" Height="8pt" />
                    <DayStyle BackColor="#edf1fa" BorderColor="White" BorderStyle="Solid" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" BorderWidth="10px" />
                    <NextPrevStyle Font-Bold="True" Font-Overline="False" Font-Size="12pt" Font-Strikeout="False" Font-Underline="True" ForeColor="White" HorizontalAlign="Left" />
                    <OtherMonthDayStyle BackColor="#F2F2F2" ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#EFB2B2" BorderStyle="None" ForeColor="White" BorderColor="#E06666" BorderWidth="10px" />
                    <SelectorStyle BorderColor="Black" BorderStyle="Dotted" />
                    <TitleStyle BackColor="#507CD1" BorderColor="#99BADD" BorderStyle="Double" Font-Bold="True" Font-Size="18pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#E06666" ForeColor="White" BorderColor="#E06666" BorderStyle="Solid" BorderWidth="11px" />
                    <WeekendDayStyle Font-Bold="True" Font-Italic="False" />
                </asp:Calendar>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                <div style="float: right;">
                    <asp:Label ID="Label5" runat="server" BackColor="#E06666" ForeColor="#E06666" Text="[.] "></asp:Label>
                    &nbsp;<asp:Label ID="Label6" runat="server" Text="  - Actual date "></asp:Label>
                    <asp:Label ID="Label4" runat="server" BackColor="#507CD1" BorderColor="#507CD1" ForeColor="#507CD1" Text="[.]  "></asp:Label>
                    &nbsp;<asp:Label ID="Label7" runat="server" Text="  - Appointment "></asp:Label>
                    &nbsp;<br />
                     <br />

                    <br />

                </div>

                <br />
                <br />
                <br />
                <br />



            </center>

        </div>
                    <div style="float:left; text-align:left; margin:10px; padding: 15px; width: 203px; height: 350px;">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Search" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        <br />
                <br/>
<asp:Label ID="Label3" runat="server" Text="Label">Find by </asp:Label>

                                    <br />
                        <asp:Label ID="Label12" runat="server" Text="Name"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_name_filter" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="Surname"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_surname_filter" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label14" runat="server" Text="Pesel"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_pesel" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button_filter" runat="server" Text="Find" Width="178px" OnClick="Button_filter_Click" />

                </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView_Filter" runat="server" BorderColor="Black" CellPadding="6" CellSpacing="6" Height="85px"  style="text-align: right; margin-left: 0px;" Width="751px" OnRowDataBound="GridView_Filter_RowDataBound">
            <EmptyDataRowStyle Font-Underline="True" />
            <FooterStyle BackColor="Black" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Italic="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="5px" Wrap="True" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>

                </asp:Content>