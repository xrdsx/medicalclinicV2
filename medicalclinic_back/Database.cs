using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace medicalclinic_back
{
    public class Database
    {
        private static MySqlConnection connection;
        private static string connectionString = @"server=s162.cyber-folks.pl;database=vfczjombdo_medical-clinic;uid=vfczjombdo_tester;password=Testowanie10!";
        public static void openConnection()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wystąpił błąd.");
            }
        }

        public static void closeConnection()
        {
            connection.Close();
        }

        public static MySqlCommand command(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command;
        }

        public static MySqlDataReader dataReader(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }
        public static MySqlDataAdapter dataAdapter(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            return dataAdapter;
        }
        
    }
}
