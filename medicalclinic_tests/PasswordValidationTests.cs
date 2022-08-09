using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using medicalclinic_back;

namespace medicalclinic_tests
{
    [TestClass]
    public class PasswordValidationTests
    {
        [TestMethod]
        public void passwordValidationIsCorrect()
        {
            var result = RecoveryPassword.passwordValidation("Test1!233");
            Assert.IsTrue(result, "Walidacja poprawna");
        }
        [TestMethod]
        public void tooShortPassword()
        {
            var result = RecoveryPassword.passwordValidation("Test123");
            Assert.IsFalse(result, "Hasło o odpowiedniej ilości znaków");
        }
        [TestMethod]
        public void passwordWithoutSpecialMark()
        {
            var result = RecoveryPassword.passwordValidation("Test12345");
            Assert.IsFalse(result, "Hasło posiada znak specjalny");
        }
        [TestMethod]
        public void passwordWithoutTheUpperCase()
        {
            var result = RecoveryPassword.passwordValidation("test12345!");
            Assert.IsFalse(result, "Hasło posiada dużą literę");
        }
        [TestMethod]
        public void PasswordInputsAreTheSame()
        {
            var result = RecoveryPassword.isPasswordTheSame("test", "test");
            Assert.IsTrue(result, "Pola haseł nie są takie same");
        }
        [TestMethod]
        public void oneInputIsDiffrentFromTheOther()
        {
            var result = RecoveryPassword.isPasswordTheSame("test", "test123");
            Assert.IsFalse(result, "Pola haseł są identyczne ");
        }
        [TestMethod]
        public void passwordWithoutTheLowerCase()
        {
            var result = RecoveryPassword.passwordValidation("TEST123!");
            Assert.IsFalse(result, "Wprowadzone hasło posiada małą literę");
        }
    }
}