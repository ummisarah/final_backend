using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Dtos.User;

namespace final_project.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(UserRegisterDTO register);
        Task<ServiceResponse<string>> Login(UserLoginDTO login);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<UserDTO>> GetUser();
    }
};