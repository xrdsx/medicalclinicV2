<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPatients.aspx.cs" Inherits="medicalclinic.ListPatients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView
        ID="PatientsDetailsGridView"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        AllowSorting="True"
        OnSorting="PatientsGridView_Sorting" Width="858px" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="PatientsGridView_SelectedIndexChanged" Height="16px"
        >
         <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true"/>
            <asp:BoundField DataField="First_name" HeaderText="First Name"/>
            <asp:BoundField DataField="Second_name" HeaderText="Surname"/>
            <asp:BoundField DataField="Pesel" HeaderText="Pesel"/>
            <asp:BoundField DataField="Sex" HeaderText="Sex" />
            <asp:BoundField DataField="Phone_number" HeaderText="Phone Number" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Date_of_birth" HeaderText="Date of Birth" DataFormatString="{0:yyyy/MM/dd}"/>
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        <asp:GridView
        ID="PatientsVisitsGridView"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        AllowSorting="True"
        OnSorting="PatientsGridView_Sorting" Width="858px" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="PatientsGridView_SelectedIndexChanged" Height="16px"
        >
         <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true"/>
            <asp:BoundField DataField="Duration" HeaderText="Duration"/>
            <asp:BoundField DataField="Type" HeaderText="Type"/>
            <asp:BoundField DataField="Id_employee" HeaderText="Employee ID"/>
            <asp:BoundField DataField="Id_office" HeaderText="Office ID" />
            <asp:BoundField DataField="Date_of_appointment" HeaderText="Appointment date" DataFormatString="{0:yyyy/MM/dd}"/>
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
     <div style="float:right">
        <asp:Button ID="ButtonAddNewPatient" runat="server" OnClick="ButtonAddNewPatient_Click"  Text="Add a patient" Width="122px" BackColor="#507CD1" BorderStyle="None" ForeColor="White" Height="25px" Font-Bold="True" />
        <br />
    </div>
    <div style="height: 48px; width: 236px; margin-top: 4px;">
         
        <br/>
        <asp:Label ID="LabelFilterMethod" runat="server" Text="Filter values: "></asp:Label>

    </div>
   
    <div>
        <asp:TextBox ID="TextBoxName" runat="server" Width="290px" placeholder ="Patient's name"></asp:TextBox>
        <asp:CheckBox ID="CheckBox_name" runat="server" Text="Filter by name"/>
    </div>
    <div>
        <asp:TextBox ID="TextBoxSurname" runat="server" Width="290px" placeholder ="Patient's surname"></asp:TextBox>
        <asp:CheckBox ID="CheckBox_surname" runat="server" Text="Filter by surname"/>
       
    </div>
    <div>
        <asp:TextBox ID="TextBoxPesel" runat="server" Width="290px" placeholder ="Patient's Pesel"></asp:TextBox>
        <asp:CheckBox ID="CheckBox_pesel" runat="server" Text="Filter by Pesel number"/>
    </div>
    <div>
        <asp:TextBox ID="TextBoxLastAppointmentDate" runat="server" Width="290px" placeholder ="Patient's last appointment date" MaxLength="10" TextMode="Date"></asp:TextBox>
        <asp:CheckBox ID="CheckBox_last_appointment_date" runat="server" Text="Filter by last appointment date"/>
    </div>
    <br />
        <asp:Button ID="ButtonFilter" runat="server" OnClick="ButtonFilter_Click" Text="Filter" Width="122px" BackColor="#507CD1" BorderStyle="None" ForeColor="White" Height="25px" Font-Bold="True"/>
        <asp:Button ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" Text="Reset" Width="122px" BackColor="#507CD1" BorderStyle="None" ForeColor="White" Height="25px" Font-Bold="True"/>
        <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonClose_Click" Text="Close" Width="122px" BackColor="#507CD1" BorderStyle="None" ForeColor="White" Height="25px" Font-Bold="True"/>
    <br />
        
    
     <asp:Panel runat="server" Height="300px" Width="74.6%"  ScrollBars="Vertical">
     <asp:GridView
        ID="PatientsGridView"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        AllowSorting="True"
        HeaderStyle ="position:absolute; font-weight: bold"
        OnSorting="PatientsGridView_Sorting" Width="856px" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="PatientsGridView_SelectedIndexChanged"
        >
         <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true" SortExpression="Id" />
            <asp:BoundField DataField="First_name" HeaderText="First Name" SortExpression="First_name" />
            <asp:BoundField DataField="Second_name" HeaderText="Surname" SortExpression="Second_name"/>
            <asp:BoundField DataField="Pesel" HeaderText="Pesel" SortExpression="Pesel"/>
            <asp:BoundField DataField="Date_of_last_appointment" HeaderText="Last Appointment Date" DataFormatString="{0:yyyy/MM/dd}"/>
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    </asp:Panel>
    <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>
    
     <br />

</asp:Content>