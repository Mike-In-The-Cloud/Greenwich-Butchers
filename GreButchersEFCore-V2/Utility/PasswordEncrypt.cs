using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Utility
{
    public class PasswordEncrypt
    {// using a tuple i can return 2 results, the hashed password and the randomly generated salt.
        public static Tuple<byte[], string> Password_hash_with_salt(string password)
        {
            // variable to store the randomly generated salt
            var RnGCsp = new RNGCryptoServiceProvider();
            // byte array
            byte[] Salt = new byte[20];
            // get the byte data for the salt
            RnGCsp.GetBytes(Salt);
            // gets the byte data of the password
            var Password_bytes = ASCIIEncoding.ASCII.GetBytes(password);

            byte[] Data_Input = new byte[Salt.Length + Password_bytes.Length];

            for (int i = 0; i < Password_bytes.Length; i++)
            {
                Data_Input[i] = Password_bytes[i];
            }
            for (int i = 0; i < Salt.Length; i++)
            {
                Data_Input[i + Password_bytes.Length] = Salt[i];
            }
            // disposes of the class
            RnGCsp.Dispose();
            SHA512 ShaM = new SHA512Managed();
            var Hashed_Byte_Array = ShaM.ComputeHash(Data_Input);
            string Hashed_Result = Convert.ToBase64String(Hashed_Byte_Array);
            // returns the salt generated to be stored in the database for checking and the hashed password to be stored in the database
            return new Tuple<byte[], string>(Salt, Hashed_Result);
        }
    }
}
