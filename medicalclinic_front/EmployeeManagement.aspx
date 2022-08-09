<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeManagement.aspx.cs" Inherits="medicalclinic.EmployeeManagement" %>

<asp:Content ID="EmployeeManagementContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-container">
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender
            ID="PopUpModalExtender"
            runat="server"
            PopupControlID="Panl1"
            TargetControlID="btnShowPopup"
            CancelControlID="HiddenButton"
            BackgroundCssClass="popout-background">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panl1" runat="server" CssClass="popup" align="center" Style="display: none">
            <asp:Label ID="MessageLabel" runat="server" Text="Log in with your admin password to continue"></asp:Label><br />
            <asp:TextBox ID="TextBoxLogin" placeholder="Login" runat="server" AutoPostBack="false"></asp:TextBox><br />
            <asp:TextBox ID="TextBoxPassword" placeholder="Password" type="password" runat="server" AutoPostBack="false"></asp:TextBox><br />
            <asp:Button CssClass="btn btn-default" ID="ConfirmButton" runat="server" Text="Confirm" OnClick="ConfirmButton_Click" Enabled="True" /><br />
            <br />
            <asp:Button CssClass="btn btn-default" ID="ButtonOK" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
            <asp:Button CssClass="btn btn-default" ID="HiddenButton" runat="server" Style="display: none" />
        </asp:Panel>
        <asp:Button ID="ButtonAdd" CssClass="btn btn-default btn-employee-add" runat="server" OnClick="ButtonAdd_Click" Text="Add New Employee" />
        <div class="table-content">
            <asp:GridView
                ID="EmployeesGridView"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                AllowSorting="true"
                OnSorting="EmployeesGridView_Sorting"
                CssClass="table table-hover table-condensed"
                OnRowCreated="EmployeesGridView_RowCreated">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="employees.id" />
                    <asp:BoundField DataField="First_name" HeaderText="First name" SortExpression="first_name" />
                    <asp:BoundField DataField="Second_name" HeaderText="Last name" SortExpression="second_name" />
                    <asp:BoundField DataField="Pesel" HeaderText="PESEL" SortExpression="pesel" />
                    <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="sex" />
                    <asp:BoundField DataField="Phone_number" HeaderText="Phone number" SortExpression="phone_number" />
                    <asp:BoundField DataField="Date_of_birth" DataFormatString="{0:d}" HeaderText="Date of birth" SortExpression="date_of_birth" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="email" />
                    <asp:CheckBoxField DataField="Is_active" HeaderText="Is active employee" SortExpression="is_active" />
                    <asp:BoundField DataField="User_department.Name" HeaderText="Department" SortExpression="departments.name" />
                    <asp:BoundField DataField="Medical_specialization.Name" HeaderText="Medical specialization" SortExpression="medical_specializations.name" />
                    <asp:BoundField DataField="User_role.Name" HeaderText="Role" SortExpression="user_roles.name" />
                    <asp:BoundField DataField="Address.Country" HeaderText="Country" SortExpression="user_adresses.country" />
                    <asp:BoundField DataField="Address.State" HeaderText="State" SortExpression="user_adresses.state" />
                    <asp:BoundField DataField="Address.City" HeaderText="City" SortExpression="user_adresses.city" />
                    <asp:BoundField DataField="Address.Postal_code" HeaderText="Postal code" SortExpression="user_adresses.postal_code" />
                    <asp:BoundField DataField="Address.Street" HeaderText="Street" SortExpression="user_adresses.street" />
                    <asp:BoundField DataField="Address.Number" HeaderText="Number" SortExpression="user_adresses.number" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton
                                ID="EmployeeReviewButton"
                                OnClick="EmployeeReviewButton_Click"
                                runat="server"
                                Text='Review employee'
                                CommandArgument='<%# Eval("Id") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton
                                ID="EmployeeEditButton"
                                OnClick="EmployeeEditButton_Click"
                                runat="server"
                                Text='Edit employee'
                                CommandArgument='<%# Eval("Id") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton
                                ID="IsActiveChange"
                                OnClick="LinkButtonEmployeeActiveChange_Click"
                                runat="server"
                                Text='Deactivate/Reactivate Employee'
                                CommandArgument='<%# Eval("Id") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="flex-container">
            <div class="filters-container">
                <div class="filters-container__element">
                    <asp:Label ID="LabelRoles" CssClass="filter-label-employee" runat="server" Text="Roles"></asp:Label>
                    <asp:DropDownList ID="DropDownListRoles" runat="server"></asp:DropDownList>
                    <asp:Button ID="ButtonFilterRoles" runat="server" OnClick="ButtonFilterRoles_Click" Text="Filter" CssClass="btn btn-default btn-filter-employee" />
                </div>
                <div class="filters-container__element">
                    <asp:Label ID="LabelIsActive" CssClass="filter-label-employee" runat="server" Text="Is active?"></asp:Label>
                    <asp:CheckBox ID="CheckBoxIsActive" CssClass="filter-checkbox-employee" runat="server" />
                    <asp:Button ID="ButtonFilterActive" runat="server" OnClick="ButtonFilterActive_Click" Text="Filter" CssClass="btn btn-default btn-filter-employee" />
                </div>
                <div class="filters-container__element">
                    <asp:Button ID="ButtonFilterClear" runat="server" OnClick="ButtonFilterClear_Click" Text="Clear filters" CssClass="btn btn-default btn-filter-employee" />
                </div>
            </div>
            <div>
                <div>
                    <asp:Button ID="Button3" runat="server" Text="Manage Calendar" OnClick="ManageCalendar_Click" CssClass="btn btn-default btn-filter-employee" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>








