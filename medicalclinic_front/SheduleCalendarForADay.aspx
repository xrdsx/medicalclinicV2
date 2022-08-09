<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SheduleCalendarForADay.aspx.cs" Inherits="medicalclinic.SheduleCalendarForADay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-container">
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender
            ID="PopupConfirmScheduleDeletion"
            runat="server"
            PopupControlID="Panl1"
            TargetControlID="btnShowPopup"
            CancelControlID="ButtonOK"
            BackgroundCssClass="popout-background">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panl1" runat="server" CssClass="popup" align="center" Style="display: none">
            <div>
                <asp:Label ID="Label4" runat="server" Text="Do you want to delete this scheduled office and doctor?"></asp:Label>
                <br />
                <br />
            </div>
            <asp:Button CssClass="btn btn-default" ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="Confirm" />
            <br />
            <asp:Button CssClass="btn btn-default" ID="ButtonOK" runat="server" Text="Cancel" />
        </asp:Panel>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <asp:GridView
            ID="ShedulesGridView"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            CssClass="table table-hover table-condensed">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Office.Number_of_office" HeaderText="Number of office" />
                <asp:BoundField DataField="Office.Office_specialization.Name" HeaderText="Office specialization" />
                <asp:BoundField DataField="Office.Office_role.Name" HeaderText="Office role" />
                <asp:BoundField DataField="Doctor.First_name" HeaderText="Doctor name" />
                <asp:BoundField DataField="Doctor.Second_name" HeaderText="Doctor surname" />
                <asp:BoundField DataField="Doctor.Medical_specialization.Name" HeaderText="Medical speciazlization" />
                <asp:TemplateField HeaderText="Shift">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# (int)Eval("Shift") == 1 ? "8:00 - 14:00" : "14:00 - 20:00"   %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:yyyy/MM/dd}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton
                            ID="DeleteSchedule"
                            OnClick="LinkButtonDeleteSchedule_Click"
                            runat="server"
                            Text='Delete'
                            CommandArgument='<%# Eval("Id") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="office-add-container">
            <div class="office-add__element">
                <asp:Label ID="LabelInfo" runat="server" Text=""></asp:Label>
            </div>
            <div class="office-add__element">
                <asp:Label ID="Label1" runat="server" Text="Office" CssClass="margin-right"></asp:Label>
                <asp:DropDownList ID="DropDownListOffices" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownListOffices_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="office-add__element">
                <asp:Label ID="Label2" runat="server" Text="Doctor" CssClass="margin-right"></asp:Label>
                <asp:DropDownList ID="DropDownListDoctors" runat="server">
                </asp:DropDownList>
            </div>
            <div class="office-add__element">
                <asp:Label ID="Label5" runat="server" Text="Work hours" CssClass="margin-right"></asp:Label>
                <asp:DropDownList ID="DropDownListShifts" runat="server">
                </asp:DropDownList>
            </div>
            <div class="office-add__element">
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="ButtonCancel_Click" />
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="ButtonSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>
