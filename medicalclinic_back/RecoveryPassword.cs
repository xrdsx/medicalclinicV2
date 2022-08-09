using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using medicalclinic_back;
using System.Text.RegularExpressions;

namespace medicalclinic_back
{
    public static class RecoveryPassword
    {
        public static bool checkCredentials(string login, string email)
        {
            Database.openConnection();
            MySqlCommand cmd = Database.command("SELECT user_credentials.login, employees.email FROM user_credentials LEFT JOIN employees ON employees.id_credentials = user_credentials.id WHERE user_credentials.login = @login AND employees.email = @email; ");
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@email", email);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            Database.closeConnection();
            reader.Close();
            return false;
        }
        public static bool changePassword(string login, string passw)
        {
            Database.openConnection();
            MySqlCommand cmd = Database.command("UPDATE user_credentials SET password = @password WHERE login=@login; ");
            cmd.Parameters.AddWithValue("@password", passw);
            cmd.Parameters.AddWithValue("@login", login);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool passwordValidation(string passw)
        {
            var has_number = new Regex(@"[0-9]+");
            var has_upper_char = new Regex(@"[A-Z]+");
            var has_lower_char = new Regex(@"[a-z]+");
            var min_max_size = new Regex(@".{8,15}");
            var has_symbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if(!has_number.IsMatch(passw))
            {
                return false;
            }
            else if(!has_upper_char.IsMatch(passw))
            {
                return false;
            }
            else if(!has_lower_char.IsMatch(passw))
            {
                return false;
            }
            else if(!min_max_size.IsMatch(passw))
            {
                return false;
            }
            else if(!has_symbols.IsMatch(passw))
            { 
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool isPasswordTheSame(string pass1, string pass2)
        {
            if (pass1 == pass2)
                return true;

            return false;
        }
    }
}
