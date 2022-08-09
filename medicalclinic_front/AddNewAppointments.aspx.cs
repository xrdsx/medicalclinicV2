using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class Formularz_internetowy1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button_AddNewAppointment.Enabled = true;

            if (!IsPostBack)
            {
                TextBox_Date.Text = Request.QueryString["selected_date"];


                List<Patient> patients = Patient.GetPatients(null, null, null, null).OrderBy(patient => patient.First_name).ThenBy(patient => patient.Second_name).ToList();
                foreach (Patient patient in patients)
                {
                    DropDownList_Patient.Items.Add(new ListItem(patient.First_name + " " + patient.Second_name + " - " + patient.Pesel, patient.Id.ToString()));
                }
                DropDownList_Patient.DataBind();

                List<MedicalSpecialization> specializations = MedicalSpecialization.getAllMedicalSpecialization();

                foreach (MedicalSpecialization specialization in specializations)
                {
                    DropDownList_Specialization.Items.Add(new ListItem(specialization.Name, specialization.Id.ToString()));
                }
                DropDownList_Specialization.DataBind();
                DropDownList_Specialization.AutoPostBack = true;
                DropDownList_Patient.AutoPostBack = true;
                DropDownList_Office.AutoPostBack = true;
                DropDownList_Doctor.AutoPostBack = true;
                TextBox_Date.AutoPostBack = true;
                TextBox_Payment.AutoPostBack = true;

            }

            if (DropDownList_Doctor.SelectedIndex < 0 || DropDownList_Office.SelectedIndex < 0 || DropDownList_Patient.SelectedIndex < 0 || DropDownList_Specialization.SelectedIndex < 0 || DropDownList_Available_hours.SelectedIndex < 0 || DateTime.Parse(TextBox_Date.Text) < DateTime.Now.Date || TextBox_Payment.Text == "")
            {
                Button_AddNewAppointment.Enabled = false;

            }
        }

        private void AlertBox(string AlertMessage, bool success)
        {
            string alert = "alert('" + AlertMessage + "');";
            if (success)
            {
                alert = "alert('" + AlertMessage + "'); window.open('AppointmentsManagement.aspx', '_self');";
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }
        protected void DropDownList_Specialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_Doctor.Items.Clear();
            DropDownList_Office.Items.Clear();

            int index=int.Parse(DropDownList_Specialization.SelectedValue);

            List<Employee> employees = Employee.SelectedEmployee(index, TextBox_Date.Text);
            foreach (Employee employee in employees)
            {
                DropDownList_Doctor.Items.Add(new ListItem(employee.First_name + " " + employee.Second_name, employee.Id.ToString()));
            }
            DropDownList_Doctor.DataBind();

            

            List<Office> offices = Office.GetSelected(index, TextBox_Date.Text);
            foreach (Office office in offices)
            {
                DropDownList_Office.Items.Add(new ListItem(office.Number_of_office, office.Id.ToString()));
            }
            DropDownList_Office.DataBind();

        }

        protected void Button_AddNewAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Appointment.ValidateDateOfVisit(DateTime.Parse(TextBox_Date.Text)))
                {
                    AlertBox("Oudated termin!", false);
                    return;
                }

                if (!Appointment.ValidatePayment(double.Parse(TextBox_Payment.Text)))
                {
                    AlertBox("Payment cannot be negative!", false);
                    return;
                }

                
                Appointment.AddNewAppointment(int.Parse(DropDownList_Doctor.SelectedValue.ToString()), int.Parse(DropDownList_Patient.SelectedValue.ToString()), int.Parse(DropDownList_Office.SelectedValue.ToString()), DateTime.Parse(TextBox_Date.Text), TimeSpan.Parse(DropDownList_Available_hours.SelectedItem.ToString()), double.Parse(TextBox_Payment.Text));
                Button_AddNewAppointment.Enabled = false;
                AlertBox("New appointment has been added", true);

            }
            catch (Exception)
            {
                AlertBox("Correct empty fields", false);
                return;
            }            
        }

        protected void Button_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppointmentsManagement.aspx");
        }
        
        protected void DropDownList_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableHours();
        }

        protected void DropDownList_Office_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableHours();
        }

        protected void DropDownList_Patient_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableHours();
        }

        protected void TextBox_Date_TextChanged(object sender, EventArgs e)
        {
            LoadAvailableHours();
        }
        private void LoadAvailableHours()
        {
            DropDownList_Available_hours.Items.Clear();
            int id_employee = 0;
            int id_patient = 0;
            int id_office = 0;
            DateTime selected_date = DateTime.Parse(TextBox_Date.Text);
            if (DropDownList_Doctor.SelectedIndex >= 0)
            {
                id_employee = int.Parse(DropDownList_Doctor.SelectedValue);
            }
            if(DropDownList_Office.SelectedIndex >= 0)
            {
                id_office = int.Parse(DropDownList_Office.SelectedValue);
            }
            if (DropDownList_Patient.SelectedIndex >= 0)
            {
                id_patient = int.Parse(DropDownList_Patient.SelectedValue);
            }

            if (id_employee != 0 && id_patient != 0 && id_office != 0 && selected_date >= DateTime.Now.Date)
            {
                List<Schedule> schedule = Schedule.GetAvailableHours(id_employee, id_patient, id_office, selected_date);
                foreach (Schedule s in schedule)
                {
                    DropDownList_Available_hours.Items.Add(s.Available_hour.ToString());
                }
                DropDownList_Available_hours.DataBind();
            }
        }
    }
}