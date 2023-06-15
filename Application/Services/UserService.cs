using Application.Common.CustomExceptionMiddleware;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Application.ServiceContracts;
using AutoMapper;
using Domain.Entities;
using FluentValidation;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateUserRequest> _createUserValidator;
        private readonly IValidator<UpdateUserRequest> _updateUserValidator;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<CreateUserRequest> createUserValidator, IValidator<UpdateUserRequest> updateUserValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _createUserValidator = createUserValidator;
            _updateUserValidator = updateUserValidator;
        }

        public async Task<UserResponse> AddUser(CreateUserRequest user)
        {
            var validationResult = await _createUserValidator.ValidateAsync(user);

            if (validationResult != null && validationResult.Errors.Count > 0)
                throw new BadRequestException(validationResult.ToString());

            var data = _mapper.Map<User>(user);
            await _unitOfWork.UserRepository.AddAsync(data);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UserResponse>(data);
        }

        public async Task<UserResponse> GetUser(int id)
        {
            var data = await _unitOfWork.UserRepository.GetWithDetailsAsync(id);

            if (data == null)
                throw new NotFoundException("User not found");

            return _mapper.Map<UserResponse>(data);
        }

        public async Task<UserResponse> UpdateUser(UpdateUserRequest user)
        {
            var validationResult = await _updateUserValidator.ValidateAsync(user);

            if (validationResult != null && validationResult.Errors.Count > 0)
                throw new BadRequestException(validationResult.ToString());

            var data = _mapper.Map<User>(user);

            await _unitOfWork.UserRepository.UpdateAsync(data);

            var updatedData = await _unitOfWork.UserRepository.GetWithDetailsAsync(user.Id);

            if (updatedData != null && updatedData.Employments.Count > 0)
                _unitOfWork.EmploymentRepository.DeleteRange(updatedData.Employments.Where(x => !user.Employments.Select(y => y.Id).Contains(x.Id)));

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UserResponse>(data);
        }
    }
}
