using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Data;
using final_project.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO register)
        {
            var response = await _authRepo.Register(register);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDTO login)
        {
            var response = await _authRepo.Login(login);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("get_profil")]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> GetUser()
        {
            return Ok(await _authRepo.GetUser());
        }
    }
}