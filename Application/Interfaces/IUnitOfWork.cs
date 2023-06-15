namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IEmploymentRepository EmploymentRepository { get; }
        Task<int> CompleteAsync();
        Task RollbackAsync();
    }
}
