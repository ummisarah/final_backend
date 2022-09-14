using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using final_project.Dtos.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace final_project.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

            if(user == null)
            {
                response.Success = false;
                response.Message = "User not found!";
            }
            else if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password!";
            }
            else
            {  
                Token token = new Token
                {
                    username = user.Username,
                    token = CreateToken(user),
                    expired_at = DateTime.Now.AddDays(1).ToString()
                };

                _context.Tokens.Add(token);
                await _context.SaveChangesAsync();

                response.Data = CreateToken(user);
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(string name, string username, string email, string phoneNumber, string address, string password)
        {
            
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExists(username))
            {
                response.Success = false;
                response.Message = "User already exists!";
                return response;
            }
            

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User 
            {
                Name = name,
                Username = username,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
                
            };
            // user.PasswordHash = passwordHash;
            // user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return ComputeHash.SequenceEqual(passwordHash);
            }
        }

        // public async Task<ServiceResponse<GetUserDTO>> GetUserDTO(int id, HttpContext httpContext)
        // {
        //     var tokenData = new Jwt().GetTokenClaim(httpContext);
        //     id = int.Parse(tokenData.id);

        //     var response = new ServiceResponse<GetUserDTO>();

        //     var userData = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            
        //     if(userData!=null)
        //     {
        //         GetUserDTO userDTO = new GetUserDTO
        //         {
        //             Name = userData.Name,
        //             Username = userData.Username,
        //             email = userData.Email,
        //             phone_number = userData.PhoneNumber,
        //             Address = userData.Address
        //         };

        //         response.Data = userDTO;
        //         response.Message = "Successfully";

        //         return response;
        //     }

        //     response.Success = false;
        //     response.Message = "False Token";
        //     return response;
        // }

        public string CreateToken(User user)
        {
            
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            
            
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                //.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token); //Token
        }

        public async Task<ServiceResponse<string>> GetFirstName(int id)
        {
            var response = new ServiceResponse<string>();
            var result = await _context.Users
                .FirstOrDefaultAsync(item => item.Id == id);
            response.Data = result.Name;
            return response;
        }
    }
}