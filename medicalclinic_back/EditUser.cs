using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace medicalclinic_back
{
    public class EditUser
    {
        private string login;
        private string role;
        private bool isActive;
        public string Login { get => login; set => login = value; }
        public string Role { get => role; set => role = value; }
        public bool IsActive { get => isActive; set => isActive = value; }

        public EditUser(string login, string role, bool isActive)
        {
            this.login = login;
            this.role = role;
            this.isActive = isActive;
        }

        public static MySqlDataAdapter FillDataGridView()
        {
            Database.openConnection();
            MySqlDataAdapter dataAdapter = Database.dataAdapter("SELECT user_credentials.login, employees.first_name, employees.second_name, employees.email, user_credentials.is_active FROM user_credentials INNER JOIN employees ON employees.`id_credentials` = user_credentials.`id` ORDER BY user_credentials.id ASC;");
            Database.closeConnection();

            return dataAdapter;
        }
        public static bool getUserActivity()
        {
            Database.openConnection();
            string query = "SELECT is_active FROM user_credentials";
            MySqlCommand command = Database.command(query);
            MySqlDataReader data = command.ExecuteReader();
            bool result = false;
            while (data.Read())
            {
                if (data.GetBoolean(0))
                    result = true;

                if (!data.GetBoolean(0))
                    result = false;

            }
            return result;
        }
        public static EditUser getUser(int id)
        {
            Database.openConnection();
            string query = "SELECT u.login, r.name, u.is_active FROM user_roles r INNER JOIN employees e ON r.id = e.id_role INNER JOIN user_credentials u ON e.id_credentials = u.id WHERE u.id = @id_credentials;";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@id_credentials", id);

            MySqlDataReader data = command.ExecuteReader();

            data.Read();
            EditUser user = new EditUser(data.GetString(0), data.GetString(1), data.GetBoolean(2));

            Database.closeConnection();
            return user;
        }
        public static void editUser(int id, string new_login, bool new_is_active, int new_id_role)
        {
            Database.openConnection();
            string query = @"UPDATE user_credentials AS u INNER JOIN employees AS e ON u.id = e.id_credentials SET u.login = @new_login, u.is_active = @new_is_active, e.id_role = @new_role WHERE u.id = @user_id; ";
            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@new_login", new_login);
            command.Parameters.AddWithValue("@new_is_active", new_is_active);
            command.Parameters.AddWithValue("@new_role", new_id_role);
            command.Parameters.AddWithValue("@user_id", id);

            command.ExecuteScalar();
            Database.closeConnection();
        }
        public static string getRoleName(int id)
        {
            EditUser user = EditUser.getUser(id);
            return user.Role;
        }
        public static void switchActivity(int i)
        {
            EditUser user = EditUser.getUser(i);
            Database.openConnection();
            MySqlCommand command = Database.command("UPDATE user_credentials SET is_active=@is_active WHERE id=@id");
            command.Parameters.AddWithValue("@id", i);
            if (user.IsActive)
            {
                command.Parameters.AddWithValue("@is_active", 0);
            }
            else
            {
                command.Parameters.AddWithValue("@is_active", 1);
            }
            command.ExecuteScalar();
            Database.closeConnection();
        }
    }
}
