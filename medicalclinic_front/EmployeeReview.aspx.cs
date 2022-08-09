using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                int id = int.Parse(Request.QueryString[0]);
                List<Employee> employees = Employee.GetAllEmployees();

                foreach (Employee emp in employees)
                {
                    if (id!=emp.Id)
                    {
                        continue;
                    }

                    TextBoxID.Text = emp.Id.ToString();
                    TextBoxName.Text = emp.First_name;
                    TextBoxSurname.Text = emp.Second_name;
                    TextBoxPESEL.Text = emp.Pesel;
                    TextBoxDateOfBirth.Text = emp.Date_of_birth.ToShortDateString();
                    TextBoxRole.Text = emp.User_role.Name;
                    TextBoxSpecialization.Text = emp.Medical_specialization.Name;
                    TextBoxCountry.Text = emp.Address.Country;
                    TextBoxState.Text = emp.Address.State;
                    TextBoxCity.Text = emp.Address.City;
                    TextBoxPostalCode.Text = emp.Address.Postal_code;
                    TextBoxStreet.Text = emp.Address.Street;
                    TextBoxHouseNumber.Text = emp.Address.Number;
                    TextBoxEmail.Text = emp.Email;
                    TextBoxPhoneNumber.Text = emp.Phone_number;

                    if(emp.Sex == SexEnum.F)
                    {
                        TextBoxSex.Text = "Female";
                    }
                    else
                    {
                        TextBoxSex.Text = "Male";
                    }

                    if(emp.Is_active)
                    {
                        TextBoxIsAcitve.Text = "Active user";
                    }
                    else
                    {
                        TextBoxIsAcitve.Text = "Inactive user";
                    }
                    
                }
         

            
            
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeManagement.aspx");
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeEdit.aspx?id =" + Request.QueryString[0]);
        }
    }
}