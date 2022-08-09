using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using MySql.Data.MySqlClient;

namespace medicalclinic_back
{
    public static class AddUser
    {
        public static string password;
        public static string login1;
        public static string login2;
        public static int user_id;

        public static string GenerateLogin(int id)
        {
            Database.openConnection();
            string query = $@"SELECT first_name, second_name FROM employees WHERE employees.id = {id}";
            MySqlCommand mySqlCommand = Database.command(query);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                login1 = mySqlDataReader.GetValue(0).ToString();
                login2 = mySqlDataReader.GetValue(1).ToString();
            }

            login1 = login1.Substring(0, 2);
            login2 = login2.Substring(0, 2);
            string output = login1 + login2 + Membership.GeneratePassword(4, 1);
            mySqlDataReader.Close();
            Database.closeConnection();
            return output;

        }
        public static string GeneratePassword()
        {
            string password = Membership.GeneratePassword(12, 1) + "!";
            return password;
        }
        public static bool InsertNewUser(string login, string password, int employee_id)
        {

            Database.openConnection();
            string queryInsert = $@"INSERT user_credentials(login,password) VALUES('{login}','{password}')";
            MySqlCommand mySqlCommandInsert = Database.command(queryInsert);
            mySqlCommandInsert.ExecuteScalar();

            string queryuserId = $@"SELECT id FROM user_credentials WHERE login='{login}';";
            MySqlCommand mySqlCommandUserId = Database.command(queryuserId);
            MySqlDataReader mySqlDataReader = mySqlCommandUserId.ExecuteReader();
            if (mySqlDataReader.Read())
            {
                user_id = mySqlDataReader.GetInt32(0);
            }
            Database.closeConnection();
            mySqlDataReader.Close();
            Database.openConnection();



            string queryUpdate = $@"UPDATE employees SET id_credentials = '{user_id}' WHERE employees.id = '{employee_id}';";
            MySqlCommand mySqlCommandUpdate = Database.command(queryUpdate);
            mySqlCommandUpdate.ExecuteScalar();


            return true;
        }


    }

}
