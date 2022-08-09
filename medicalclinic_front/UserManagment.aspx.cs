using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using medicalclinic_back;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace medicalclinic
{
	public partial class UserManagment : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if(Session["role"].ToString() == "Administrator" || Session["role"].ToString()=="SuperAdmin")
            {
                Database.openConnection();
                MySqlDataAdapter dataAdapter = Database.dataAdapter("SELECT user_credentials.id, user_credentials.login, employees.first_name, employees.second_name, employees.email, user_credentials.is_active FROM user_credentials INNER JOIN employees ON employees.`id_credentials` = user_credentials.`id` ORDER BY user_credentials.id ASC;");
                DataTable employees = new DataTable();
                dataAdapter.Fill(employees);

                UserTable.DataSource = employees;
                UserTable.DataBind();
                Database.closeConnection();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewUser.aspx");
        }

        protected void UserEditBtn_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect("UserEdit.aspx?id =" + lnk.CommandArgument);
        }

        protected void Activity_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            int i = Convert.ToInt32(UserTable.DataKeys[rowIndex].Values[0]);
            EditUser.switchActivity(i);
            Page_Load(null, null);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            LoginUser.Time = Int32.Parse(TextBox1.Text);
        }
    }
}