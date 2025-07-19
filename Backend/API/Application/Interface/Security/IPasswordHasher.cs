using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Security
{
    public interface IPasswordHasher
    {
        public Task<string> HashPasswordAsync(string password);
        public Task<bool> VerifyPasswordAsync(string hashedPassword, string providedPassword);
    }
}
