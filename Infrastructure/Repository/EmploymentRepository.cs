
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EmploymentRepository : Repository<Employment>, IEmploymentRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmploymentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employment>> GetByUserIdAsync(int userId)
        {
            return await _appDbContext.Employments.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
