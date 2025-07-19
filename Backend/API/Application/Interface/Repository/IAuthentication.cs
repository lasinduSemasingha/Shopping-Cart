using Application.DTOs;
using Application.DTOs.Auth;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repository
{
    public interface IAuthentication
    {
        public Task<ServiceResponseDTO> CreateUserAsync(User user);
    }
}
