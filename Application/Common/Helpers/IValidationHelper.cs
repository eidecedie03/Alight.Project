namespace Application.Common.Helpers
{
    public interface IValidationHelper
    {
        Task<bool> EmailNotExistsAsync(string email, CancellationToken cancellationToken);

    }
}
