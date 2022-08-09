using System;
using medicalclinic_back;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;

namespace medicalclinic
{
    public partial class Calendar : System.Web.UI.Page
    {
        public string dropdownlist;
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar_main.VisibleDate = DateTime.Today;

                GridView_raportMonthly.DataBind();
            }
            try
            {
                Database.openConnection();
                MySqlConnection dbconn = new MySqlConnection();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
           Label9.Visible = false;
            Label10.Visible = false;
            ImageButton_gocalendar.Visible = false;
           GridView_raportMonthly.Visible = false;


        }

        protected void Calendar_main_DayRender(object sender, DayRenderEventArgs e)
        {
            DataTable datatab = Dates;
            DateTime eventDate;
            DateTime today = DateTime.Today;

            for (int i = 0; i < datatab.Rows.Count; i++)
            {
                eventDate = Convert.ToDateTime(datatab.Rows[i]["date"]);

                if (e.Day.Date == eventDate)
                {

                    e.Cell.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                    e.Cell.BackColor = System.Drawing.Color.FromArgb(80, 124, 209);

                }

            }
        }

        public DataTable Dates
        {
            get
            {
                Database.openConnection();
                DataTable datatab = new DataTable();
                MySqlCommand command = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, pat.sex as Sex, pat.date_of_birth AS Birth, pat.phone_number AS Phone, pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id");
                MySqlDataAdapter mysqlDataAd = new MySqlDataAdapter(command);
                mysqlDataAd.Fill(datatab);
                Database.closeConnection();
                return datatab;

            }
        }

        protected void Calendar_main_SelectionChanged(object sender, EventArgs e)
        {
            int day = Calendar_main.SelectedDate.Day;
            int month = Calendar_main.SelectedDate.Month;
            Label8.Visible = false;
            Calendar_main.Visible = false;
            Button_new.Visible = true;

            Label9.Visible = true;
            GridView_raportMonthly.Visible = true;
            GridView_Filter.Visible = false;
            ImageButton_gocalendar.Visible = true;
            Label10.Visible = true;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            Label14.Visible = false;
            Label3.Visible = false;
            TextBox_name_filter.Visible = false ;
            TextBox_pesel.Visible = false;
            TextBox_surname_filter.Visible = false;
            Button_filter.Visible = false;
            Button_Cancel_all.Visible = true;

            GridView_raportMonthly.Visible = true;


            GridView_raportMonthly.DataSource = Calendar_Appointments.Calendar_sectionchanged(day, month);
            GridView_raportMonthly.DataBind();
            Database.closeConnection();

            string selected = Calendar_main.SelectedDate.ToString();
            List<string> Calendar_seleteddate = new List<string>();
            Calendar_seleteddate.Add(selected);
        }

        protected void Button_filter_Click(object sender, EventArgs e)
        {
            GridView_Filter.DataBind();
            string name = TextBox_name_filter.Text;
            string surname = TextBox_surname_filter.Text;
            string pesel = TextBox_pesel.Text;


            if (TextBox_name_filter.Text.Length >= 1)
            {
                GridView_Filter.DataSource = Calendar_Appointments.Filtr_byname(name);
                GridView_Filter.DataBind();
            }
            else if (TextBox_surname_filter.Text.Length >= 1)
            {
                GridView_Filter.DataSource = Calendar_Appointments.Filtr_bysurname(surname);
                GridView_Filter.DataBind();
            }
            else if (TextBox_pesel.Text.Length >= 1)
            {
                GridView_Filter.DataSource = Calendar_Appointments.Filtr_bypesel(pesel);
                GridView_Filter.DataBind();
            }

            if (TextBox_name_filter.Text.Length >= 1 & TextBox_surname_filter.Text.Length >= 1)
            {
                GridView_Filter.DataSource = Calendar_Appointments.Filtr_byname_and_surname(name, surname);
                GridView_Filter.DataBind();
            }
           else if (TextBox_name_filter.Text.Length < 1 & TextBox_surname_filter.Text.Length < 1 & TextBox_pesel.Text.Length < 1)
            {
               Response.Write("<script>alert('Empty values')</script>");
            }

            TextBox_name_filter.Text = "";
            TextBox_surname_filter.Text = "";
            TextBox_pesel.Text = "";
        }
       

        protected void ImageButton_gocalendar1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar_main.Visible = true;
            GridView_raportMonthly.Visible = false;
            GridView_Filter.Visible = true;
            Label8.Visible = true;
            Label9.Visible = false;
            Label10.Visible = false;
            ImageButton_gocalendar.Visible = false;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label11.Visible = true;
            Label12.Visible = true;
            Label13.Visible = true;
            Label14.Visible = true;
            Label3.Visible = true;
            TextBox_name_filter.Visible = true;
            TextBox_pesel.Visible = true;
            TextBox_surname_filter.Visible = true;
            Button_filter.Visible = true;
            Button_Cancel_all.Visible = false;
            
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView_raportMonthly.DataBind();
            DropDownList DropDownList_status = (e.Row.FindControl("DropDownList_status") as DropDownList);
            dropdownlist = DropDownList_status.ToString();
        }

        protected void AcceptButton_Click(object sender, EventArgs e)
        {
            int day = Calendar_main.SelectedDate.Day;
            int month = Calendar_main.SelectedDate.Month;

    

            Label8.Visible = false;
            Calendar_main.Visible = false;
            Label9.Visible = true;
            GridView_raportMonthly.Visible = true;
            ImageButton_gocalendar.Visible = true;
            Label10.Visible = true;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            Label14.Visible = false;
            Label3.Visible = false;
            TextBox_name_filter.Visible = false;
            TextBox_pesel.Visible = false;
            TextBox_surname_filter.Visible = false;
            Button_filter.Visible = false;
            Button_Cancel_all.Visible = true;
            GridView_raportMonthly.Visible = true;



            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string name = GridView_raportMonthly.Rows[rowind].Cells[2].Text;
            string surname = GridView_raportMonthly.Rows[rowind].Cells[3].Text;
            string time = GridView_raportMonthly.Rows[rowind].Cells[6].Text;
            DateTime date = Convert.ToDateTime(GridView_raportMonthly.Rows[rowind].Cells[1].Text);

            Calendar_Appointments.StatusChanged(dropdownlist, time, date, name,surname);


            Database.openConnection();
            GridView_raportMonthly.DataSource = Calendar_Appointments.Calendar_sectionchanged(day, month);
            GridView_raportMonthly.DataBind();
            Database.closeConnection();

        }
        protected void SelectedIndexChanged2(object sender, EventArgs e)
        {
           
            DropDownList dropDownList = sender as DropDownList;
            dropdownlist = dropDownList.SelectedItem.Text;
        }
        protected void Button_Cancel_all_Click(object sender, EventArgs e)
        {
            int day = Calendar_main.SelectedDate.Day;
            int month = Calendar_main.SelectedDate.Month;
            Label8.Visible = false;
            Calendar_main.Visible = false;
            Label9.Visible = true;
            GridView_raportMonthly.Visible = true;
            ImageButton_gocalendar.Visible = true;
            Label10.Visible = true;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            Label14.Visible = false;
            Label3.Visible = false;
            TextBox_name_filter.Visible = false;
            TextBox_pesel.Visible = false;
            TextBox_surname_filter.Visible = false;
            Button_filter.Visible = false;
            GridView_raportMonthly.Visible = true;

            GridView_raportMonthly.DataSource = Calendar_Appointments.Calendar_sectionchanged(day, month);
            GridView_raportMonthly.DataBind();

            Database.closeConnection();

            string status = "Canceled";
            DateTime date = Calendar_main.SelectedDate;
            Calendar_Appointments.CancelAllAppointments(status,date);

            Response.Write("<script>alert('Status changed')</script>");

        }

        protected void Appointment_Description_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect("Calendar_AppointmentResults.aspx?id =" + lnk.CommandArgument);

        }

        protected void Button_new_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar_AppointmentAdd.aspx");
        }

        protected void GridView_Filter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Text = "Description";
            }
        }
    }

    
}
