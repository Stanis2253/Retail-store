using Identity.DA.Models.DTO;

namespace Identity.Domain.Services
{
    public interface IUserManager
    {

        Task<UserDTO> GetUserById(string id);

        Task<UserDTO> Authenticate(UserDTO userDTO);

    }
}
