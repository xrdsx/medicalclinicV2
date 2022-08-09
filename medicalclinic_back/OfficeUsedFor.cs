using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicalclinic_back
{
    public class OfficeUsedFor
    {
        private int id;
        private string name;

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }

        public OfficeUsedFor(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static List<OfficeUsedFor> GetAllTypes()
        {
            Database.openConnection();

            string query = "SELECT id, type FROM used_for";

            MySqlDataReader data = Database.dataReader(query);

            List<OfficeUsedFor> types = new List<OfficeUsedFor>();

            while (data.Read())
            {
                OfficeUsedFor type = new OfficeUsedFor(data.GetInt32(0), data.GetString(1));
                types.Add(type);
            }

            Database.closeConnection();
            return types;
        }
    }
}
