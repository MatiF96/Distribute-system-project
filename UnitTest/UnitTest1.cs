using CinemaSystem.Repositories;
using CinemaSystem.Services;
using CinemaSystem.Services.DTO;
using Konscious.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public byte[] GetPassHash(string password, byte[] salt) 
        {
            var argon2 = new Argon2i(System.Text.Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 4096,
                Iterations = 40
            };
            return argon2.GetBytes(128);
        }
        public string HashPassword(string password)
        {
            var salt = "somesalt";
            var hashBytes = GetPassHash(password, System.Text.Encoding.UTF8.GetBytes(salt));
            return Convert.ToBase64String(hashBytes);
        }

        private bool IsPasswordValid(string password, string hashedPassword)
        {
            var salt = "somesalt";
            var storedHash = Convert.FromBase64String(hashedPassword);
            var passwordHashBytes = GetPassHash(password, System.Text.Encoding.UTF8.GetBytes(salt));
            for (int i = 0; i < passwordHashBytes.Length; i++)
            {
                if (passwordHashBytes[i] != storedHash[i]) return false;
            }
            return true;
        }
        
        [TestMethod]
        
        public void TestPassHash()
        {
            var test_pass = "Password123";
            var test_pass_hashed = "ROn2R7Jrf2iNSLnaJ3aGRWrJhOSA2N442hPvUnQeKX9TEuwFXLn4vhNNekSYw13Nz3OS/A+lgariJbmJXpMWMrd1GKQ+vfEt0ylk7U54PX9Qdcpl25LLaPdlrqELmGDxWFgWXz4S8LmJPBgsYSp7cvaubkT/wheq6IVPLL4zfcc=";
            var result = HashPassword(test_pass);
            Assert.AreEqual(test_pass_hashed, result);
        }

        [TestMethod]

        public void TestPassValidation()
        {
            var test_pass = "Password123";
            var test_pass_hashed = "ROn2R7Jrf2iNSLnaJ3aGRWrJhOSA2N442hPvUnQeKX9TEuwFXLn4vhNNekSYw13Nz3OS/A+lgariJbmJXpMWMrd1GKQ+vfEt0ylk7U54PX9Qdcpl25LLaPdlrqELmGDxWFgWXz4S8LmJPBgsYSp7cvaubkT/wheq6IVPLL4zfcc=";
            var result_check = IsPasswordValid(test_pass, test_pass_hashed);
            Assert.IsTrue(result_check);
        }
       
    }
}
