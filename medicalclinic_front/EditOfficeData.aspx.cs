using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class EditOfficeData : System.Web.UI.Page
    {
        private static string oldOfficeNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            { 
            
                ComboBoxOfficeRolesFill();
                ComboBoxSpecializationFill();
                TextBoxID.Enabled = false;

                int id = int.Parse(Request.QueryString[0]);
                List<Office> offices = Office.GetAllOffices();

                foreach(Office off in offices)
                {
                if (off.Id != id)
                    {
                        continue;
                    }

                    TextBoxID.Text = off.Id.ToString();
                    TextBoxNumberOfOffice.Text = off.Number_of_office;
                    oldOfficeNumber = off.Number_of_office;
                    CheckBoxAvailibility.Checked = off.Avalibility;

                    int i = 0;
                    foreach (var item in DropDownListRoles.Items)
                    {
                        if (item.ToString() == off.Office_role.Name)
                        {
                            DropDownListRoles.SelectedIndex = i;
                        }
                        i++;
                    }

                    i = 0;
                    foreach (var item in DropDownListSpecializations.Items)
                    {
                        if (item.ToString() == off.Office_specialization.Name)
                        {
                            DropDownListSpecializations.SelectedIndex = i;
                        }
                        i++;
                    }

                    break;
                }
            }

        }

        private void ComboBoxSpecializationFill()
        {
            List<OfficeSpecialization> specializations = OfficeSpecialization.GetAllSpecializations();
            DropDownListSpecializations.Items.Clear();
            foreach (OfficeSpecialization spec in specializations)
            {
                DropDownListSpecializations.Items.Add(spec.Name);
            }
        }
        private void ComboBoxOfficeRolesFill()
        {
            List<OfficeUsedFor> roles = OfficeUsedFor.GetAllTypes();
            DropDownListRoles.Items.Clear();
            foreach (OfficeUsedFor role in roles)
            {
                DropDownListRoles.Items.Add(role.Name);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficesManagement.aspx");
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if(!Office.ValidateNumberUnique(TextBoxNumberOfOffice.Text, oldOfficeNumber))
            {
                string message = "Two offices can not have the same number";
                AlertBox(message);
                ButtonEdit.Enabled = false;
                return;
            }
            Office.EditOfficesData(Convert.ToInt32(TextBoxID.Text), TextBoxNumberOfOffice.Text, CheckBoxAvailibility.Checked, DropDownListRoles.SelectedValue, DropDownListSpecializations.SelectedValue);
            Response.Redirect("OfficesManagement.aspx");
        }


        private void valuesPicked()
        {
            if (TextBoxNumberOfOffice.Text == "" || DropDownListSpecializations.SelectedValue == null || DropDownListRoles.SelectedValue == null)
            {
                ButtonEdit.Enabled = false;
                return;
            }
            ButtonEdit.Enabled = true;

        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }

        protected void TextBoxNumberOfOffice_TextChanged1(object sender, EventArgs e)
        {
            foreach (char ch in TextBoxNumberOfOffice.Text)
            {
                if (!char.IsDigit(ch))
                {
                    TextBoxNumberOfOffice.Text = "";
                }
            }
            valuesPicked();
        }
    }
}