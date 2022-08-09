using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace medicalclinic_back
{
    public static class LoginUser
    {
       
        private static int attempt = 3;
        private static int id;
        private static bool islogged = false;
        private static bool isActive = false;
        private static string role;
        private static int time;
        public static int NumOfAttempt { get { return attempt; } set { attempt = value; } }
        public static bool IsLogged { get { return islogged; } set { islogged = value; } }
        public static bool IsActive { get { return isActive; } set { isActive = value; } }
        public static string Role { get { return role; } set { role = value; } }
        public static int Id { get { return id; } set { id = value; } }
        public static int Time { get { return time; } set { time = value; } }
        public static string wrongData()
        {
            NumOfAttempt--;
            return "The given credentials are not correct! There are " + NumOfAttempt + " attempts left.";
        }
        public static bool checkAttempt()
        {
            if (NumOfAttempt == 1)
                return true;
            return false;
        }
        public static bool checkIsActive()
        {
            if (IsActive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string showInfo()
        {
            return "The given credentials are not correct! Input has been blocked";
        }
        public static void logIn(string login, string passw)
        {
            Database.openConnection();
            MySqlCommand cmd = Database.command("SELECT * FROM user_credentials where BINARY login=@login AND BINARY password = @password AND is_active=1");
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", passw);
            MySqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                IsLogged = true;
                isActive = true;
                Id = sdr.GetInt32(0);
                NumOfAttempt = 3;
            }
            sdr.Close();
            Database.closeConnection();
        }
        public static bool checkIfLogged()
        {
            if (IsLogged)
                return true;
            return false;
        }
        public static void logOut()
        {
            IsLogged = false;
        }
        public static string getRoleName(int id)
        {
            EditUser user = EditUser.getUser(id);
            return user.Role;
        }
        public static int getUserId()
        {
            return Id;
        }
        public static double setTime()
        {

            int czas = 0 + Time;
            if (czas == 0)
            {
                Time = czas;
                czas = 1;
            }
            return czas;
        }
    }
}
