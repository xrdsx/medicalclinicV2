using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicalclinic_back
{
    public class OfficeSpecialization
    {
        private int id;
        private string name;

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }

        public OfficeSpecialization(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static List<OfficeSpecialization> GetAllSpecializations()
        {
            string query = "select id, name from office_specializations";
            Database.openConnection();

            MySqlCommand command = Database.command(query);
            MySqlDataReader data = command.ExecuteReader();

            List<OfficeSpecialization> specializations = new List<OfficeSpecialization>();

            while (data.Read())
            {
                OfficeSpecialization specialization = new OfficeSpecialization(data.GetInt32(0), data.GetString(1));
                specializations.Add(specialization);
            }
            Database.closeConnection();
            return specializations;

        }

       
    }
}
