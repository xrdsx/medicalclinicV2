<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDetails.aspx.cs" Inherits="medicalclinic.PatientDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<center>
<div style="height: 92.4vh; width: 80vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white">
    <div style="margin-top: 5vh">
        <asp:Label CssClass="Title" ID="LabelMessage" runat="server" Text="Patient Details"></asp:Label>
    </div>
    <div style="width: 85%; display: flex">
        <div style="border: solid; border-color: #EDF1F9; width: 20%; float: left; flex: 1">
            <asp:Label CssClass="LabelHead" ID="Label_paient" runat="server" Text="Patient data"></asp:Label>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_id" runat="server" Text="ID: "></asp:Label>
                <asp:Label CssClass="Value" ID="Label_id_value" runat="server" Text="Label"></asp:Label>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_first_name" runat="server" Text="First name: "></asp:Label>
                <asp:Label CssClass="Value" ID="Label_first_name_value" runat="server" Text="Label"></asp:Label>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_surname" runat="server" Text="Second name: "></asp:Label>
                <asp:Label CssClass="Value" ID="Label_surname_value" runat="server" Text="Label"></asp:Label>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_sex" runat="server" Text="Sex:"></asp:Label>
                <asp:Label CssClass="Value" ID="Label_sex_value" runat="server" Text="Label"></asp:Label>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_date_of_birth" runat="server" Text="Date of birth: "></asp:Label>
                <asp:Label CssClass="Value" ID="Label_date_of_birth_value" runat="server" Text="Label"></asp:Label>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_pesel" runat="server" Text="Pesel: "></asp:Label>
                <asp:Label CssClass="Value" ID="Label_pesel_value" runat="server" Text="Label"></asp:Label>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_phone_number" runat="server" Text="Phone number: "></asp:Label>
                <asp:Label CssClass="Value" ID="Label_phone_number_value" runat="server" Text="Label"></asp:Label>
            </div>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_email" runat="server" Text="Email: "></asp:Label>
                <asp:Label CssClass="Value" ID="Label_email_value" runat="server" Text="Label"></asp:Label>       
            </div>
            <div style="clear: both">
                <asp:Label CssClass="LabelDetails" ID="Label_activity" runat="server" Text="Status: "></asp:Label>
                <asp:Label CssClass="Value" ID="Label_activity_value" runat="server" Text="Not Active"></asp:Label>        
            </div>
        </div>

        <div style="border: solid; border-color: #EDF1F9; width: 61.5%; float: left; height: 100%;">
            <asp:Label CssClass="LabelHead" ID="Label_appointments" runat="server" Text="Patient appointments"></asp:Label>
            <asp:Panel runat="server" Height="260px" Width="100%" ScrollBars="Vertical">
                <asp:GridView CssClass="GridView" ID="GridViewAppointments" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" HeaderStyle ="position:absolute">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Duration" HeaderText="Duration">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description"/>
                        <asp:BoundField DataField="Employee" HeaderText="Doctor"/>
                        <asp:BoundField DataField="Office_number" HeaderText="Office number" />
                        <asp:BoundField DataField="Date_of_appointment" HeaderText="Appointment date" DataFormatString="{0:yyyy/MM/dd}"/>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>
    <div style="width: 85%; display: flex">
        <div style="border: solid; border-color: #EDF1F9; width: 61.5%; float: left; height: 100%">
            <div>
                <asp:Label CssClass="LabelHead" ID="Label_modify" runat="server" Text="Modify patient"></asp:Label>

                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label3" runat="server" Text="New first name: "></asp:Label>
                    <asp:TextBox CssClass="TextBox" ID="TextBox_first_name" runat="server" MaxLength="30"></asp:TextBox>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label5" runat="server" Text="New second name: "></asp:Label>
                    <asp:TextBox CssClass="TextBox" ID="TextBox_surname" runat="server" MaxLength="30"></asp:TextBox>
                </div>
                <div style="clear: both;">
                    <asp:Label CssClass="Label" ID="Label7" runat="server" Text="New sex:"></asp:Label>
                    <div style="display: inline-block;">
                        <asp:RadioButton CssClass="RadioButton" ID="RadioButton_sex_male" Text="Male" GroupName="sex" runat="server" />
                    <asp:RadioButton CssClass="RadioButton" ID="RadioButton_sex_female" Text="Female" GroupName="sex" runat="server"/>
                    </div>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label9" runat="server" Text="New date of birth: "></asp:Label>
                    <asp:TextBox CssClass="TextBox" ID="TextBox_date_of_birth" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label11" runat="server" Text="New Pesel: "></asp:Label>
                    <asp:TextBox CssClass="TextBox" ID="TextBox_pesel" runat="server" MaxLength="11"></asp:TextBox>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label13" runat="server" Text="New phone number: "></asp:Label>
                    <asp:TextBox CssClass="TextBox" ID="TextBox_phone_number" runat="server" MaxLength="9"></asp:TextBox>
                </div>
                <div style="clear: both">
                    <asp:Label CssClass="Label" ID="Label15" runat="server" Text="New email: "></asp:Label>
                    <asp:TextBox CssClass="TextBox" ID="TextBox_email" runat="server" MaxLength="100"></asp:TextBox>        
                </div>
                <div>
                    <asp:Button CssClass="Button" ID="Button_modify" runat="server" OnClientClick ="return ModifyAlertFunction()" Text="Modify" OnClick="Button_Modify_Click" Style="margin-top: 1.5vh"/>
                    <asp:HiddenField ID="ConfirmMessageResponseModify" runat="server" ClientIDMode="Static" />
                </div>
            </div>
        </div>
        <div style="border: solid; border-color: #EDF1F9; width: 20%; float: left; flex: 1">
            <asp:Label CssClass="LabelHead" ID="Label1" runat="server" Text="Other options"></asp:Label>
            <br />
            <div style="width: 50%; margin-top: 15%">
                <div>
                    <asp:Button CssClass="Button" ID="Button_delete" runat="server" OnClick="Button_Delete_Click" OnClientClick ="return DeleteAlertFunction()" Text="Delete" />
                    <asp:HiddenField ID="ConfirmMessageResponseDelete" runat="server" ClientIDMode="Static" />
                </div>
                <div>
                    <asp:Button CssClass="Button" ID="Button_activity" runat="server" Text="Activate Patient" OnClick="Button_activity_Click"/>
                </div>
                <div>
                    <asp:Button CssClass="Button" ID="Button_close" runat="server" OnClick="Button_close_Click" Text="Close" />
                </div>               
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
            font-size: 1.1vw;
            width: 100%;
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
            margin-top: 0.7vh;
            margin-bottom: 0.7vh;
            text-overflow: ellipsis;
            white-space:nowrap;
            overflow:hidden;
            
        }
        .Button:hover
        {
            background-color: white;
            color: #507CD1;
        }
        .LabelHead
        {
            text-align: center;
            color: #507CD1;
            font-weight: bold;
            font-size: 1.8vw;
            width: 100%;
            float: right;
            margin: 5px;
        }
        .TextBox
        {
            width: 50%;
            font-size: 1.7vmin;
            font-weight: lighter;
            float: right;
            margin-right: 2vw;
            margin-top: 0.8vh;
            display: block;
            height: 2.9vmin;
            text-overflow: ellipsis;
        }
        .Value
        {
            text-align: left;
            width: 60%;
            font-size: 1.7vmin;
            float: left;
            margin-top: 0.5vh;
            margin-left: 0.5vw;
            text-overflow: ellipsis;
            white-space:nowrap;
            overflow:hidden;
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
            width: 15vw;
            height: 2.9vmin;
            text-overflow: ellipsis;
            white-space:nowrap;
            overflow:hidden;
        }
        .LabelDetails
        {
            text-align: left;
            font-size: 1.7vmin;
            font-weight: lighter;
            float: left;
            display: block;
            margin-top: 0.5vh;
            margin-left: 0.5vw;
            width: 8.5vw;
            text-overflow: ellipsis;
            white-space:nowrap;
            overflow:hidden;
        }
        .RadioButton
        {
            float: left;
            margin-right: 4.5vw;
            display: block;
            font-size: 1.7vmin;
            font-weight: lighter;
            margin-top: 0.8vh;
        }
        input[type=radio]
        {
            width: 1.5vmin;
            height: 1.5vmin;
        }
        input[type=radio]:checked
        {
            width: 1.5vmin;
            height: 1.5vmin;
        }
        
        
    </style> 
    <script>     
        function DeleteAlertFunction() {
            if (confirm('Are you sure you want to remove this patient from the database?')) {
                $('#ConfirmMessageResponseDelete').val('Yes');
            }
            else {
                $('#ConfirmMessageResponseDelete').val('No');
            }
        }
        function ModifyAlertFunction() {
            if (confirm('Are you sure you want to modify data of this patient?')) {
                $('#ConfirmMessageResponseModify').val('Yes');
            }
            else {
                $('#ConfirmMessageResponseModify').val('No');
            }
        }
    </script>
</asp:Content>