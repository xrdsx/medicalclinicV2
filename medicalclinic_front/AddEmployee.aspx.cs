using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;


namespace medicalclinic
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ComboboxRoleFill();
                ComboboxSpecializationFill();
                CalendarBirthDate.SelectedDate = DateTime.Today;
            }
            else
            {
                CalendarBirthDate.SelectedDate = DateTime.ParseExact(CalendarTextBox.Text, CalendarBirthDate.Format, null);
            }
            CalendarTextBox.Attributes.Add("readonly", "readonly");
        }

        private void ComboboxRoleFill()
        {
            List<UserRole> data = UserRole.getAllRoles();
            DropDownListRole.Items.Clear();
            DropDownListRole.DataSource = data;
            DropDownListRole.DataBind();
            DropDownListRole.DataTextField = "Name";
            DropDownListRole.DataValueField = "Id";
            DropDownListRole.DataBind();
        }

        private void ComboboxSpecializationFill()
        {
            List<MedicalSpecialization> data = MedicalSpecialization.getAllMedicalSpecialization();
            DropDownListSpecialization.Items.Clear();
            DropDownListSpecialization.DataSource = data;
            DropDownListSpecialization.DataBind();
            DropDownListSpecialization.DataTextField = "Name";
            DropDownListSpecialization.DataValueField = "Id";
            DropDownListSpecialization.DataBind();
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeManagement.aspx");
        }

        protected void TexBoxName_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        protected void TextBoxSurname_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        protected void TextBoxPESEL_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        private void IsEmpty()
        {
            if(string.IsNullOrEmpty(TextBoxName.Text) || string.IsNullOrEmpty(TextBoxSurname.Text) || string.IsNullOrEmpty(TextBoxPESEL.Text))
            {
                ButtonNext.Enabled = false;
                return;
            }

            ButtonNext.Enabled = true;
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            if (!Employee.ValidatePesel(TextBoxPESEL.Text, (DateTime)CalendarBirthDate.SelectedDate, DropDownListSex.SelectedValue))
            {
                AlertBox("Incorrect PESEL number.");
                return;
            }

            if(!Employee.ValidatePeselUnique(TextBoxPESEL.Text))
            {
                AlertBox("This PESEL is already in the database.");
                return;
            }

            if(!AdressCheck())
            {
                AlertBox("To add an address, all address fields must be completed.");
                    return;
            }

            if(TextBoxEmail.Text.Length>0)
            {
                if(!Employee.ValidateEmail(TextBoxEmail.Text))
                {
                    AlertBox("Incorrect e-mail adress.");
                    return;
                }
            }

            if (TextBoxPhoneNumber.Text!="" && TextBoxPhoneNumber.Text.Length != 9)
            {
                AlertBox("Incorrect phone number.");
                return;
            }



            string address_id = Address.insertNewAddress(TextBoxCountry.Text, TextBoxState.Text, TextBoxCity.Text, TextBoxPostalCode.Text, TextBoxStreet.Text, TextBoxHouseNumber.Text);

            string sexLongName = DropDownListSex.SelectedValue.ToString();
            string sex = "M";

            if (sexLongName == "Female")
            {
                sex = "F";
            }

            string employee_id = Employee.InsertNewEmployee(TextBoxName.Text, TextBoxSurname.Text, TextBoxPESEL.Text, sex, TextBoxPhoneNumber.Text, TextBoxEmail.Text, CalendarTextBox.Text, DropDownListRole.SelectedValue, address_id);

            if (CheckIsDoctorRoleSelected())
            {
                Employee.SetEmployeeSpecialization(employee_id, DropDownListSpecialization.SelectedValue);
            }

            if (TextBoxEmail.Text.Length > 0)
            {
                var smtpClient = new SmtpClient("vfczjombdo.cfolks.pl", 587);
                smtpClient.Credentials = new NetworkCredential()
                {
                    UserName = "tester@vfczjombdo.cfolks.pl",
                    Password = "hF-.cozq6O3I@-Za"
                };

                smtpClient.Send("tester@vfczjombdo.cfolks.pl", TextBoxEmail.Text, "MedicalClinic", "You were added as employee to our Medical Clinic Database, Congratulations (this message was generated for students project)");
            }

            AlertBox("New Employee has been added to database");
            OpenUserWindow(employee_id);
        }

        private bool CheckIsDoctorRoleSelected() {
            if (DropDownListRole.SelectedValue != "2")
            {
                return false;
            }
            else
                return true;
        }
        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CheckIsDoctorRoleSelected())
            {
                DropDownListSpecialization.Visible = false;
            }
            else
            { 
                DropDownListSpecialization.Visible = true;
            }
        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }

        private void OpenUserWindow(string employee_id) 
        {
            string window = "window.open('CreateNewUser.aspx?emp="+ employee_id +"', '_self');";
            ClientScript.RegisterStartupScript(this.GetType(), "openuserwindow", window, true);
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
    }
}