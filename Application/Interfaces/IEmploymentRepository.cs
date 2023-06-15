using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEmploymentRepository : IRepository<Employment>
    {
        Task<IEnumerable<Employment>> GetByUserIdAsync(int userId);
    }
}
