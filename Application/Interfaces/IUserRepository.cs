using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetWithDetailsAsync(int id);
        Task<User> GetByEmailAsync(string email);
    }
}
