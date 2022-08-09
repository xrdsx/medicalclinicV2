using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace medicalclinic_back
{
    public class Token
    {
        public static string genToken { get; set; }
        public static string hash { get; set; }
        static SHA256 sha256 = SHA256.Create();
        public static void generateToken(string token)
        {
            genToken = token;
            hash = GetHash(sha256, genToken);


        }
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            var hashOfInput = GetHash(hashAlgorithm, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
        public static bool unhashToken()
        {

            if (VerifyHash(sha256, genToken, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void cleanToken()
        {
            genToken = "";
            hash = "";
        }
    }

}

