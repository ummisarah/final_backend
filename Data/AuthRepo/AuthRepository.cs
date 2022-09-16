using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using final_project.Dtos.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;

namespace final_project.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthRepository(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Login(UserLoginDTO login)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower().Equals(login.Username.ToLower()));

            if(user == null)
            {
                response.Success = false;
                response.Message = "User not found!";
            }
            else if(!VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
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

        public async Task<ServiceResponse<int>> Register(UserRegisterDTO register)
        {
            
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExists(register.Username))
            {
                response.Success = false;
                response.Message = "User already exists!";
                return response;
            }
            

            CreatePasswordHash(register.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = _mapper.Map<User>(register);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
           
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            User userCart = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == register.Username);
            // Console.WriteLine(userCart.Id);
           
            _context.Carts.Add
            (
                new Cart
                {
                    user = userCart
                }
            );

            _context.Wishlists.Add
            (
                new Wishlist
                {
                    user_wishlist = userCart
                }
            );

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
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<UserDTO>> GetUser()
        {

            var response = new ServiceResponse<UserDTO>();
            var result = await _context.Users
                .FirstOrDefaultAsync(item => item.Id == GetUserId());
            UserDTO userDTO = _mapper.Map<UserDTO>(result);
            response.Data = userDTO;
            return response;
        }
    }
}