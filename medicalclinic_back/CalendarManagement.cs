using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicalclinic_back
{
    public class CalendarManagement
    {
        private int id;
        private Office office;
        private Employee doctor;
        private DateTime date;
        private int shift;

        public int Id { get => id; set => id = value; }
        public Office Office { get => office; set => office = value; }
        public Employee Doctor { get => doctor; set => doctor = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Shift { get => shift; set => shift = value; }

        public CalendarManagement(int id, Office office, Employee doctor, DateTime date, int shift)
        {
            this.Id = id;
            this.Office = office;
            this.Doctor = doctor;
            this.Date = date;
            this.shift = shift;
        }

        public static List<CalendarManagement> GetAllShedules()
        {
            string query = "select w.id, w.id_office, w.id_doctor, w.date, w.shift from work_hours as w left join offices on offices.id = w.id_office left join employees on employees.id = w.id_doctor";
            List<Office> offices = Office.GetAllOffices();
            List<Employee> employees = Employee.GetAllEmployees();
            Database.openConnection();
            MySqlCommand command = Database.command(query);
            List<CalendarManagement> shedules = new List<CalendarManagement>();
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Office off;
                Employee doctor;

                off = offices.Where(x => x.Id == reader.GetInt32(1)).ToList()[0];
                doctor = employees.Where(x => x.Id == reader.GetInt32(2)).ToList()[0];

                CalendarManagement s = new CalendarManagement(reader.GetInt32(0), off, doctor, reader.GetDateTime(3), reader.GetInt32(4));
                shedules.Add(s);
            }
            Database.closeConnection();
            return shedules;
        }

        public static void CreateNewShedule(int officeID, int doctorID, DateTime date, int shift)
        {
            string query = "insert into work_hours (id_office, id_doctor, date, shift) values (@office, @doctor, @data, @shift)";
            Database.openConnection();

            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@office", officeID);
            command.Parameters.AddWithValue("@doctor", doctorID);
            command.Parameters.AddWithValue("@data", date);
            command.Parameters.AddWithValue("@shift", shift);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void DeleteSchedule(int id)
        {
            string query = "delete from work_hours where id = @id";

            Database.openConnection();

            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            Database.closeConnection();

        }
    }
}
