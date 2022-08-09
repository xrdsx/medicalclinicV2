using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class PopupConfirmOfficeDeletion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int officeID = 5; //jak przesłać wartość z poprzedniego okna
            string message;

            if (Office.CheckIfPlannedForFutureVisits(officeID))
            {
                message = "This office is planned for future visits so it can not be deleted!";
                AlertBox(message);
                return;
            }

            Office.DeleteOffice(officeID);
            message = "Office deleted successfully";
            AlertBox(message);
        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }
    }
}