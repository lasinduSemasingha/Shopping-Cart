using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface.Security;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Security
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<object> _hasher = new();

        public async Task<string> HashPasswordAsync(string password)
        {
            return await Task.Run(() => _hasher.HashPassword(null, password));
        }

        public async Task<bool> VerifyPasswordAsync(string hashedPassword, string providedPassword)
        {
            var result = await Task.Run(() => _hasher.VerifyHashedPassword(null, hashedPassword, providedPassword));
            return result == PasswordVerificationResult.Success;
        }
    }
}
