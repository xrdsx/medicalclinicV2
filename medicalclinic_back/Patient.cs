using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace medicalclinic_back
{
    public class Patient
    {
        private int id;
        private string first_name;
        private string second_name;
        private string pesel;
        private SexEnum sex;
        private string phone_number;
        private string email;
        private DateTime date_of_birth;
        private string date_of_last_appointment;
        private ActivityEnum activity;

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Second_name { get => second_name; set => second_name = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public SexEnum Sex { get => sex; set => sex = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public string Date_of_last_appointment { get => date_of_last_appointment; set => date_of_last_appointment = value; }
        public ActivityEnum Activity { get => activity; set => activity = value; }

        public Patient(int id, string first_name, string second_name, string pesel, SexEnum sex, string phone_number, string email, DateTime date_of_birth, ActivityEnum activity, string date_of_last_appointment)
        {
            this.id = id;
            this.first_name = first_name;
            this.second_name = second_name;
            this.pesel = pesel;
            this.sex = sex;
            this.phone_number = phone_number;
            this.email = email;
            this.date_of_birth = date_of_birth;
            this.date_of_last_appointment = date_of_last_appointment;
            this.activity = activity;
        }

        public static List<Patient> GetPatients(string patient_name, string patient_surname, string patient_pesel, string appointment_date, string sort_column = "p.id", string sort_direction = "ASC")
        {
            Database.openConnection();
            string query;
            string p_name = "'" + patient_name + "%'";
            string p_surname = "'" + patient_surname + "%'";
            string p_pesel = "'" + patient_pesel + "%'";
            if (appointment_date == null)
            {
                query = $"SELECT p.id, p.first_name, p.second_name, p.pesel, p.sex, p.phone_number, p.email, p.date_of_birth, p.is_active, IFNULL((SELECT MAX(v.date) FROM visits v WHERE p.id = v.id_patient), (SELECT 'no appointments')) as date FROM patients p WHERE p.first_name LIKE {p_name} AND p.second_name LIKE {p_surname} AND p.pesel LIKE {p_pesel} ORDER BY {sort_column} {sort_direction}";
            }
            else
            {
                string v_date = "'" + appointment_date + "'";
                query = $"SELECT p.id, p.first_name, p.second_name, p.pesel, p.sex, p.phone_number, p.email, p.date_of_birth, p.is_active, CONVERT((SELECT MAX(v.date) FROM visits v WHERE p.id = v.id_patient), NCHAR) as date FROM patients p WHERE ABS(DATEDIFF({v_date}, (SELECT MAX(v.date) FROM visits v WHERE p.id = v.id_patient))) <= 3 AND p.first_name LIKE {p_name} AND p.second_name LIKE {p_surname} AND p.pesel LIKE {p_pesel} ORDER BY {sort_column} {sort_direction}";
            }

            MySqlDataReader data = Database.dataReader(query);

            List<Patient> patients = new List<Patient>();
            while (data.Read())
            {
                Patient patient = new Patient(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetString(3), (SexEnum)Enum.Parse(typeof(SexEnum), data.GetString(4)), data.GetString(5), data.GetString(6), data.GetDateTime(7), (ActivityEnum)Enum.Parse(typeof(ActivityEnum), data.GetString(8)), data.GetString(9));

                patients.Add(patient);
            }

            Database.closeConnection();
            return patients;
        }
        public static List<Patient> GetThisPatient(int this_patient_id)
        {
            Database.openConnection();
            string query = $"SELECT p.id, p.first_name, p.second_name, p.pesel, p.sex, p.phone_number, p.email, p.date_of_birth, p.is_active, IFNULL((SELECT MAX(v.date) FROM visits v WHERE p.id = v.id_patient), (SELECT 'no appointments')) as date FROM patients p WHERE p.id LIKE {this_patient_id}";
            MySqlDataReader data = Database.dataReader(query);
            List<Patient> patient = new List<Patient>();
            while (data.Read())
            {
                Patient patient_data = new Patient(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetString(3), (SexEnum)Enum.Parse(typeof(SexEnum), data.GetString(4)), data.GetString(5), data.GetString(6), data.GetDateTime(7), (ActivityEnum)Enum.Parse(typeof(ActivityEnum), data.GetString(8)), data.GetString(9));

                patient.Add(patient_data);
            }

            Database.closeConnection();
            return patient;
        }

        public static void DeletePatient(int Id)
        {
            Database.openConnection();
            string query = $"DELETE FROM visits WHERE @Id = id_patient";
            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@Id", Id);
            command.ExecuteNonQuery();
            string query1 = $"DELETE FROM patients WHERE @Id = id";
            MySqlCommand command1 = Database.command(query1);
            command1.Parameters.AddWithValue("@Id", Id);
            command1.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void ModifyPatient(int id, string first_name, string surname, string pesel, string sex, string phone_number, string email, string date_of_birth)
        {
            Database.openConnection();
            string query = $"UPDATE patients SET first_name = @FirstName, second_name = @Surname, pesel = @Pesel, sex = @Sex, date_of_birth = @Date, phone_number = @PhoneNumber, email = @Email WHERE id = @Id;";
            
            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@FirstName", first_name);
            command.Parameters.AddWithValue("@Surname", surname);
            command.Parameters.AddWithValue("@Pesel", pesel);
            command.Parameters.AddWithValue("@Sex", sex);
            command.Parameters.AddWithValue("@PhoneNumber", phone_number);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Date", date_of_birth);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }
        public static void ChangePatientsActivity(int id, ActivityEnum new_activity)
        {
            Database.openConnection();
            string query = $"UPDATE patients SET is_active = @NewActivity WHERE id = @Id;";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@NewActivity", new_activity.ToString());

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void AddNewPatient(string first_name, string surname, string pesel, string sex, string phone_number, string email, string date_of_birth)
        {
            Database.openConnection();
            string query = $"INSERT INTO patients (id, first_name, second_name,pesel, sex, date_of_birth, phone_number, email) VALUES (DEFAULT,@FirstName,@Surname,@Pesel,@Sex,@Date,@PhoneNumber,@Email)";


            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@FirstName", first_name);
            command.Parameters.AddWithValue("@Surname", surname);
            command.Parameters.AddWithValue("@Pesel", pesel);
            command.Parameters.AddWithValue("@Sex", sex);
            command.Parameters.AddWithValue("@PhoneNumber", phone_number);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Date", date_of_birth);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }
       
        public static bool ValidateName(string first_name)
        {
            Regex regex = new Regex(@"^[\p{Lu}\p{Ll}][\p{Ll}]*(([,.] |[ '-])[\p{Lu}\p{Ll}][\p{Ll}]*)*(\.?){1,30}$");
            Match match = regex.Match(first_name);
           
            if (!match.Success)
            {
                return false;
            }

            return true;
        }
        public static bool ValidateSurname(string surname)
        {
            Regex regex = new Regex(@"^[\p{Lu}\p{Ll}][\p{Ll}]*(([,.] |[ '-])[\p{Lu}\p{Ll}][\p{Ll}]*)*(\.?){1,30}$");
            Match match = regex.Match(surname);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }
        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9]){1,100}?$");
            Match match = regex.Match(email);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }
        public static bool ValidatePhoneNumber(string phonenumber)
        {
            Regex regex = new Regex(@"^([1-9]{1})[0-9]{8}$");
            Match match = regex.Match(phonenumber);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }
        public static bool ValidatePesel(string pesel, DateTime birth, SexEnum sex)
        {
            bool result = false;

            if (birth < DateTime.Today && pesel.Length==11)
            {
                string dayOfBirth, monthOfBirth;
                char gender;
                

            

                int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

                if (sex.Equals(SexEnum.M))
                {
                    gender = 'M';
                }
                else
                {
                    gender = 'F';
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
                    bool verifyGenderIfWomen = (peselDigits[9] % 2 == 0 && gender == 'F');

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
            }
            return result;
            
           
        }
        public static bool ValidatePeselUnique(string pesel)
        {
            List<Patient> PatientList = GetPatients(null, null, null, null);

            foreach (Patient pat in PatientList)
            {
                if (pat.Pesel == pesel)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
