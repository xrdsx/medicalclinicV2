using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class SheduleCalendarForADay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Convert.ToDateTime(Request.QueryString["selected_date"]) < DateTime.Today)
                {
                    ButtonSubmit.Enabled = false;
                    LabelInfo.Text = "Please be aware that you are not allowed to create a schedule for the past date";
                }
                else
                {
                    ButtonSubmit.Enabled = true;
                    LabelInfo.Text = "Create a schedule for day: "+ Request.QueryString["selected_date"];
                    ViewState["selected_date"] = Request.QueryString["selected_date"];
                }

                FillInDropDownListOffices();
                FillInDropDownListDoctors(Employee.GetAllEmployees(filter_column: FilterColumnEmployee.Role, filter_query: "2"));
                FillInDropDownListShifts();
                DropDownListDoctors.SelectedIndex = 0;
                DropDownListOffices.SelectedIndex = 0;
                FillInGridViewShedules();
            }
        }

        private void FillInGridViewShedules()
        {
            List<CalendarManagement> shedulesForADay = CalendarManagement.GetAllShedules().Where(x => x.Date == Convert.ToDateTime(Request.QueryString["selected_date"])).ToList();
            if(shedulesForADay.Count > 0)
            {
                Label3.Text = "Schedules for this day";
                ShedulesGridView.DataSource = shedulesForADay;
                ShedulesGridView.DataBind();
            }
            else
            {
                Label3.Text = "There are no schedules created for this day";
            }

        }

        private void FillInDropDownListOffices()
        {
            List<Office> offices = Office.GetAllOffices();
            DropDownListOffices.Items.Clear();
            DropDownListOffices.Items.Add("--select--");

            foreach(Office o in offices)
            {
                DropDownListOffices.Items.Add(new ListItem(o.Number_of_office + " "+ o.Office_specialization.Name+ " "+o.Office_role.Name));
            }
            DropDownListOffices.DataBind();
        }

        private void FillInDropDownListDoctors(List<Employee> employees)
        {
            DropDownListDoctors.Items.Clear();
            DropDownListDoctors.Items.Add("--select--");
            foreach (Employee emp in employees)
            {
                DropDownListDoctors.Items.Add(new ListItem(emp.Id.ToString() +" "+emp.First_name + " " + emp.Second_name ));
            }
        }

        private void FillInDropDownListShifts() {
            DropDownListShifts.Items.Clear();
            DropDownListShifts.Items.Add("--select--");
            DropDownListShifts.Items.Add("8:00 - 14:00");
            DropDownListShifts.Items.Add("14:00 - 20:00");
        }

        protected void DropDownListOffices_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Office> offices = Office.GetAllOffices();
            
            if(DropDownListOffices.SelectedIndex == 0)
            {
                return;
            }
            Office off = offices[DropDownListOffices.SelectedIndex -1];
            string officeSpecialization = off.Office_specialization.Name;
            string dedicatedFor = off.Office_role.Name;
            List<Employee> doctors = Employee.GetAllEmployees();
            if (dedicatedFor.ToLower() != "general meetings" )
            {
                FillInDropDownListDoctors(doctors.Where(x => x.Medical_specialization.Name == officeSpecialization).ToList());
                return;
            }
            if(dedicatedFor.ToLower() == "general meetings")
            {
                FillInDropDownListDoctors(doctors.Where(x => x.Medical_specialization.Name == officeSpecialization || x.Medical_specialization.Name == "Pediatria" ).ToList());
                return;
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendarManagement.aspx");
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if(DropDownListDoctors.SelectedValue == "--select--" || DropDownListOffices.SelectedValue == "--select--" ||DropDownListShifts.SelectedValue == "--select--")
            {
                AlertBox("You have to choose a doctor, office and work hours");
                return;
            }
            int doctorID = int.Parse(DropDownListDoctors.SelectedValue.Split(' ')[0]);
            
            List<Office> offices = Office.GetAllOffices();
            Office off = offices[DropDownListOffices.SelectedIndex - 1];
            int officeID = off.Id;

            DateTime date = Convert.ToDateTime(Request.QueryString["selected_date"]);

            if (!Office.CheckIfOfficeIsAlreadyBooked(officeID, date, DropDownListShifts.SelectedIndex))
            {
                AlertBox("This office or shift are already booked. Please choose another one");
                return;
            }

            CalendarManagement.CreateNewShedule(officeID, doctorID, date, DropDownListShifts.SelectedIndex);
            AlertBox("New schedule successfully created");
            RedirectToThisDay();
        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }

        protected void LinkButtonDeleteSchedule_Click(object sender, EventArgs e) {
            LinkButton lb = sender as LinkButton;
            ViewState["id"] = lb.CommandArgument;
            PopupConfirmScheduleDeletion.Show();
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ViewState["id"].ToString());

            CalendarManagement.DeleteSchedule(id);
            AlertBox("Deleted successfully");
            RedirectToThisDay();
        }

        private void RedirectToThisDay()
        {
            string window = $"window.open('SheduleCalendarForADay.aspx?selected_date={ViewState["selected_date"].ToString()}', '_self');";
            ClientScript.RegisterStartupScript(this.GetType(), "openself", window, true);
        }
    }
}