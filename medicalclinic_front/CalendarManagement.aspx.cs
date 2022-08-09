using medicalclinic_back;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI;

namespace medicalclinic
{
    public partial class CallendarManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        
        protected void Calendar_work_hours_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.Equals(DateTime.Now.Date))
            {
                e.Cell.Controls.Add(new LiteralControl(" <div style='height: 2px; font-size: 1vw'>Today</div>"));
            }
            List<CalendarManagement> shedules = CalendarManagement.GetAllShedules();
            foreach (CalendarManagement s in shedules)
            {
                if (e.Day.Date.Equals(s.Date))
                {
                    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#82A3E0");
                }
            }
        }
        protected void Calendar_work_hours_SelectionChanged(object sender, EventArgs e)
        {
            string selected_date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            Response.Redirect(string.Format("~/SheduleCalendarForADay.aspx?selected_date={0}", selected_date));
        }


    }
}