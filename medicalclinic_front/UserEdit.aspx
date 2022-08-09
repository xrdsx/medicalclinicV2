<%@ Page Title="" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="medicalclinic.UserEdit" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="edit-form-wrapper">
    <div class="edit-form">
        <h2>Edit form</h2>
        <div class="role-box">
            <label for="MainContent_DropDownList1" class="dropdown-label">Role</label>
            <asp:DropDownList ID="DropDownList1" CssClass="dropdown-editform" runat="server"></asp:DropDownList>
        </div>
        <div class="login-box">
            <label for="MainContent_login" class="login-label">Login</label>
            <asp:TextBox ID="login" runat="server" CssClass="login-editform"></asp:TextBox>
        </div>
        <div class="active-checkbox-box">
            <asp:CheckBox ID="CheckBox1" CssClass="checkbox-label" runat="server" Text="Is active?"/>
            <asp:LinkButton ID="Button3_pass" CssClass="change-pass-editform" runat="server" Text="Change password" CommandArgument='<%# Eval("login") %>' OnClick="Button3_pass_Click" ></asp:LinkButton>
        </div>
        <div class="btns-box">
            <asp:Button ID="Button1" CssClass="btn-editform" runat="server" Text="Save" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" CssClass="btn-editform" runat="server" Text="Cancel" OnClick="Button2_Click" />
        </div>               
    </div>
    </div>
         <script>
            const cancelBtn = document.getElementById("MainContent_Button2")
            const roleList = document.getElementById("MainContent_DropDownList1");
            const loginInput = document.getElementById("MainContent_login")
            const isActive = document.getElementById("MainContent_CheckBox1")

            const currentRole = roleList.options[roleList.selectedIndex].textContent
            const currentLogin = loginInput.value
            const currentIsActive = isActive.checked

            function handleRoleList() {
                return roleList.options[roleList.selectedIndex].textContent
            }

            function handleLoginInput() {
                return loginInput.value
            }

            function handleIsActive() {
                return isActive.checked
            }

            function handleCancelButton(e) {
                e.preventDefault()         
            
                if (currentLogin !== handleLoginInput() || currentRole !== handleRoleList() || currentIsActive !== handleIsActive()) {
                    if (confirm("Dokonano zmian. Czy na pewno chcesz opuścić formularz?"))
                        location.href = 'UserManagment.aspx'

                        return;
                }

                location.href = 'UserManagment.aspx'
            }

            roleList.addEventListener('change', handleRoleList)
            cancelBtn.addEventListener('click', handleCancelButton)

        </script>
    </asp:Content>
