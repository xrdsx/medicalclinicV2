using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace medicalclinic_back
{

    public class Calendar_Appointments
    {
        private string name;
        private string surname;
        private string pesel;
        private string date;
        private string id;
        private string status;
        private string time;

        public string Date { get => date; set => date = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public string Id { set => id = value; }
        public string Status { get => status; set => status = value; }
        public string Time { get => time; set => time = value; }

        public Calendar_Appointments(string date, string name, string surname, string pesel, string status, string time)
        {
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.date = date;
            this.status = status;
            this.time = time;
        }

        public static List<Calendar_Appointments>Appointments(string name, string surname)
        {
            string p_name = name;
            string p_surname = surname;
            
            Database.openConnection();
            MySqlCommand command = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.status as Status, vis.time AS Time  FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.first_name like @name " + "AND pat.second_name like @surname ORDER BY Date ASC");

            command.Parameters.AddWithValue("@name", p_name);
            command.Parameters.AddWithValue("@surname", p_surname);
            MySqlDataReader data = command.ExecuteReader();

            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();

            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2),data.GetString(3), data.GetString(4), data.GetString(5));
                filters.Add(type);

            }
            data.Close();
            Database.closeConnection();
            return filters;
        }

        //filtrowanie imie met
        public static List<Calendar_Appointments> Filtr_byname(string name)
        {
            string p_name = name + "%";

            Database.openConnection();

            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, status as Status, vis.description as Description FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.first_name like @name ORDER BY Date ASC");
            query.Parameters.AddWithValue("@name", p_name);
            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5));
                filters.Add(type);
            }
            data.Close();

            Database.closeConnection();
            return filters;

        }

        //filtrowanie nazwisko
        public static List<Calendar_Appointments> Filtr_bysurname(string surname)
        {
            string p_surname = surname + "%";

            Database.openConnection();

            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.status as Status, vis.description as Description FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.second_name like @surname ORDER BY Date ASC");
            query.Parameters.AddWithValue("@surname", p_surname);
            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5));
                filters.Add(type);

            }
            data.Close();

            Database.closeConnection();
            return filters;
        }
        //filtrowanie pesel
        public static List<Calendar_Appointments> Filtr_bypesel(string pesel)
        {
            string p_pesel = pesel + "%";


            Database.openConnection();

            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.status as Status, vis.description AS Description  FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.pesel like @pesel ORDER BY Date ASC");
            query.Parameters.AddWithValue("@pesel", p_pesel);


            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5)/*, data.GetString(4), data.GetDateTime(5), data.GetString(6), data.GetString(7)*/);
                filters.Add(type);
            }
            data.Close();

            Database.closeConnection();
            return filters;
        }
        //filtrowanie imie + nazwisko
        public static List<Calendar_Appointments> Filtr_byname_and_surname(string name, string surname)
        {
            string p_name = name + "%";
            string p_surname = surname + "%";

            Database.openConnection();

            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.status as Status, vis.time AS Time  FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.first_name like @name " + "AND pat.second_name like @surname ORDER BY Date ASC");
            query.Parameters.AddWithValue("@name", p_name);
            query.Parameters.AddWithValue("@surname", p_surname);

            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3),data.GetString(4), data.GetString(5));
                filters.Add(type);
            }
            data.Close();

            Database.closeConnection();
            return filters;
        }

        //wyswietlanie kalendarza na cały miesiąc (szczegółowy)
        public static List<Calendar_Appointments> Calendar_details(int month, int year)
        {
            Database.openConnection();
            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.status as Status, vis.time AS Time  FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where month(date) =  @month AND year(date) = @year ORDER BY vis.date ASC");
            query.Parameters.AddWithValue("@year", year);
            query.Parameters.AddWithValue("@month", month);



            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5));
                filters.Add(type);
            }
            data.Close();

            Database.closeConnection();
            return filters;
        }

        //wyświetlanie szczegółów na wybrany dzień

        public static List<Calendar_Appointments> Calendar_sectionchanged(int day, int month)
        {
            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.status as Status, vis.time as Time FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where day(date) = @day AND month(date) = @month ORDER BY Name ASC");


            Database.openConnection();

            query.Parameters.AddWithValue("@day", day);
            query.Parameters.AddWithValue("@month", month);

            
            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5))/*, data.GetString(4), data.GetDateTime(5), data.GetString(6), data.GetString(7)*/;
                filters.Add(type);
            }
            data.Close();
            

            Database.closeConnection();
            return filters;
        }
        //dodanie nowej wizyty

        public static void PatientId(string name, string surname)
        {
            string p_name = name;
            string p_surname = surname;

            Database.openConnection();
            MySqlCommand query_id = Database.command("SELECT id_patient FROM patient WHERE first_name = @name and second_name = @surname");
            query_id.Parameters.AddWithValue("@name", p_name);
            query_id.Parameters.AddWithValue("@surname", p_surname);

            query_id.ExecuteNonQuery();

            Database.closeConnection();
        }
        public static void AddVisit(string name, string surname, string date, string time)
        {
            string p_name = name;
            string p_surname = surname;
            string p_date = date;
            string p_time = time;

            Database.openConnection();
            MySqlCommand query = Database.command("INSERT INTO visits(date, time, id_patient) VALUES (@date, @time, (SELECT id from patients where patients.first_name = @name AND patients.second_name = @surname))");
            query.Parameters.AddWithValue("@date", p_date);
            query.Parameters.AddWithValue("@time", p_time);
            query.Parameters.AddWithValue("@name", p_name);
            query.Parameters.AddWithValue("@surname", p_surname);

            query.ExecuteNonQuery();

            Database.closeConnection();
        }
        public static void SelectedDate(DateTime date)
        {

            DateTime p_date = date;
            Database.closeConnection();
        }

        public static void StatusChange(string status, DateTime date, string pesel)
        {
            string p_status = status;
            DateTime p_date = date;
            string p_pesel = pesel;
            
            Database.openConnection();
           
            MySqlCommand query_status = Database.command("UPDATE visits SET status = @status WHERE date = @date AND id_patient = (SELECT id from patients where pesel = @pesel)");
            query_status.Parameters.AddWithValue("@status", p_status);
            query_status.Parameters.AddWithValue("@date", p_date);
            query_status.Parameters.AddWithValue("@pesel", p_pesel);

            query_status.ExecuteNonQuery();
            Database.closeConnection();


        }
        public static void CancelAllAppointments(string status, DateTime date)
        {
            string p_status = status;
            DateTime p_date = date;


            Database.openConnection();

            MySqlCommand query_status = Database.command("UPDATE visits SET status = @status WHERE date = @date");
            query_status.Parameters.AddWithValue("@status", p_status);
            query_status.Parameters.AddWithValue("@date", p_date);

            query_status.ExecuteNonQuery();
            Database.closeConnection();
            

        }

        public static void StatusChanged(string status, string time, DateTime date, string name, string surname)
        {
            string p_status = status;
            string p_time = time;
            DateTime p_date = date;
            string p_name = name;
            string p_surname = surname;

            Database.openConnection();

            MySqlCommand query_status = Database.command("UPDATE visits SET status = @status  WHERE date = @date AND time = @time AND id_patient = (SELECT id from patients where first_name = @name AND second_name = @surname)");
            query_status.Parameters.AddWithValue("@status", p_status);
            query_status.Parameters.AddWithValue("@time", p_time);
            query_status.Parameters.AddWithValue("@date", p_date);
            query_status.Parameters.AddWithValue("@name", name);
            query_status.Parameters.AddWithValue("@surname", surname);

            query_status.ExecuteNonQuery();
            Database.closeConnection();
        }


        public static void AddResultToAppointment(DateTime date, string name, string surname, string description, string time)
        {
            string p_description = description;
            string p_time = time;
            DateTime p_date = date;
            string p_name = name;
            string p_surname = surname;

            Database.openConnection();

            MySqlCommand query_status = Database.command("UPDATE visits SET description = @description  WHERE date = @date AND time = @time AND id_patient = (SELECT id from patients where first_name = @name AND second_name = @surname)");
            query_status.Parameters.AddWithValue("@description", p_description);
            query_status.Parameters.AddWithValue("@time", p_time);
            query_status.Parameters.AddWithValue("@date", p_date);
            query_status.Parameters.AddWithValue("@name", name);
            query_status.Parameters.AddWithValue("@surname", surname);

            query_status.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void PatientHistory(string pesel)
        {
            string p_pesel = pesel + "%";

            Database.openConnection();
            MySqlCommand query_pathis = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.status as Status, vis.time AS Time, vis.description as result FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.pesel like @pesel ORDER BY Date ASC");
            query_pathis.Parameters.AddWithValue("@pesel", p_pesel);

            query_pathis.ExecuteNonQuery();

            Database.closeConnection();
        }

        public static void PatientHistory1(string pesel)
        {
            string p_pesel = pesel + "%";

            Database.openConnection();
            MySqlCommand query_pathis = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, vis.status as Status, vis.time AS Time, vis.description as result FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.pesel like @pesel ORDER BY Date ASC");
            query_pathis.Parameters.AddWithValue("@pesel", p_pesel);

            query_pathis.ExecuteNonQuery();

            Database.closeConnection();
        }
    }
}






