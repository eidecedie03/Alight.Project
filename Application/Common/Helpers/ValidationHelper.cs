using Application.Interfaces;

namespace Application.Common.Helpers
{
    public class ValidationHelper : IValidationHelper
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValidationHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> EmailNotExistsAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            return user == null;
        }
    }
}
