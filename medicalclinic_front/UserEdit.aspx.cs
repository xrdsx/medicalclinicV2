using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class UserEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {       
            if(!IsPostBack)
            {
                ComboboxRoleFill();
                EditUser user = EditUser.getUser(getId());
                login.Text = user.Login;

                if (user.IsActive)
                    CheckBox1.Checked = true;
                else
                    CheckBox1.Checked = false;
                

                int i = 0;
                foreach (var item in DropDownList1.Items)
                {
                    if (item.ToString() == user.Role)
                    {
                        DropDownList1.SelectedIndex = i;
                    }
                    i++;
                }
            }
            
            
        }

        private void ComboboxRoleFill()
        {
            List<UserRole> data = UserRole.getAllRoles();
            DropDownList1.Items.Clear();
            foreach (UserRole role in data)
            {
                DropDownList1.Items.Add(role.Name);
               
            }
        }
        private int getId()
        {
            return int.Parse(Request.QueryString[0]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (login.Text == "")
            {
                Response.Write("<script>alert('" + "Zostawiłeś puste pole z loginem!. Uzupełnij pole aby kontynuować" + "')</script>");
                return;
            }
            int role_id = DropDownList1.SelectedIndex + 1;
            string new_login = login.Text;
            bool is_active;
            if (CheckBox1.Checked == true)
            {
                is_active = true;
            }
            else
            {
                is_active = false;
            }

            EditUser.editUser(getId(), new_login, is_active, role_id);
            Email.sendEmail("Nowe informacje na temat konta:      Login: " + new_login + " 	   Czy aktywny: " + is_active.ToString() + "         Rola: " + EditUser.getRoleName(getId()), "Zmiany na twoim koncie", "test.kacperkowalski@gmail.com");
           
        }

        private void AlertPopUp(string alertMessage)
        {
            string script = "confirm('" + alertMessage + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "confirm", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_pass_Click(object sender, EventArgs e)
        {
            try
            {
                
                Session["change_passw_login"] = login.Text;
                Session["change_passw"] = login.Text;
                Response.Redirect("PasswordChangeByAdmin.aspx");
            }
            catch (NullReferenceException)
            {

            }
        
        }

        
    }
}