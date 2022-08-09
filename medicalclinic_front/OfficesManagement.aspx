<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfficesManagement.aspx.cs" Inherits="medicalclinic.OfficesManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-container">
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender
            ID="PopupConfirmOfficeDeletion"
            runat="server"
            PopupControlID="Panl1"
            TargetControlID="btnShowPopup"
            CancelControlID="ButtonOK"
            BackgroundCssClass="popout-background">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panl1" runat="server" CssClass="popup" align="center" Style="display: none">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Do you want to delete this office?"></asp:Label>
                <br />
                <br />
            </div>
            <asp:Button CssClass="btn btn-default" ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="Confirm" />
            <br />
            <asp:Button CssClass="btn btn-default" ID="ButtonOK" runat="server" Text="Cancel" />
        </asp:Panel>
        <div class="table-content">
            <asp:GridView
                ID="OfficesGridView"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                CssClass="table table-hover table-condensed">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="Number_of_office" HeaderText="Number of office" />
                    <asp:CheckBoxField DataField="Avalibility" HeaderText="Is available" />
                    <asp:BoundField DataField="Office_specialization.Name" HeaderText="Specialization" />
                    <asp:BoundField DataField="Office_role.Name" HeaderText="Office role" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="OfficeEditButton" OnClick="OfficeEditButton_Click" runat="server" Text='Edit data'
                                CommandArgument='<%# Eval("Id") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton
                                ID="DeleteOffice"
                                OnClick="LinkButtonDeleteOffice_Click"
                                runat="server"
                                Text='Delete Office'
                                CommandArgument='<%# Eval("Id") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="office-add-container">
            <div class="office-add__element">
                <asp:Label ID="LabelNumberOfOffice" runat="server" Text="Number Of Office"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxNumberOfOffice" AutoPostBack="True" OnTextChanged="TextBoxNumberOfOffice_TextChanged" MaxLength="10" />
            </div>
            <div class="office-add__element">
                <asp:Label ID="LabelSpecialization" runat="server" Text="Office Specialization"></asp:Label>
                <asp:DropDownList ID="DropDownListSpecializations" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSpecializations_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="office-add__element">
                <asp:Label ID="LabelRole" runat="server" Text="Role Of Office"></asp:Label>
                <asp:DropDownList ID="DropDownListOfficeRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListOfficeRole_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <asp:Button ID="ButtonInsertOffice" runat="server" Text="Add New Office" CssClass="btn btn-default btn-filter-office" OnClick="ButtonInsertOffice_Click" />
        </div>
    </div>
</asp:Content>
