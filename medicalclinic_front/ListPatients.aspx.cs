using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace medicalclinic
{
    public partial class ListPatients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false) //Checking if the page is loading for the first time
            {
                PatientsGridRefresh();
            }

        }
        private void PatientsGridRefresh(string sort_column = "p.id", string sort_direction = "ASC")
        {
            string p_name = null;
            string p_surname = null;
            string p_pesel = null;
            string last_apppointment_date = null;

            if (CheckBox_name.Checked || CheckBox_surname.Checked || CheckBox_pesel.Checked || CheckBox_last_appointment_date.Checked)
            {
                if (CheckBox_name.Checked && TextBoxName.Text != "")
                {
                    p_name = TextBoxName.Text;
                }
                if (CheckBox_surname.Checked && TextBoxSurname.Text != "")
                {
                    p_surname = TextBoxSurname.Text;
                }
                if (CheckBox_pesel.Checked && TextBoxPesel.Text != "")
                {
                    p_pesel = TextBoxPesel.Text;
                }
                if (CheckBox_last_appointment_date.Checked && TextBoxLastAppointmentDate.Text != "")
                {
                    last_apppointment_date = TextBoxLastAppointmentDate.Text;
                }
            }
            List<Patient> patients = Patient.GetPatients(p_name, p_surname, p_pesel, last_apppointment_date, sort_column, sort_direction);

            PatientsGridView.DataSource = patients;
            PatientsGridView.DataBind();

        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            PatientsGridRefresh();
        }
        protected string GetSortDirection(string column)
        {
            string nextDir = "ASC";
            if (ViewState["sort"] != null && ViewState["sort"].ToString() == column)
            {
                nextDir = "DESC";
                ViewState["sort"] = null;
            }
            else
            {
                ViewState["sort"] = column;
            }
            return nextDir;
        }

        protected void PatientsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sort_column;
            string sort_direction;
            string dir = GetSortDirection(e.SortExpression);
            switch (e.SortExpression)
            {
                case "Id":
                    sort_column = "Id";
                    if (dir == "ASC")
                    {
                        sort_direction = "DESC";
                    }
                    else
                    {
                        sort_direction = "ASC";
                    }
                    break;
                case "First_name":
                    sort_column = "First_name";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Second_name":
                    sort_column = "Second_name";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Pesel":
                    sort_column = "Pesel";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                default:
                    {
                        sort_column = "Id";
                        sort_direction = "DESC";
                    }
                    break;
            }
            PatientsGridRefresh(sort_column, sort_direction);
        }
        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxName.Text = "";
            TextBoxSurname.Text = "";
            TextBoxPesel.Text = "";
            TextBoxLastAppointmentDate.Text = "";
            CheckBox_name.Checked = false;
            CheckBox_surname.Checked = false;
            CheckBox_pesel.Checked = false;
            CheckBox_last_appointment_date.Checked = false;
            PatientsGridRefresh();
        }

        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void PatientsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = PatientsGridView.SelectedRow;
            string selected_patient_id = row.Cells[1].Text;
            Response.Redirect(string.Format("~/PatientDetails.aspx?selected_patient_id={0}", selected_patient_id));
        }

        protected void ButtonAddNewPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewPatient.aspx");
        }
    }
}