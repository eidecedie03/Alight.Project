using Application.Models.Request;
using Application.Models.Response;

namespace Application.ServiceContracts
{
    public interface IUserService
    {
        Task<UserResponse> AddUser(CreateUserRequest user);
        Task<UserResponse> UpdateUser(UpdateUserRequest user);
        Task<UserResponse> GetUser(int id);
    }
}
