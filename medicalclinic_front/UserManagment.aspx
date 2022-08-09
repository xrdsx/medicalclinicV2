<%@ Page Title="" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManagment.aspx.cs" Inherits="medicalclinic.UserManagment" EnableEventValidation="false"  %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="wrapper">

        <a href="./CreateNewUser.aspx" class="btn-new-user">Add an user</a>
        <div class="blockade-box">
             <asp:TextBox ID="TextBox1" runat="server" Text ="" ></asp:TextBox>
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Change the blockade" />
        </div>

        <div class="filters-box">
                <input type="text" value="" id="search-input" placeholder="Search for an user" />
&nbsp;<fieldset>
                <input type="checkbox" id="cb-firstname" class="check-box" checked />
                <label for="cb-firstname">Sort by name</label>
                <input type="checkbox" id="cb-secondname" class="check-box" />
                <label for="cb-secondname">Sort by surname</label>
            </fieldset>
        </div>
        <asp:GridView ID="UserTable" CssClass="user-managment-table" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
            
            <Columns>               
                <asp:BoundField DataField ="id" HeaderText ="ID"  />
                <asp:BoundField DataField ="login" HeaderText ="Login" />
                <asp:BoundField DataField ="first_name" HeaderText ="Name" />
                <asp:BoundField DataField ="second_name" HeaderText ="Surname" />
                <asp:BoundField DataField ="email" HeaderText ="E-mail" />
                <asp:BoundField DataField="is_active" HeaderText="Activity" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="UserEditBtn" runat="server" Text="Edit" CommandArgument='<%# Eval("id") %>' OnClick="UserEditBtn_Click" ></asp:LinkButton>
                    </ItemTemplate>  
                </asp:TemplateField>                
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="Activity" runat="server" CausesValidation="false" Text="Activate" OnClick="Activity_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </div>

    <script src="./Scripts/TableSort.js"></script>
</asp:Content>
