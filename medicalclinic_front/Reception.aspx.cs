using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class Reception : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_patients_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientsManagement.aspx");
        }

        protected void Button_appointments_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppointmentsManagement.aspx");
        }
    }
}