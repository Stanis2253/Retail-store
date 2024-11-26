using Identity.DA.Models.DTO;

namespace Identity.Domain.Services
{
    public interface IUserManager
    {
        Task<string> GenerateToken(string username);

        Task<UserDTO> GetUserById(string id);

    }
}
