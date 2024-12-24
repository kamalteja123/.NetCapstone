
using UserManagement.Models.DTO;

namespace UserManagement.Interfaces
{
    public interface IUserService
    {
        public Task<ResponseDTO> Login(LoginRequestDTO loginRequest);
        public Task<ResponseDTO> Register(UserRegisterRequestDTO userRequest);
        //public Task<ResponseDTO> RegisterAdmin(UserRegisterRequestDTO userRequest);
    }
}
