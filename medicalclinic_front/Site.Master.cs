using System;
using System.Web.UI;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["role"].ToString() == "Administrator")
            {
                AdminPanel.Visible = true;
                
            }
            if(Session["role"].ToString() == "Pracownik")
            {
                EmployeePanel.Visible=true;
            }
            if(Session["role"].ToString()== "Lekarz")
            {
                DoctorPanel.Visible = true;
            }
            if(Session["role"].ToString()=="SuperAdmin")
            {
                SuperAdminPanel.Visible = true;
            }
        }

        protected void Users_Click(object sender, EventArgs e)
        {
            
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            LoginUser.logOut();
            Response.Redirect("Login.aspx");                
        }
    }
}