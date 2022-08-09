using medicalclinic_back;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI;

namespace medicalclinic
{
    public partial class ListAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selected_date = Request.QueryString["selected_date"];
            int employee_id = Int32.Parse(Request.QueryString["employee_id"]);
            int patient_id = Int32.Parse(Request.QueryString["patient_id"]);
            int office_id = Int32.Parse(Request.QueryString["office_id"]);
            Label_date.Text = Label_date.Text + selected_date;
            List<Appointment> appointments = Appointment.GetAppointments(employee_id, patient_id, office_id, selected_date);
            GridViewAppointments.DataSource = appointments;
            GridViewAppointments.DataBind();
            if(DateTime.Parse(selected_date).Date < DateTime.Now.Date)
            {
                Button_addnewappointment.Enabled = false;
                Button_addnewappointment.Visible = false;
            }
        }
        protected void GridViewAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewAppointments.SelectedRow;
            string selected_appointment_id = row.Cells[1].Text;
            Response.Redirect(string.Format("~/ReceptionAppointmentDetails.aspx?selected_appointment_id={0}", selected_appointment_id));
        }
        protected void Button_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppointmentsManagement.aspx");
        }
        protected void Button_addnewappointment_Click(object sender, EventArgs e)
        {
            string selected_date = Request.QueryString["selected_date"];
            Response.Redirect(string.Format("~/AddNewAppointments.aspx?selected_date={0}", selected_date));
        }
    }
}