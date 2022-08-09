using medicalclinic_back;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class Calendar_AppointmentAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_info_Click(object sender, EventArgs e)
        {
            string p_name = TextBox_name.Text;
            string p_surname = TextBox_surname.Text;


            GridView_infos.DataSource = Calendar_Appointments.Appointments(p_name, p_surname);
            GridView_infos.DataBind();
       
            string name = TextBox_name.Text;
            string surname = TextBox_surname.Text;
            string pesel = TextBox_surname0.Text;



                Database.openConnection();
                MySqlCommand command = Database.command("SELECT id FROM patients where first_name = @name AND second_name = @surname");
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);

                Database.closeConnection();


       
        }

        protected void Button_accept_appo_Click(object sender, EventArgs e)
        {
            if (TextBox_surname0.Text == null || TextBox_surname.Text == null)
            {

                Response.Write("<script>alert('Values can't be empty')</script>");
            }
            else
            {
                string date = TextBox_date.Text;
                string time = TextBox_time.Text;
                string name = TextBox_name.Text;
                string surname = TextBox_surname.Text;

                Calendar_Appointments.AddVisit(name, surname, date, time);
            }
            Response.Redirect("Calendar.aspx");
        }

        protected void Button_cancel_appo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }
    }
}
