using Application.DTOs;
using Application.DTOs.Auth;
using Application.Interface.Repository;
using Application.Interface.Security;
using Application.Services.Interface;
using Azure.Identity;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthentication _authentication;

        public UserService(IPasswordHasher passwordHasher, IAuthentication authentication)
        {
            _passwordHasher = passwordHasher;
            _authentication = authentication;
        }
        public async Task<ServiceResponseDTO> SignUpAsync(SignUpDTO sign)
        {
            var user = new User
            {
                Username = sign.username,
                PasswordHash = await _passwordHasher.HashPasswordAsync(sign.password),
                Name = sign.name,
                IsActive = true
            };
            var result = await _authentication.CreateUserAsync(user);
            return new ServiceResponseDTO(true, "User Created");
            
        }
        //public async Task<ServiceResponseDTO> LoginAsync(LoginDTO login)
        //{

        //}
    }
}
