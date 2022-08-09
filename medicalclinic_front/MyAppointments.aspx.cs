using System;
using medicalclinic_back;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace medicalclinic
{
    public partial class MyAppointments : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable datatab = Appos;

            if (datatab.Rows.Count <= 0)
            {
                Label2.Visible = true;
                Label2.Text = "No appointments today.";
            }
            else
            {
                GridView_todays.DataSource = datatab;
                GridView_todays.DataBind();
            }

        }
        public DataTable Appos
        {
            get
            {
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;

                DataTable datatab = new DataTable();
                MySqlCommand command = Database.command("SELECT pat.first_name AS Name, pat.second_name AS Surname,  time AS Time, status AS Status FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where day(date) = @day AND month(date) =  @month AND year(date) = @year ORDER BY vis.date ASC");
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@month", month);
                command.Parameters.AddWithValue("@day", day);
                MySqlDataAdapter mysqlDataAd = new MySqlDataAdapter(command);
                mysqlDataAd.Fill(datatab);

                return datatab;

            }
        }
        protected void ImageButton_gocalendar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }
    }
}