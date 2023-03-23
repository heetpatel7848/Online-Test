using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IUserService
    {
        ResponseDTO GetUsers();
        ResponseDTO GetUsersPaginated(int page, int limit);
        ResponseDTO GetUserById(int id);
        ResponseDTO GetUserByEmail(string email);
        ResponseDTO AddUser(AddUserDTO user);
        ResponseDTO UpdateUser(UpdateUserDTO user);
        ResponseDTO DeleteUser(int id);
        GetUserDTO IsUserExists(LoginDTO user);
    }
}