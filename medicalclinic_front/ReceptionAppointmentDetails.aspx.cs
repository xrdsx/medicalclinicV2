using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class ReceptionAppointmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int selected_appointment_id = Int32.Parse(Request.QueryString["selected_appointment_id"]);
                List<Appointment> appointment = Appointment.GetThisAppointment(selected_appointment_id);
                Label_id_value.Text = appointment[0].Id.ToString();

                Label_date_value.Text = appointment[0].Date_of_appointment.ToString("yyyy-MM-dd");
                Label_time_value.Text = appointment[0].Time_of_appointment.ToString();
                TextBox_ndate.Text = appointment[0].Date_of_appointment.ToString("yyyy-MM-dd");
                Label_doctor_value.Text = appointment[0].Employee.ToString();
                Label_patient_value.Text = appointment[0].Patient.ToString();
                Label_office_value.Text = appointment[0].Office_number.ToString();
                Label_description_value.Text = appointment[0].Description;
                Label_payment_value.Text = appointment[0].Payment.ToString();
                Label_doctor_id.Text = appointment[0].Id_employee.ToString();
                Label_patient_id.Text = appointment[0].Id_patient.ToString();
                Label_office_id.Text = appointment[0].Id_office.ToString();
                TextBox_ndate.AutoPostBack = true;
                if (appointment[0].Confirmed == StatusEnum.Canceled)
                {
                    Label_status_value.Text = appointment[0].Confirmed.ToString();
                    Button_cancel.Enabled = false;
                }
                else
                {
                    Label_status_value.Text = appointment[0].Confirmed.ToString();
                }

                LoadAvailableHours();
                DropDownList_Available_hours.SelectedValue = DropDownList_Available_hours.Items.FindByText(Label_time_value.Text).Value;

            }
        }

        protected void Button_Cancel_Click(object sender, EventArgs e)
        {
            int selected_appointment_id = Int32.Parse(Request.QueryString["selected_appointment_id"]);
            string confirm_value = ConfirmMessageResponseDelete.Value;
            if (confirm_value == "Yes")
            {
                Appointment.CanceletionAppointment(selected_appointment_id);
                Response.Redirect(string.Format("~/ReceptionAppointmentDetails?selected_appointment_id={0}", selected_appointment_id));
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

        protected void Button_Reshedule_Click(object sender, EventArgs e)
        {

            try
            {
                if (!Appointment.ValidateDateOfVisit(DateTime.Parse(TextBox_ndate.Text)))
                {
                    AlertBox("Oudated termin!", false);
                    return;
                }

                if (!Appointment.ValidateTimeOfVisit(TimeSpan.Parse(DropDownList_Available_hours.SelectedItem.ToString()), DateTime.Parse(TextBox_ndate.Text)))
                {
                    AlertBox("Incorrect time!", false);
                    return;
                }
            }
            catch (Exception)
            {
                AlertBox("Correct empty fields", false);
                return;
            }


            int selected_appointment_id = Int32.Parse(Request.QueryString["selected_appointment_id"]);
            string confirm_value = ConfirmMessageResponseModify.Value;

            if (confirm_value == "Yes")
            {
                Appointment.ModifyAppointment(selected_appointment_id, TextBox_ndate.Text, DropDownList_Available_hours.SelectedItem.ToString()); ;

                Response.Redirect(string.Format("~/ReceptionAppointmentDetails?selected_appointment_id={0}", selected_appointment_id));
            }

        }

        protected void Button_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppointmentsManagement.aspx");
        }

        protected void TextBox_ndateTextChanged(object sender, EventArgs e)
        {
            LoadAvailableHours();
        }

        private void LoadAvailableHours()
        {
            DropDownList_Available_hours.Items.Clear();
            int id_employee = int.Parse(Label_doctor_id.Text);
            int id_patient = int.Parse(Label_patient_id.Text);
            int id_office = int.Parse(Label_office_id.Text);
            DateTime selected_date = DateTime.Parse(TextBox_ndate.Text);


            if (id_employee != 0 && id_patient != 0 && id_office != 0 && selected_date >= DateTime.Now.Date)
            {
                List<Schedule> schedule = Schedule.GetAvailableHours(id_employee, id_patient, id_office, selected_date);
                schedule.Add(new Schedule(TimeSpan.Parse(Label_time_value.Text)));
                schedule = schedule.OrderBy(s => s.Available_hour).ToList();
                foreach (Schedule s in schedule)
                {
                    DropDownList_Available_hours.Items.Add(s.Available_hour.ToString());
                }
                DropDownList_Available_hours.DataBind();
            }
        }
    }
}