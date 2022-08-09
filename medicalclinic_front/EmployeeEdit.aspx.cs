using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using medicalclinic_back;
using System.Diagnostics;

namespace medicalclinic
{
    
    public partial class WebForm5 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            CalendarTextBox.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                ComboboxRoleFill();
                ComboboxSpecializationFill();

                int id = int.Parse(Request.QueryString[0]);
                List<Employee> employees = Employee.GetAllEmployees();


                foreach (Employee emp in employees)
                {
                    if (id != emp.Id)
                    {
                        continue;
                    }

                    TextBoxID.Text = emp.Id.ToString();
                    HideFieldIDAddress.Value = emp.Address.Id.ToString();
                    TextBoxName.Text = emp.First_name;
                    TextBoxSurname.Text = emp.Second_name;
                    TextBoxPESEL.Text = emp.Pesel;
                    ViewState["CurrentPesel"] = emp.Pesel;
                    CalendarBirthDate.SelectedDate = emp.Date_of_birth;
                    int i = 0;
                    foreach (var item in DropDownListRole.Items)
                    {
                        if (item.ToString() == emp.User_role.Name)
                        {
                            DropDownListRole.SelectedIndex = i;
                        }
                        i++;
                    }
                    if (emp.User_role.Name == "Lekarz")
                    {
                        DropDownListSpecialization.Visible = true;
                        SpecializationLabel.Visible = true;

                        i = 0;
                        foreach (var item in DropDownListSpecialization.Items)
                        {
                            if (item.ToString() == emp.Medical_specialization.Name)
                            {
                                DropDownListSpecialization.SelectedIndex = i;
                            }
                            i++;
                        }
                    }
                    TextBoxCountry.Text = emp.Address.Country;
                    TextBoxState.Text = emp.Address.State;
                    TextBoxCity.Text = emp.Address.City;
                    TextBoxPostalCode.Text = emp.Address.Postal_code;
                    TextBoxStreet.Text = emp.Address.Street;
                    TextBoxHouseNumber.Text = emp.Address.Number;
                    TextBoxEmail.Text = emp.Email;
                    TextBoxPhoneNumber.Text = emp.Phone_number;

                    if (emp.Sex == SexEnum.F)
                    {
                        DropDownListSex.SelectedIndex = 0;
                    }
                    else
                    {
                        DropDownListSex.SelectedIndex = 1;
                    }
                    ViewState["StartStatus"] = emp.Is_active;

                    if (emp.Is_active)
                    {
                        CheckBoxIsActive.Checked = true;
                    }
                    else
                    {
                        CheckBoxIsActive.Checked = false;
                    }
                    break;
                }
            }
            else 
            {
                CalendarBirthDate.SelectedDate = DateTime.ParseExact(CalendarTextBox.Text, CalendarBirthDate.Format, null);
            }
            
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeManagement.aspx");
        }


        private void ComboboxRoleFill()
        {
            List<UserRole> data = UserRole.getAllRoles();
            DropDownListRole.Items.Clear();
            foreach (UserRole role in data)
            {
                DropDownListRole.Items.Add(role.Name);
            }
        }

        private void ComboboxSpecializationFill()
        {
            List<MedicalSpecialization> data = MedicalSpecialization.getAllMedicalSpecialization();
            DropDownListSpecialization.Items.Clear();
            foreach (MedicalSpecialization spec in data)
            {
                DropDownListSpecialization.Items.Add(spec.Name);
            }
        }

        protected void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        private void IsEmpty()
        {
            if (string.IsNullOrEmpty(TextBoxName.Text) || string.IsNullOrEmpty(TextBoxSurname.Text) || string.IsNullOrEmpty(TextBoxPESEL.Text))
            {
                ButtonConfirm.Enabled = false;
                return;
            }

            ButtonConfirm.Enabled = true;
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (!Employee.ValidatePesel(TextBoxPESEL.Text, (DateTime)CalendarBirthDate.SelectedDate, DropDownListSex.SelectedValue))
            {
                AlertBox("incorrect pesel number");
                return;
            }

            
            if (!Employee.ValidatePeselUnique(TextBoxPESEL.Text) && TextBoxPESEL.Text!= ViewState["CurrentPesel"].ToString())
            {
                AlertBox("This pesel is already in the database");
                return;
            }

            if (!AdressCheck())
            {
                AlertBox("To add an address, all address fields must be completed");
                return;
            }

            if (TextBoxEmail.Text.Length > 0)
            {
                if (!Employee.ValidateEmail(TextBoxEmail.Text))
                {
                    AlertBox("incorrect e-mail adress");
                    return;
                }
            }

            if (TextBoxPhoneNumber.Text != "" && TextBoxPhoneNumber.Text.Length != 9)
            {
                AlertBox("incorrect phone number");
                return;
            }

            string sexLongName = DropDownListSex.SelectedValue.ToString();
            string sex = "M";

            if (sexLongName == "Female")
            {
                sex = "F";
            }

            if (CheckBoxIsActive.Checked!=(bool)ViewState["StartStatus"])
            {
                Employee.ChangeActiveStatus(TextBoxID.Text);
            }
            

            Employee.UpdateEmployee(TextBoxID.Text ,TextBoxName.Text, TextBoxSurname.Text, TextBoxPESEL.Text, sex, TextBoxPhoneNumber.Text, TextBoxEmail.Text, CalendarTextBox.Text);
            Address.updateAddress(HideFieldIDAddress.Value, TextBoxCountry.Text, TextBoxState.Text, TextBoxCity.Text, TextBoxPostalCode.Text, TextBoxStreet.Text, TextBoxHouseNumber.Text);

            AlertBox("User has been edited");
            RedirectToEmployeeManagenement();
        }

        protected void TextBoxSurname_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        protected void TextBoxPESEL_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListRole.SelectedValue != "Lekarz")
            {
                SpecializationLabel.Visible = false;
                DropDownListSpecialization.Visible = false;
                return;
            }

            SpecializationLabel.Visible = true;
            DropDownListSpecialization.Visible = true;
        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }

        private void RedirectToEmployeeManagenement()
        {
            string window = "window.open('EmployeeManagement.aspx', '_self');";
            ClientScript.RegisterStartupScript(this.GetType(), "openemployeemanagement", window, true);
        }


        private bool AdressCheck()
        {
            int notemptytextboxes = 0;
            int textboxescount = 0;
            TextBox currenttextbox;
            foreach (Control tbox in AddressPanel.Controls)
            {

                if (tbox is TextBox)
                {
                    textboxescount++;
                    currenttextbox = (TextBox)tbox;
                }
                else
                {
                    continue;
                }

                if (currenttextbox.Text.Length > 0)
                {
                    notemptytextboxes++;
                }
            }

            if (notemptytextboxes > 0 && notemptytextboxes < textboxescount)
            {
                return false;
            }

            return true;
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (!UserCredentials.IsLoginDataCorrect(TextBoxLogin.Text, TextBoxPassword.Text))
            {
                AlertBox("Incorrect login data!");
                return;
            }

            if (!UserCredentials.IsActiveAdmin(TextBoxLogin.Text))
            {
                AlertBox("No administrator permissions!");
                return;
            }
            CheckBoxIsActive.Checked= !CheckBoxIsActive.Checked;
            PopUpModalExtender.Hide();
        }


        protected void ButtonChangeActiveStatus_Click(object sender, EventArgs e)
        {
            TextBoxLogin.Text = string.Empty;
            TextBoxPassword.Text = string.Empty;
            PopUpModalExtender.Show();
        }
    }
}