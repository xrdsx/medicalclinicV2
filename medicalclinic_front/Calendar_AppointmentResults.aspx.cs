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
    public partial class Calendar_AppointmentResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //tworzymy liste stringów i odwołuje się do CommandArgument eval - linijka 20/21 plik Calendar.aspx i następnie pozbywamy się białych znaków - w tym przypadku średnika
                string[] array = Request.QueryString[0].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                //wywołujemy obiekty tablicy kolejno a w miejsce [] wstawiamy numer argumentu odpowiadającego temu co jest w kodzie - linijska 20/21 plik Calendar.aspx 
                string date = array[0];
                string name = array[1];
                string surname = array[2];
                string pesel = array[3];
                string time = array[4];
                TextBox_date.Text = date;
                TextBox_name.Text = name;
                TextBox_surname.Text = surname;
                TextBox_pesel.Text = pesel;

            }
        }

        protected void Button_Accept_Click(object sender, EventArgs e)
        {
            string[] array = Request.QueryString[0].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string time = array[4];



            string result = Request.Form["textArea_result"].ToString();
            DateTime date = Convert.ToDateTime(TextBox_date.Text);
            string name = TextBox_name.Text;
            string surname = TextBox_surname.Text;
            string pesel = TextBox_pesel.Text;


            if(result != "")
            {
                Calendar_Appointments.AddResultToAppointment(date, name, surname, result, time);

                Response.Redirect("Calendar.aspx");
            }
            else
            {
                Response.Write("<script>alert('Textarea is empty.')</script>");
            }



        }
        protected void Button_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }


        protected void Button_History_Click(object sender, EventArgs e)
        {


            DataTable datatab = PatientHistory;

            if (datatab.Rows.Count <= 0)
            {

            }
            else
            {
                GridView_patientHistory.DataSource = datatab;
                GridView_patientHistory.DataBind();
            }
        }

        public DataTable PatientHistory
        {
            get
            {
                string pesel = TextBox_pesel.Text;

                DataTable datatab = new DataTable();
                MySqlCommand query_pathis = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.time AS Time, vis.description as Description FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.pesel like @pesel ORDER BY Date ASC");
                query_pathis.Parameters.AddWithValue("@pesel", pesel);
                MySqlDataAdapter mysqlDataAd = new MySqlDataAdapter(query_pathis);
                mysqlDataAd.Fill(datatab);

                return datatab;
            }
        }
    }
}