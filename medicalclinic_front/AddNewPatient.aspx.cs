using medicalclinic_back;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class AddNewPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void AlertBox(string AlertMessage, bool success)
        {
            string alert = "alert('" + AlertMessage + "');";
            if (success)
            {
                alert = "alert('" + AlertMessage + "'); window.open('PatientsManagement.aspx', '_self');";
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }

        protected void ButtonAddNewPatient_Click(object sender, EventArgs e)
        {
            string sexLongName = DropDownListSex.SelectedValue.ToString();
            SexEnum sex = SexEnum.M;

            if (sexLongName == "Female")
            {
                sex = SexEnum.F;
            }
            
              

            if (!Patient.ValidateName(TextBoxName.Text))
            {
               AlertBox("Incorrect name!", false);
               return;
            }

            if (!Patient.ValidateSurname(TextBoxSurname.Text))
            {
               AlertBox("Incorrect surname!", false);
               return;
            }

            try
            {
                if (!Patient.ValidatePesel(TextBoxPesel.Text, DateTime.Parse(TextBoxDateOfBirth.Text), sex))
                {
                    AlertBox("Incorrectly entered pesel number, sex or date of birth!", false);
                    return;
                }
            }
            catch (Exception)
            {
                AlertBox("Pesel, date of birth and gender are mandatory to be filled in!", false);
                return;
            }

            if (!Patient.ValidatePhoneNumber(TextBoxPhoneNumber.Text))
            {
                AlertBox("Incorrect phone number!", false);
                return;
            }

            if (!Patient.ValidateEmail(TextBoxEmail.Text))
            {
                AlertBox("Incorrect e-mail address!", false);
                return;
            }

            if (!Patient.ValidatePeselUnique(TextBoxPesel.Text))
            {
                AlertBox("Patient with this pesel already exist in datebase!", false);
                return;
            }
            
            
            AlertBox("Patient has been added to the database!", true);

            Patient.AddNewPatient(TextBoxName.Text, TextBoxSurname.Text, TextBoxPesel.Text, sex.ToString(), TextBoxPhoneNumber.Text, TextBoxEmail.Text, TextBoxDateOfBirth.Text);

        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientsManagement.aspx");
        }
    }
}