using Microsoft.AspNetCore.Identity;
using System;
using System.Text;

using WebApplication1.Models;
using System.Security.Cryptography;

using BC = BCrypt.Net.BCrypt;

namespace WebApplication1.Identity
{
    public class PasswordHasher : IPasswordHasher<DataClass>
    {
        public string HashPassword(DataClass customer, string passwordHash)
        { 
            return BC.HashPassword(passwordHash);
        }

        public PasswordVerificationResult VerifyHashedPassword(DataClass customer,
            string hashedPassword, string password)
        {
            if (BC.Verify(password, hashedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }

}
