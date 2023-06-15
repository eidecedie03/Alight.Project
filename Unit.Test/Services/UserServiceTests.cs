using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Unit.Test.Data;

namespace Unit.Test.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IValidator<CreateUserRequest>> _createUserValidatorMock;
        private readonly Mock<IValidator<UpdateUserRequest>> _updateUserValidatorMock;
        private readonly UserService _sut;
        public UserServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _createUserValidatorMock = new Mock<IValidator<CreateUserRequest>>();
            _updateUserValidatorMock = new Mock<IValidator<UpdateUserRequest>>();
            _sut = new UserService(_mapperMock.Object, _unitOfWorkMock.Object, _createUserValidatorMock.Object, _updateUserValidatorMock.Object);
        }

        [Fact]
        public async void UserService_GetUser_ShouldReturnUser()
        {
            #region Arrange

            _unitOfWorkMock.Setup(x => x.UserRepository.GetWithDetailsAsync(It.IsAny<int>()))
                .ReturnsAsync(TestData.UserEntity);
            _mapperMock.Setup(x => x.Map<UserResponse>(It.IsAny<User>()))
                        .Returns(TestData.UserResponseDto);

            #endregion

            #region Act

            var result = await _sut.GetUser(It.IsAny<int>());

            #endregion

            #region Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<UserResponse>();

            #endregion
        }

        [Fact]
        public async void UserService_AddUser_ShouldAddUser()
        {
            #region Arrange

            _unitOfWorkMock.Setup(x => x.UserRepository.AddAsync(TestData.UserEntity()));

            _mapperMock.Setup(x => x
                        .Map<User>(It.IsAny<CreateUserRequest>()))
                        .Returns(TestData.UserEntity);

            _createUserValidatorMock.Setup(x => x.Validate(It.IsAny<CreateUserRequest>()))
                .Returns(new ValidationResult());

            _mapperMock.Setup(x => x.Map<UserResponse>(It.IsAny<User>()))
                        .Returns(TestData.UserResponseDto);

            #endregion

            #region Act

            var result = await _sut.AddUser(TestData.CreateUserDto());

            #endregion

            #region Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<UserResponse>();

            #endregion
        }


        [Fact]
        public async void UserService_UpdateUser_ShouldUpdateUser()
        {
            #region Arrange

            _unitOfWorkMock.Setup(x => x.UserRepository.UpdateAsync(TestData.UserEntity()));

            _mapperMock.Setup(x => x
                        .Map<User>(It.IsAny<UpdateUserRequest>()))
                        .Returns(TestData.UserEntity);
            _updateUserValidatorMock.Setup(x => x.Validate(It.IsAny<UpdateUserRequest>()))
                .Returns(new ValidationResult());

            _mapperMock.Setup(x => x.Map<UserResponse>(It.IsAny<User>()))
                    .Returns(TestData.UserResponseDto);

            #endregion

            #region Act

            var result = await _sut.UpdateUser(TestData.UpdateUserDto());

            #endregion

            #region Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<UserResponse>();

            #endregion
        }
    }
}