using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace medicalclinic_back
{
    public class Schedule
    {
        private TimeSpan available_hour;

        public TimeSpan Available_hour { get => available_hour; set => available_hour = value; }

        public Schedule(TimeSpan available_hour)
        {
            this.Available_hour = available_hour;
        }
        public static List<Schedule> GetAvailableHours(int employee_id, int patient_id, int office_id, DateTime selected_date)
        {
            string e_id = "'" + employee_id.ToString() + "'";
            string p_id = "'" + patient_id.ToString() + "'";
            string o_id = "'" + office_id.ToString() + "'";
            string appointment_date = "'" + selected_date.ToString("yyyy-MM-dd") + "'";

            List<Schedule> available_hours = new List<Schedule>();
            TimeSpan minutes = new TimeSpan(0, 20, 0);
            TimeSpan end_hour = new TimeSpan(20, 0, 0);
            TimeSpan hour;
            if (selected_date.Date == DateTime.Now.Date)
            {
                if (DateTime.Now.Minute > 40)
                {
                    hour = new TimeSpan(DateTime.Now.Hour + 1, 0, 0);
                }
                else if (DateTime.Now.Minute > 20)
                {
                    hour = new TimeSpan(DateTime.Now.Hour, 40, 0);
                }
                else
                {
                    hour = new TimeSpan(DateTime.Now.Hour, 20, 0);
                }
            }
            else
            {
                hour = new TimeSpan(8, 0, 0);
            }

            while (hour < end_hour)
            {
                available_hours.Add(new Schedule(hour));
                hour += minutes;
            }

            Database.openConnection();
            string query = $"SELECT v.time FROM visits v WHERE (v.id_employee LIKE {e_id} OR v.id_patient LIKE {p_id} OR v.id_office LIKE {o_id}) AND v.date LIKE {appointment_date};";

            MySqlDataReader data = Database.dataReader(query);
            int index = 0;
            while (data.Read())
            {
                Schedule unapproachable_hour = new Schedule(data.GetTimeSpan(0));
                index = available_hours.FindIndex(a => a.available_hour == unapproachable_hour.available_hour);
                if (index != -1)
                {
                    available_hours.RemoveAt(index);
                }
            }
            Database.closeConnection();
            return available_hours;
        }

    }
}
