using System.ComponentModel;

namespace medicalclinic_back
{
    public enum DatabaseColumnName {
        [Description("employees.id")] Id,
        [Description("first_name")] First_name,
        [Description("second_name")] Second_name,
        [Description("pesel")] Pesel,
        [Description("sex")] Sex,
        [Description("phone_number")] Phone_number,
        [Description("email")] Email,
        [Description("date_of_birth")] Date_of_birth,
        [Description("is_active")] Is_active,
        [Description("country")] Country,
        [Description("state")] State,
        [Description("city")] City,
        [Description("postal_code")] Postal_code,
        [Description("street")] Street,
        [Description("number")] Number,
        [Description("user_roles.name")] Role,
        [Description("departments.name")] Department,
        [Description("medical_specializations.name")] Medical_specialization,
    }

    public static class DatabaseColumnNameExtenstion
    {
        public static string GetDescription(this DatabaseColumnName enumValue)
        {
            object[] attr = enumValue.GetType().GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return ((DescriptionAttribute)attr[0]).Description;
        }
    }
}




