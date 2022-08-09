using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;

namespace medicalclinic_back
{
    public class UserCredentials
    {
        private int id;
        private string login;
        private string password;

        public int Id { get => id; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

        public UserCredentials(int id, string login, string password) 
        { 
            this.id = id;
            this.login = login;
            this.password = password;
        }

        public static UserCredentials getUserCredentials(string id_credentials)
        {
            Database.openConnection();
            string query = "SELECT id, login, password FROM user_credentials WHERE id = @id_credentials";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@id_credentials", id_credentials);

            MySqlDataReader data = command.ExecuteReader();

            data.Read();
            UserCredentials credentials = new UserCredentials(data.GetInt32(0), data.GetString(1), data.GetString(2));

            Database.closeConnection();
            return credentials;
        }

        public static string insertNewUser(string login, string password)
        {
            Database.openConnection();
            string query = "INSERT INTO user_credentials (login, password) VALUES (@login, @password); SELECT LAST_INSERT_ID();";


            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            string user_id = command.ExecuteScalar().ToString();
            Database.closeConnection();

            return user_id;
        }

        public static bool passwordValidation(string passw)
        {
            var has_number = new Regex(@"[0-9]+");
            var has_upper_char = new Regex(@"[A-Z]+");
            var has_lower_char = new Regex(@"[a-z]+");
            var has_symbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");


            if (has_number.IsMatch(passw) & has_upper_char.IsMatch(passw) & has_lower_char.IsMatch(passw) & has_symbols.IsMatch(passw) & passw.Length > 7 & passw.Length < 16)
            {
                return true;
            }
            return false;
        }

        public static bool loginValidationUnique(string login)
        {
            Database.openConnection();
            string query = @"select case when exists (select 1 from user_credentials where login=@login) then 1 else 0 end";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@login", login);

            bool exists;

            exists = Convert.ToBoolean(command.ExecuteScalar());

            Database.closeConnection();
            return !exists;
        }

        public static bool IsLoginDataCorrect(string login, string password)
        {
            Database.openConnection();
            string query = @"select case when exists (SELECT 1 FROM user_credentials where BINARY login=@login AND BINARY password = @password) then 1 else 0 end";
            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            bool correct;
            correct = Convert.ToBoolean(command.ExecuteScalar());

            Database.closeConnection();
            return correct;
        }

        public static bool IsActiveAdmin(string login)
        {
            string query = @"select case when exists (SELECT 1 FROM employees inner join user_credentials on user_credentials.id=employees.id_credentials inner join user_roles on employees.id_role=user_roles.id where BINARY user_credentials.login =@login AND user_roles.name='Administrator' and employees.is_active=1) then 1 else 0 end";
            Database.openConnection();
            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@login", login);

            bool isActive;
            isActive= Convert.ToBoolean(command.ExecuteScalar());
            Database.closeConnection();
            return isActive;
        }

    }
}
