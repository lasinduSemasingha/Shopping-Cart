using Application.DTOs;
using Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IUserService
    {
        public Task<ServiceResponseDTO> SignUpAsync(SignUpDTO user);
        // public Task<ServiceResponseDTO> LoginAsync(LoginDTO user);
    }
}
