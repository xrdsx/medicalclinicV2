using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicalclinic_back
{
    public class DayAppointment
    {
        List<int> DayApp = new List<int>();
        public int day;
        public int month;

        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        
        public DayAppointment(int day, int month)
        {
            this.Day = day;
            this.Month = month;
            

        }


        public static void Days(int day, int month)
        {
            List<int> DayApp = new List<int>();
            DayApp.Add(day);
            DayApp.Add(month);

        }


    }
}
