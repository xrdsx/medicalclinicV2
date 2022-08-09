using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medicalclinic_back;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace medicalclinic_tests
{
    [TestClass]
    public class PeselValidationTest
    {
        [TestMethod]
        public void IncorrectDateOfBirth()
        {
            string pesel = "96031299531"; // prawidłowa data to 12.03.1996
            DateTime birthDate = Convert.ToDateTime("13/03/1996");
            string sex = "Male";

            Assert.IsFalse(Employee.ValidatePesel(pesel, birthDate, sex), "Pesel number is valid");
        }

        [TestMethod]
        public void IncorrectSex()
        {
            string pesel = "96031299531";
            DateTime birthDate = Convert.ToDateTime("12/03/1996");
            string sex = "Female";

            Assert.IsFalse(Employee.ValidatePesel(pesel, birthDate, sex), "Pesel number is valid");
        }

        [TestMethod]
        public void IncorrectDigitInPesel()
        {
            string pesel = "96041299531";
            DateTime birthDate = Convert.ToDateTime("12/03/1996");
            string sex = "Male";

            Assert.IsFalse(Employee.ValidatePesel(pesel, birthDate, sex), "Pesel number is valid");
        }

        [TestMethod]
        public void IncorrectDateOfBirthAndSex()
        {
            string pesel = "96031299531"; // prawidłowa data to 12.03.1996
            DateTime birthDate = Convert.ToDateTime("13/03/1996");
            string sex = "Female";

            Assert.IsFalse(Employee.ValidatePesel(pesel, birthDate, sex), "Pesel number is valid");
        }

        [TestMethod]
        public void IncorrectDateOfBirthAndOneDigit()
        {
            string pesel = "96041299531"; // prawidłowa data to 12.03.1996
            DateTime birthDate = Convert.ToDateTime("13/03/1996");
            string sex = "Male";

            Assert.IsFalse(Employee.ValidatePesel(pesel, birthDate, sex), "Pesel number is valid");
        }

        [TestMethod]
        public void IncorrectSexAndOneDigit()
        {
            string pesel = "96041299531";
            DateTime birthDate = Convert.ToDateTime("12/03/1996");
            string sex = "Female";

            Assert.IsFalse(Employee.ValidatePesel(pesel, birthDate, sex), "Pesel number is valid");
        }

        [TestMethod]
        public void AllDataCorrect()
        {
            string pesel = "96031299531";
            DateTime birthDate = Convert.ToDateTime("12/03/1996");
            string sex = "Male";

            Assert.IsTrue(Employee.ValidatePesel(pesel, birthDate, sex), "Pesel number is invalid");
        }
    }
}
