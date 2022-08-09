using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace medicalclinic_back
{
    public class MedicalSpecialization
    {
        private int id;
        private string name;

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }

        public MedicalSpecialization(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static List<MedicalSpecialization> getAllMedicalSpecialization()
        {
            Database.openConnection();
            string query = "SELECT id, name FROM medical_specializations";

            MySqlDataReader data = Database.dataReader(query);

            List<MedicalSpecialization> specializations = new List<MedicalSpecialization>();

            while (data.Read())
            {
                MedicalSpecialization specialization = new MedicalSpecialization(data.GetInt32(0), data.GetString(1));
                specializations.Add(specialization);
            }

            Database.closeConnection();
            return specializations;
        }
    }
}
