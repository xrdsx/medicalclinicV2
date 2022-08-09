using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicalclinic_back
{
    public class Office
    {
        private int id;
        private string number_of_office;
        private bool avalibility;
        private OfficeSpecialization office_specialization;
        private OfficeUsedFor office_role;


        public int Id { get => id; set => id = value; }
        public string Number_of_office { get => number_of_office; set => number_of_office = value; }
        public bool Avalibility { get => avalibility; set => avalibility = value; }
        public OfficeSpecialization Office_specialization { get => office_specialization; set => office_specialization = value; }
        public OfficeUsedFor Office_role { get => office_role; set => office_role = value; }


        public Office(int id, string number_of_office, bool avalibility, OfficeSpecialization office_specialiation,OfficeUsedFor role)
        {
            this.id = id;
            this.number_of_office = number_of_office;
            this.avalibility = avalibility;
            this.office_specialization = office_specialiation;
            this.office_role = role;
        }

        public static List<Office> GetAllOffices()
        {
            Database.openConnection();
            string query = "select offices.id, number_of_office, avalibility, office_specializations.id, office_specializations.name, used_for.id, used_for.type from offices left join office_specializations on offices.id_office_specialization = office_specializations.id left join used_for on offices.id_used_for = used_for.id";

            MySqlCommand command = Database.command(query);
            MySqlDataReader data = command.ExecuteReader();

            List<Office> offices = new List<Office>();
            while (data.Read())
            {
                OfficeSpecialization specialization;
                OfficeUsedFor role;


                if(data.GetValue(3) == DBNull.Value)
                {
                    specialization = new OfficeSpecialization(-1, string.Empty);
                }
                else
                {
                    specialization = new OfficeSpecialization(data.GetInt32(3), data.GetString(4));
                }

                if (data.GetValue(5) == DBNull.Value)
                {
                    role = new OfficeUsedFor(-1, string.Empty);
                }
                else
                {
                    role = new OfficeUsedFor(data.GetInt32(5), data.GetString(6));
                }

                Office office = new Office(data.GetInt32(0), data.GetString(1), data.GetBoolean(2), specialization,role);

                offices.Add(office);
            }
            Database.closeConnection();
            return offices;
        }

        public static void InsertNewOffice(string number, string specialization, string role)
        {
            Database.openConnection();
            string query = "insert into offices (id_office_specialization,id_used_for,number_of_office) values(@idSpecialization,@idUsedFor,@numberOfOffice)";

            MySqlCommand command = Database.command(query);
            int specID = 0;
            foreach(OfficeSpecialization spec in OfficeSpecialization.GetAllSpecializations())
            {
                if(spec.Name == specialization)
                {
                    specID = spec.Id;
                    break;
                }
            }

            int roleID = 0;
            foreach (OfficeUsedFor type in OfficeUsedFor.GetAllTypes())
            {
                if(type.Name == role)
                {
                    roleID = type.Id;
                    break;
                }
            }

            command.Parameters.AddWithValue("@idSpecialization", specID);
            command.Parameters.AddWithValue("@idUsedFor", roleID);
            command.Parameters.AddWithValue("@numberOfOffice", number);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void EditOfficesData(int id, string number, bool availibility, string role, string specialization)
        {
            Database.openConnection();
            string query = "update offices set number_of_office = @numberOfOffice, avalibility = @isAvailable, id_office_specialization = @idSpec, id_used_for = @idRole where offices.id = @id";

            MySqlCommand command = Database.command(query);

            int specID = 0;
            foreach (OfficeSpecialization spec in OfficeSpecialization.GetAllSpecializations())
            {
                if (spec.Name == specialization)
                {
                    specID = spec.Id;
                    break;
                }
            }

            int roleID = 0;
            foreach (OfficeUsedFor type in OfficeUsedFor.GetAllTypes())
            {
                if (type.Name == role)
                {
                    roleID = type.Id;
                    break;
                }
            }

            command.Parameters.AddWithValue("@idSpec", specID);
            command.Parameters.AddWithValue("@idRole", roleID);
            command.Parameters.AddWithValue("@numberOfOffice", number);
            command.Parameters.AddWithValue("@isAvailable", availibility);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static bool CheckIfPlannedForFutureVisits(int officeID)
        {
            string query = "select count(*) from visits where date >= @data and id_office = @id";
            Database.openConnection();

            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@id", officeID);


            Int32 futureVisits = (Int32)(long)command.ExecuteScalar();
            Database.closeConnection();

            if(futureVisits >= 1)
            {
                return true;
            }
            return false;
        }

        public static void DeleteOffice(int officeID)
        {

            deleteVisitsForTheOffice(officeID);
            string query = "delete from offices where id = @id";

            Database.openConnection();

            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@id", officeID);

            command.ExecuteNonQuery();
            Database.closeConnection();

        }

        private static void deleteVisitsForTheOffice(int officeID)
        {
            string query = "delete from visits where id_office = @id";

            Database.openConnection();

            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@id", officeID);

            command.ExecuteNonQuery();
            Database.closeConnection();

        }

        public static bool ValidateNumberUnique(string numberOfOffice)
        {
            return checkIfNumberIsUnique(numberOfOffice);
        }

        public static bool ValidateNumberUnique(string newNumberOfOffice, string oldNumberOfOffice)
        {
            if(newNumberOfOffice != oldNumberOfOffice)
            {
                return checkIfNumberIsUnique(newNumberOfOffice);
            }
            
            return true;
        }

        private static bool checkIfNumberIsUnique(string numberOfOffice)
        {
            string query = "select count(*) from offices as o where o.number_of_office = @number";

            Database.openConnection();

            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@number", numberOfOffice);

            Int32 offices = (Int32)(long)command.ExecuteScalar();
            Database.closeConnection();

            if(offices == 0)
            {
                return true;
            }
            return false;
        }

        public static List<Office> GetSelected(int index, string date)
        {
            Database.openConnection();
            string query = @"select offices.id, number_of_office, avalibility, office_specializations.id, office_specializations.name, used_for.id, used_for.type from offices INNER JOIN office_specializations on offices.id_office_specialization = office_specializations.id INNER JOIN used_for on offices.id_used_for = used_for.id INNER JOIN work_hours ON work_hours.id_office = offices.id WHERE office_specializations.id = @index AND work_hours.date = @date";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@index", index);
            command.Parameters.AddWithValue("@date", date);

            MySqlDataReader data = command.ExecuteReader();
            List<Office> offices = new List<Office>();
            while (data.Read())
            {
                OfficeSpecialization specialization;
                OfficeUsedFor role;


                if (data.GetValue(3) == DBNull.Value)
                {
                    specialization = new OfficeSpecialization(-1, string.Empty);
                }
                else
                {
                    specialization = new OfficeSpecialization(data.GetInt32(3), data.GetString(4));
                }

                if (data.GetValue(5) == DBNull.Value)
                {
                    role = new OfficeUsedFor(-1, string.Empty);
                }
                else
                {
                    role = new OfficeUsedFor(data.GetInt32(5), data.GetString(6));
                }

                Office office = new Office(data.GetInt32(0), data.GetString(1), data.GetBoolean(2), specialization, role);

                offices.Add(office);
            }
            Database.closeConnection();
            return offices;
        }

        public static bool CheckIfOfficeIsAlreadyBooked(int officeID, DateTime date, int shift)
        {
            Database.openConnection();
            string query = "select count(*) from work_hours as w where w.id_office = @office and date = @data and shift = @shift";
            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@office", officeID);
            command.Parameters.AddWithValue("@data", date);
            command.Parameters.AddWithValue("@shift", shift);

            Int32 offices = (Int32)(long)command.ExecuteScalar();
            Database.closeConnection();
            if (offices == 0)
            {
                return true;
            }
             return false;
        }

    }
}
