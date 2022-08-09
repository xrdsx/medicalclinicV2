using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class PatientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int selected_patient_id = Int32.Parse(Request.QueryString["selected_patient_id"]);
                List<Patient> patient = Patient.GetThisPatient(selected_patient_id);
                Label_id_value.Text = patient[0].Id.ToString();

                if (patient[0].Activity == ActivityEnum.Y)
                {
                    Label_activity_value.Text = "Active";
                    Button_activity.Text = "Deactivate Patient";
                }
                Label_first_name_value.Text = patient[0].First_name;
                TextBox_first_name.Text = patient[0].First_name;
                Label_surname_value.Text = patient[0].Second_name;
                TextBox_surname.Text = patient[0].Second_name;
                if (patient[0].Sex == SexEnum.M)
                {
                    Label_sex_value.Text = "Male";
                    RadioButton_sex_male.Checked = true;
                }
                else
                {
                    Label_sex_value.Text = "Female";
                    RadioButton_sex_female.Checked = true;
                }
                Label_date_of_birth_value.Text = patient[0].Date_of_birth.ToString("yyyy-MM-dd");
                TextBox_date_of_birth.Text = patient[0].Date_of_birth.ToString("yyyy-MM-dd");
                Label_pesel_value.Text = patient[0].Pesel;
                TextBox_pesel.Text = patient[0].Pesel;
                Label_phone_number_value.Text = patient[0].Phone_number;
                TextBox_phone_number.Text = patient[0].Phone_number;
                Label_email_value.Text = patient[0].Email;
                TextBox_email.Text = patient[0].Email;

                List<Appointment> this_patient_appointments = Appointment.GetThisPatientAppointments(selected_patient_id);
                GridViewAppointments.DataSource = this_patient_appointments;
                GridViewAppointments.DataBind();
            }
        }
        protected void Button_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientsManagement.aspx");
        }
        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            int selected_patient_id = Int32.Parse(Request.QueryString["selected_patient_id"]);
            string confirm_value = ConfirmMessageResponseDelete.Value;
            if (confirm_value == "Yes")
            {
                Patient.DeletePatient(selected_patient_id);
                Response.Redirect("PatientsManagement.aspx");
            }
        }
        private void AlertBox(string AlertMessage, bool success)
        {
            string alert = "alert('" + AlertMessage + "');";
            if (success)
            {
                alert = "alert('" + AlertMessage + "'); window.open('ListPatients.aspx', '_self');";
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }
        protected void Button_Modify_Click(object sender, EventArgs e)
        {
            SexEnum sex = SexEnum.M;
            int selected_patient_id = Int32.Parse(Request.QueryString["selected_patient_id"]);
            string confirm_value = ConfirmMessageResponseModify.Value;
            if (RadioButton_sex_female.Checked)
            {
                sex = SexEnum.F;
            }
            if (!Patient.ValidateName(TextBox_first_name.Text))
            {
                AlertBox("Incorrect name!", false);
                return;
            }

            if (!Patient.ValidateSurname(TextBox_surname.Text))
            {
                AlertBox("Incorrect surname!", false);
                return;
            }
            try
            {
                if (DateTime.Parse(TextBox_date_of_birth.Text) > DateTime.Now)
                {
                    AlertBox("Incorrect date of birth field!", false);
                    return;
                }
            }
            catch
            {
                AlertBox("Empty date of birth field!", false);
                return;
            }
            if (!Patient.ValidatePhoneNumber(TextBox_phone_number.Text))
            {
                AlertBox("Incorrect phone number!", false);
                return;
            }
            if (!Patient.ValidateEmail(TextBox_email.Text))
            {
                AlertBox("Incorrect e-mail adress!", false);
                return;
            }
            if (!Patient.ValidatePesel(TextBox_pesel.Text, DateTime.Parse(TextBox_date_of_birth.Text), sex))
            {
                AlertBox("Pesel does not match date of birth or gender!", false);
                return;
            }
            if (TextBox_pesel.Text != Label_pesel_value.Text && !Patient.ValidatePeselUnique(TextBox_pesel.Text))
            {
                AlertBox("Patient with this pesel already exist in datebase!", false);
                return;
            }

            if (confirm_value == "Yes")
            {
                Patient.ModifyPatient(selected_patient_id, TextBox_first_name.Text, TextBox_surname.Text, TextBox_pesel.Text, sex.ToString(), TextBox_phone_number.Text, TextBox_email.Text, TextBox_date_of_birth.Text);
                Response.Redirect(string.Format("~/PatientDetails.aspx?selected_patient_id={0}", selected_patient_id));
            }
        }

        protected void Button_activity_Click(object sender, EventArgs e)
        {
            int selected_patient_id = Int32.Parse(Request.QueryString["selected_patient_id"]);
            List<Patient> patient = Patient.GetThisPatient(selected_patient_id);
            ActivityEnum activity = patient[0].Activity;
            if (activity == ActivityEnum.Y)
            {
                Patient.ChangePatientsActivity(selected_patient_id, ActivityEnum.N);
            }
            if (activity == ActivityEnum.N)
            {
                Patient.ChangePatientsActivity(selected_patient_id, ActivityEnum.Y);
            }
            Response.Redirect(string.Format("~/PatientDetails.aspx?selected_patient_id={0}", selected_patient_id));
        }
    }
}