using medicalclinic_back;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class Calendar_AddAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //bez tego nie ładuje poprzednich dat 
            {
                Calendar_date.VisibleDate = DateTime.Today;
            }
        }
        protected void Button_cancel_appo_Click(object sender, EventArgs e)
        {

        }

        protected void Button_accept_appo_Click(object sender, EventArgs e)
        {
            DateTime date = Calendar_date.SelectedDate.Date;
            string time = TextBox_time.Text;
            string name = TextBox_name.Text;
            string surname = TextBox_surname.Text;
            string duration = DropDownList_duration.SelectedValue;
            string office = DropDownList_office.SelectedValue;
            string id = DropDownList_id.SelectedValue;
            
           int confirmed;
           
            if (CheckBox_confirmed.Checked == true) 
            {
                confirmed = 1;
            }
            else
            {
                confirmed = 0;
            }



        }
        protected void Button_info_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
           string p_name = TextBox_name.Text;
           string p_surname = TextBox_surname.Text;

           
            GridView_infos.DataSource = Calendar_Appointments.Appointments(p_name, p_surname);
            GridView_infos.DataBind();































         
            
            
            
            
            
            
            
            
            
            
            
            
            string name = TextBox_name.Text;
            string surname = TextBox_surname.Text;
            Database.openConnection();
            MySqlCommand command = Database.command("SELECT id FROM patients where first_name = @name AND second_name = @surname");
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
            DropDownList_id.DataSource = command.ExecuteReader();
            DropDownList_id.DataTextField = "id";

            DropDownList_id.DataBind();

            Database.closeConnection();
        }

    }
}