using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace medicalclinic_back
{
    public class Employee
    {
        private int id;
        private string first_name;
        private string second_name;
        private string pesel;
        private SexEnum sex;
        private string phone_number;
        private string email;
        private DateTime date_of_birth;
        private bool is_active;
        private MedicalSpecialization medical_specialization;
        private Address address;
        private UserRole user_role;
        private UserDepartment user_department;
        private UserCredentials user_credentials;

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Second_name { get => second_name; set => second_name = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public SexEnum Sex { get => sex; set => sex = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public bool Is_active { get => is_active; set => is_active = value; }
        public MedicalSpecialization Medical_specialization { get => medical_specialization; set => medical_specialization = value; }
        public Address Address { get => address; set => address = value; }
        public UserRole User_role { get => user_role; set => user_role = value; }
        public UserDepartment User_department { get => user_department; set => user_department = value; }
        public UserCredentials User_login { get => user_credentials; set => user_credentials = value; }

        public Employee(int id, string first_name, string second_name, string pesel, SexEnum sex, string phone_number, string email, DateTime date_of_birth, bool is_active, MedicalSpecialization specialization, Address address, UserRole role, UserDepartment department)
        {
            this.id = id;
            this.first_name = first_name;
            this.second_name = second_name;
            this.pesel = pesel;
            this.sex = sex;
            this.phone_number = phone_number;
            this.email = email;
            this.date_of_birth = date_of_birth;
            this.is_active = is_active;
            this.medical_specialization = specialization;
            this.address = address;
            this.user_role = role;
            this.user_department = department;
        }

        public static List<Employee> GetAllEmployees(string sort_column = "employees.id", SortDirection sort_direction = SortDirection.Ascending, FilterColumnEmployee filter_column = FilterColumnEmployee.Undefined, string filter_query = "1")
        {
            bool is_sort_column_correct = false;
            string where_filter;
            string order_sort;


            foreach (DatabaseColumnName value in Enum.GetValues(typeof(DatabaseColumnName)))
            {
                string column = DatabaseColumnNameExtenstion.GetDescription(value);
                if (sort_column == column) {
                    is_sort_column_correct = true;
                    break;
                }
            }

            if (is_sort_column_correct)
            {
                if (sort_direction == SortDirection.Ascending)
                    order_sort = $"ORDER BY {sort_column} ASC";
                else
                    order_sort = $"ORDER BY {sort_column} DESC";
            } else order_sort = $"ORDER BY employees.id ASC";

            if (filter_column == FilterColumnEmployee.Active)
            {
                where_filter = "WHERE is_active = @filter_query";
            }
            else if (filter_column == FilterColumnEmployee.Role)
            {
                where_filter = "WHERE user_roles.name = @filter_query";
            }
            else {
                where_filter = "WHERE 1 = @filter_query";
            }

            Database.openConnection();
            string query = $"SELECT employees.id, first_name, second_name, pesel, sex, phone_number, email, date_of_birth, is_active, medical_specializations.id, medical_specializations.name, user_addresses.id, user_addresses.country, user_addresses.state, user_addresses.city, user_addresses.postal_code, user_addresses.street, user_addresses.number, user_roles.id, user_roles.name, departments.id, departments.name FROM employees LEFT JOIN medical_specializations ON employees.id_specialization = medical_specializations.id LEFT JOIN user_addresses ON employees.id_address = user_addresses.id LEFT JOIN user_roles ON employees.id_role = user_roles.id LEFT JOIN departments ON employees.id_department = departments.id {where_filter} {order_sort}";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@filter_query", filter_query);

            MySqlDataReader data = command.ExecuteReader();

            List<Employee> employees = new List<Employee>();
            while (data.Read())
            {
                MedicalSpecialization specialization;
                Address address;
                UserRole role;
                UserDepartment department;
                if (data.GetValue(9) == DBNull.Value)
                    specialization = new MedicalSpecialization(-1, string.Empty);
                else
                    specialization = new MedicalSpecialization(data.GetInt32(9), data.GetString(10));
                if (data.GetValue(11) == DBNull.Value)
                    address = new Address(-1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                else
                    address = new Address(data.GetInt32(11), data.GetString(12), data.GetString(13), data.GetString(14), data.GetString(15), data.GetString(16), data.GetString(17));
                if (data.GetValue(18) == DBNull.Value)
                    role = new UserRole(-1, string.Empty);
                else 
                    role = new UserRole(data.GetInt32(18), data.GetString(19));
                if (data.GetValue(20) == DBNull.Value)
                    department = new UserDepartment(-1, string.Empty);
                else
                    department = new UserDepartment(data.GetInt32(20), data.GetString(21));

                Employee employee = new Employee(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetString(3), (SexEnum)Enum.Parse(typeof(SexEnum),data.GetString(4)), data.GetString(5), data.GetString(6), data.GetDateTime(7), data.GetBoolean(8), specialization, address, role, department);

                employees.Add(employee);
            }

            Database.closeConnection();
            return employees;
        }

        public static string InsertNewEmployee(string first_name, string second_name, string pesel, string sex, string phone_number, string email, string date_of_birth, string id_role, string address_id = null) 
        {

            Database.openConnection();
            string query = "INSERT INTO employees (first_name, second_name, pesel, sex, phone_number, email, date_of_birth, id_address, id_role) VALUES (@first_name, @second_name, @pesel, @sex, @phone_number, @email, @date_of_birth, @address_value, @id_role); SELECT LAST_INSERT_ID();";


            MySqlCommand command = Database.command(query);

            if (address_id != null)
            {
                command.Parameters.AddWithValue("@address_value", address_id);
            }
            else {
                command.Parameters.AddWithValue("@address_value", DBNull.Value);
            }

            command.Parameters.AddWithValue("@first_name", first_name);
            command.Parameters.AddWithValue("@second_name", second_name);
            command.Parameters.AddWithValue("@pesel", pesel);
            command.Parameters.AddWithValue("@sex", sex);
            command.Parameters.AddWithValue("@phone_number", phone_number);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@date_of_birth", date_of_birth);
            command.Parameters.AddWithValue("@id_role", id_role);


            string employee_id = command.ExecuteScalar().ToString();
            Database.closeConnection();

            return employee_id;
        }

        public static void CreateRelationToUser(string user_id, string employee_id)
        {
            Database.openConnection();
            string query = "UPDATE employees SET id_credentials = @user_id WHERE id = @employee_id";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@employee_id", employee_id);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void SetEmployeeSpecialization(string id, string id_specialization)
        {
            Database.openConnection();

            string query = "UPDATE employees SET id_specialization = @id_specialization WHERE id = @id";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@id_specialization", id_specialization);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void SetEmployeeDepartment(string id, string id_department)
        {
            Database.openConnection();

            string query = "UPDATE employees SET id_role = @id_department WHERE id = @id";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@id_department", id_department);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void UpdateEmployee(string id, string first_name, string second_name, string pesel, string sex, string phone_number, string email, string date_of_birth)
        {
            Database.openConnection();

            string query = "UPDATE employees SET first_name = @first_name, second_name = @second_name, pesel = @pesel, sex = @sex, phone_number = @phone_number, email = @email, date_of_birth = @date_of_birth WHERE id = @id";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@first_name", first_name);
            command.Parameters.AddWithValue("@second_name", second_name);
            command.Parameters.AddWithValue("@pesel", pesel);
            command.Parameters.AddWithValue("@sex", sex);
            command.Parameters.AddWithValue("@phone_number", phone_number);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@date_of_birth", date_of_birth);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static bool ValidatePesel(string pesel, DateTime birth, string sex)
        {
            string dayOfBirth, monthOfBirth;
            char gender;
            bool result = false;

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 }; //wagi poszczegolnych cyfr nr pesel

            if (sex == "Male")
            {
                gender = 'M';
            }
            else
            {
                gender = 'K';
            }



            List<int> peselDigits = new List<int>(); 
            foreach (char digit in pesel)
            {
                if (char.IsDigit(digit))
                {
                    peselDigits.Add(Convert.ToInt32(digit.ToString()));
                }
                else
                {
                    return result;
                }
            }

            if (peselDigits.Count == 11)
            {
                dayOfBirth = birth.Day.ToString("00");
                monthOfBirth = birth.Month.ToString("00");

                string thirdAndFourthDigit;

                if (birth.Year >= 2000 && birth.Year < 2400)
                {

                    int digitOfHundreds = (birth.Year - 2000) / 100; 
                    int toAddToMonth = 0;
                    switch (digitOfHundreds)
                    {
                        case 0:
                            toAddToMonth = 20;
                            break;
                        case 1:
                            toAddToMonth = 40;
                            break;
                        case 2:
                            toAddToMonth = 60;
                            break;
                        case 3:
                            toAddToMonth = 80;
                            break;

                    }
                    thirdAndFourthDigit = (Convert.ToInt32(monthOfBirth) + toAddToMonth).ToString();

                }
                else
                {
                    thirdAndFourthDigit = monthOfBirth;
                }

                string yearAsString = birth.Year.ToString();
                string firstTwoDigits = yearAsString[2].ToString() + yearAsString[3].ToString(); 

                string year = peselDigits[0].ToString() + peselDigits[1].ToString(); 
                string month = peselDigits[2].ToString() + peselDigits[3].ToString(); 
                string day = peselDigits[4].ToString() + peselDigits[5].ToString(); 

                bool verifyYear = (firstTwoDigits == year);
                bool verifyMonth = (thirdAndFourthDigit == month);
                bool verifyDay = (dayOfBirth == day);
                bool verifyGenderIfMen = (peselDigits[9] % 2 == 1 && gender == 'M');
                bool verifyGenderIfWomen = (peselDigits[9] % 2 == 0 && gender == 'K');

                if (verifyYear && verifyMonth && verifyDay && (verifyGenderIfMen || verifyGenderIfWomen))
                {
                    int checksum = 0;
                    for (int i = 0; i <= weights.Length - 1; i++)
                    {
                        checksum += peselDigits[i] * weights[i];
                    }
                    checksum %= 10;

                    if (checksum != 0)
                    {
                        checksum = 10 - checksum;
                    }

                    if (checksum.ToString() == peselDigits[10].ToString())
                    {
                        result = true;
                    }
                }

            }


            return result;
        }

        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^[^@]+@[^@]+\.[^@]+$");
            Match match = regex.Match(email);

            if(!match.Success)
            {
                return false;
            }

            return true;
        }

        public static bool ValidatePeselUnique(string pesel)
        {

            Database.openConnection();
            string query = @"select case when exists (select 1 from employees where pesel=@pesel) then 1 else 0 end";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@pesel", pesel);

            bool exists;

            exists = Convert.ToBoolean(command.ExecuteScalar());

            Database.closeConnection();
            return !exists;
        }

        public static void ChangeActiveStatus(string id)
        {
            bool newstatus = !IsActive(id);

            Database.openConnection();
            string query = @"UPDATE employees SET is_active = @status WHERE employees.id = @id";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@status", newstatus);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static bool IsActive(string id)
        {
            Database.openConnection();
            string query = @"SELECT is_active from employees where id=@id";
            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@id", id);

            bool active = Convert.ToBoolean(command.ExecuteScalar());
            Database.closeConnection();
            return active;
        }

        public static List<Employee> SelectedEmployee(int index, string date)
        {
            Database.openConnection();
            string query = @"SELECT employees.id, first_name, second_name, pesel, sex, phone_number, email, date_of_birth, is_active, medical_specializations.id, medical_specializations.name, user_addresses.id, user_addresses.country, user_addresses.state, user_addresses.city, user_addresses.postal_code, user_addresses.street, user_addresses.number, user_roles.id, user_roles.name, departments.id, departments.name FROM employees INNER JOIN medical_specializations ON employees.id_specialization = medical_specializations.id INNER JOIN user_addresses ON employees.id_address = user_addresses.id INNER JOIN user_roles ON employees.id_role = user_roles.id INNER JOIN departments ON employees.id_department = departments.id INNER JOIN work_hours ON work_hours.id_doctor = employees.id WHERE medical_specializations.id = @index AND work_hours.date = @date";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@index", index);
            command.Parameters.AddWithValue("@date", date);

            MySqlDataReader data = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (data.Read())
            {
                MedicalSpecialization specialization;
                Address address;
                UserRole role;
                UserDepartment department;
                if (data.GetValue(9) == DBNull.Value)
                    specialization = new MedicalSpecialization(-1, string.Empty);
                else
                    specialization = new MedicalSpecialization(data.GetInt32(9), data.GetString(10));
                if (data.GetValue(11) == DBNull.Value)
                    address = new Address(-1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                else
                    address = new Address(data.GetInt32(11), data.GetString(12), data.GetString(13), data.GetString(14), data.GetString(15), data.GetString(16), data.GetString(17));
                if (data.GetValue(18) == DBNull.Value)
                    role = new UserRole(-1, string.Empty);
                else
                    role = new UserRole(data.GetInt32(18), data.GetString(19));
                if (data.GetValue(20) == DBNull.Value)
                    department = new UserDepartment(-1, string.Empty);
                else
                    department = new UserDepartment(data.GetInt32(20), data.GetString(21));

                Employee employee = new Employee(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetString(3), (SexEnum)Enum.Parse(typeof(SexEnum), data.GetString(4)), data.GetString(5), data.GetString(6), data.GetDateTime(7), data.GetBoolean(8), specialization, address, role, department);

                employees.Add(employee);
            }

            Database.closeConnection();
            return employees;
        }
    }
}
