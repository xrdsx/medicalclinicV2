using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace medicalclinic_back
{
    public class UserRole
    {
        private int id;
        private string name;

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }

        public UserRole(int id, string name) { 
            this.id = id;
            this.name = name;
        }

        public static List<UserRole> getAllRoles()
        {
            Database.openConnection();
            string query = "SELECT id, name FROM user_roles";

            MySqlDataReader data = Database.dataReader(query);

            List <UserRole> roles = new List<UserRole>(); 

            while (data.Read()) {
                UserRole role = new UserRole(data.GetInt32(0), data.GetString(1));
                roles.Add(role);
            }

            Database.closeConnection();
            return roles;
        }
    }
}
