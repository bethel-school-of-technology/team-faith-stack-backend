/*using System;
using System.Security.Cryptography;
using System.Text;

//This file is for the password encryption.

namespace BreathWebAPI.Services {
    public class UserAuth {
        public static string Sha256(string randomString) {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString), 0, Encoding.UTF8.GetByteCount(randomString));
            foreach (byte theByte in crypto) {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public static bool Sha256Check(string userInput, string valueToCompare) {
            // passes the raw user input through the hashing method.
            string hashedInput = UserAuth.Sha256(userInput);
            if (valueToCompare == hashedInput) {
                return true;
            }
                return false;
        }
    }
}*/