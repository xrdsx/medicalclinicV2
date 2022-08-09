using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;

namespace medicalclinic_back
{
    public class Address
    {
        private int id;
        private string country;
        private string state;
        private string city;
        private string postal_code;
        private string street;
        private string number;

        public Address(int id, string country, string state, string city, string postal_code, string street, string number) 
        { 
            this.id = id;
            this.country = country; 
            this.state = state; 
            this.city = city;
            this.postal_code = postal_code;
            this.street = street;
            this.number = number;
        }

        public int Id { get => id; set => id = value; }
        public string Country { get => country; set => country = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string Postal_code { get => postal_code; set => postal_code = value; }
        public string Street { get => street; set => street = value; }
        public string Number { get => number; set => number = value; }

        public static string insertNewAddress(string country, string state, string city, string postal_code, string street, string number)
        {
            Database.openConnection();
            string query = "INSERT INTO user_addresses (country, state, city, postal_code, street, number) VALUES (@country, @state, @city, @postal_code, @street, @number); SELECT LAST_INSERT_ID();";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@country", country);
            command.Parameters.AddWithValue("@state", state);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@postal_code", postal_code);
            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@number", number);

            string address_id = command.ExecuteScalar().ToString();
            Database.closeConnection();

            return address_id;
        }

        public static void updateAddress(string id, string country, string state, string city, string postal_code, string street, string number)
        {
            Database.openConnection();

            string query = "UPDATE user_addresses SET country = @country, state = @state, city = @city, postal_code = @postal_code, street = @street, number = @number WHERE id = @id";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@country", country);
            command.Parameters.AddWithValue("@state", state);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@postal_code", postal_code);
            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@number", number);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }
    }
}
