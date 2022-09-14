using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(string name, string username, string email, string phoneNumber, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}