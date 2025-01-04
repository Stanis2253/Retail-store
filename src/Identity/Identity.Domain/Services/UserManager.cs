using Identity.DA.Models;
using Identity.DA.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.Domain.Services
{
    public class UserManager : IUserManager
    {
        private readonly AppSettings _appSettings;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserManager(AppSettings appSettings, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _appSettings = appSettings;
            _userManager = userManager;

        }

        public async Task<UserDTO> Authenticate(UserDTO userDTO)
        {
            var user = await _userManager.FindByNameAsync(userDTO.UserName);
            if (user == null || !await ValidateUser(user, userDTO.Password))
                throw new ArgumentOutOfRangeException("Invalid login or password!");
            var token = await GenerateToken(user);

            var response = new UserDTO{Id = user.Id, UserName = user.UserName, Email = user.Email, Token = token };

            return response;
        }

        private async Task<bool> ValidateUser(ApplicationUser user, string password)
             => await _signInManager.UserManager.CheckPasswordAsync(user, password);

        private async Task<string?> GenerateToken(ApplicationUser user)
        {
            byte[] key = Convert.FromBase64String(_appSettings.Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, user.UserName)}),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                throw new ArgumentOutOfRangeException("User not found!");

            var response = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };

            return response;
        }
    }
}
