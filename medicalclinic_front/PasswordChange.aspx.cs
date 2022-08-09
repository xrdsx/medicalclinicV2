using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["change_passw"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            IncorrectDataLabel.Visible = false;
            head_info.Text = "Zmiana hasła dla użytkownika: " + Session["change_passw_login"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!RecoveryPassword.isPasswordTheSame(new_passw.Text, confirm_passw.Text))
            {
                IncorrectDataLabel.Visible = true;
                IncorrectDataLabel.Text = "Podane hasła nie są identyczne. Spróbuj ponownie";
                return;
              
            }
            if(RecoveryPassword.passwordValidation(confirm_passw.Text) == false)
            {
                IncorrectDataLabel.Visible = true;
                IncorrectDataLabel.Text = "Niepoprawny format. Hasło musi zawierać minimum jedną wielką i małą literę, przynajmniej jeden znak specjalny i cyfrę. Minimalna długość hasła to 8 znaków";
                return ;
            }
            if (RecoveryPassword.changePassword(Session["change_passw_login"].ToString(), new_passw.Text))
            {
                IncorrectDataLabel.Visible = true;
                IncorrectDataLabel.Text = "Hasło zostało pomyślnie zmienione!";
            }
           
        }

        protected void returnBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            new_passw.Text = "";
            confirm_passw.Text = "";
        }
    }
}