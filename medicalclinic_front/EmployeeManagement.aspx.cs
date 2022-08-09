using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace medicalclinic
{
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                employeesGridRefresh();
        }

        private void employeesGridRefresh(string sort_column = "employees.id", SortDirection sort_direction = SortDirection.Ascending, FilterColumnEmployee filter_column = FilterColumnEmployee.Undefined, string filter_query = "1")
        {
            List<Employee> employees = Employee.GetAllEmployees(sort_column, sort_direction, filter_column, filter_query);
            ViewState["SortColumn"] = sort_column;
            ViewState["SortDirection"] = sort_direction;
            ViewState["FilterQuery"] = filter_query;
            ViewState["FilterColumn"] = filter_column;
            fillDropDownListsWithValues();
            setInitialValuesOnFilters();
            EmployeesGridView.DataSource = employees;
            EmployeesGridView.DataBind();
        }

        private void setInitialValuesOnFilters() {
            if ((FilterColumnEmployee)ViewState["FilterColumn"] == FilterColumnEmployee.Role)
            {
                DropDownListRoles.SelectedValue = ViewState["FilterQuery"].ToString();
            }
            if ((FilterColumnEmployee)ViewState["FilterColumn"] == FilterColumnEmployee.Active)
            {
                if (ViewState["FilterQuery"].ToString() == "1")
                    CheckBoxIsActive.Checked = true;
                else
                    CheckBoxIsActive.Checked = false;
            }
        }

        private void fillDropDownListsWithValues()
        {
            List<UserRole> data = UserRole.getAllRoles();
            DropDownListRoles.Items.Clear();
            foreach (UserRole role in data)
            {
                DropDownListRoles.Items.Add(role.Name);
            }
        }

        protected void ButtonFilterRoles_Click(object sender, EventArgs e)
        {
            string query = DropDownListRoles.SelectedValue;
            employeesGridRefresh(filter_column: FilterColumnEmployee.Role, filter_query: query);
        }

        protected void ButtonFilterActive_Click(object sender, EventArgs e)
        {
            string query = "";
            if (CheckBoxIsActive.Checked) query = "1";
            else query = "0";
            employeesGridRefresh(filter_column: FilterColumnEmployee.Active, filter_query: query);
        }

        protected void ButtonFilterClear_Click(object sender, EventArgs e)
        {          
            employeesGridRefresh();
        }

        protected SortDirection GetSortDirection(string column)
        {
            SortDirection nextDir = SortDirection.Ascending;
            if (ViewState["sort"] != null && ViewState["sort"].ToString() == column)
            {
                nextDir = SortDirection.Descending;
                ViewState["sort"] = null;
            }
            else
            {
                ViewState["sort"] = column;
            }
            return nextDir;
        }

        protected void EmployeesGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sort_column;
            SortDirection sort_direction = GetSortDirection(e.SortExpression);
            sort_column = e.SortExpression.ToString();
            employeesGridRefresh(sort_column, sort_direction);
        }
        protected void EmployeesGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell tc in e.Row.Cells)
                {
                    if (tc.HasControls())
                    {
                        LinkButton lnk = (LinkButton)tc.Controls[0];
                        if (lnk != null && ViewState["SortColumn"].ToString() == lnk.CommandArgument)
                        {
                            string sortArrow = (SortDirection)ViewState["SortDirection"] == SortDirection.Ascending ? " &#9650;" : " &#9660;";
                            lnk.Text += sortArrow;
                        }
                    }
                }
            }

            if ((FilterColumnEmployee)ViewState["FilterColumn"] == FilterColumnEmployee.Role)
            {
                LabelRoles.CssClass += " filters-container__element--active";
                LabelIsActive.CssClass = "filter-label-employee";

            }
            else if ((FilterColumnEmployee)ViewState["FilterColumn"] == FilterColumnEmployee.Active)
            {
                LabelIsActive.CssClass += " filters-container__element--active";
                LabelRoles.CssClass = "filter-label-employee";

            }
            else {
                LabelRoles.CssClass = "filter-label-employee";
                LabelIsActive.CssClass = "filter-label-employee";
            }

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }

        protected void EmployeeReviewButton_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect("EmployeeReview.aspx?id =" + lnk.CommandArgument);
        }

        protected void EmployeeEditButton_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect("EmployeeEdit.aspx?id =" + lnk.CommandArgument);
        }

        protected void ButtonOffices_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficesManagement.aspx");
        }

        protected void LinkButtonEmployeeActiveChange_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            ViewState["employee_id"] = lb.CommandArgument;
            PopUpModalExtender.Show();
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {

            if (!UserCredentials.IsLoginDataCorrect(TextBoxLogin.Text, TextBoxPassword.Text))
            {
                AlertBox("Incorrect login data!");
                return;
            }

            if (!UserCredentials.IsActiveAdmin(TextBoxLogin.Text))
            {
                AlertBox("No administrator permissions!");
                return;
            }
            Employee.ChangeActiveStatus(ViewState["employee_id"].ToString());
            AlertBox("Employee status has been changed");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            PopUpModalExtender.Hide();
        }

        private void AlertBox(string AlertMessage)
        {
            string script = "alert('" + AlertMessage + "'); window.location.href='EmployeeManagement.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", script, true);
        }

        protected void ManageCalendar_Click(object sender, EventArgs e) {
            Response.Redirect("CalendarManagement.aspx");
        }

    }
}
