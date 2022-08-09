using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace medicalclinic_back
{
    public class UserDepartment
    {
        private int id;
        private string name;

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }

        public UserDepartment(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static List<UserDepartment> getAllDepartments()
        {
            Database.openConnection();
            string query = "SELECT id, name FROM departments";

            MySqlDataReader data = Database.dataReader(query);

            List<UserDepartment> departments = new List<UserDepartment>();

            while (data.Read())
            {
                UserDepartment department = new UserDepartment(data.GetInt32(0), data.GetString(1));
                departments.Add(department);
            }

            Database.closeConnection();
            return departments;
        }
    }
}
