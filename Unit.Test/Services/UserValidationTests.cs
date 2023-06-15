using Application.Common.Helpers;
using Application.Common.Validators;
using FluentAssertions;
using Moq;
using Unit.Test.Data;

namespace Unit.Test.Services
{
    public class UserValidationTests
    {
        private readonly Mock<IValidationHelper> _validationHelperMock;
        private readonly CreateUserValidator _sut;
        public UserValidationTests()
        {
            _validationHelperMock = new Mock<IValidationHelper>();
            _sut = new CreateUserValidator(_validationHelperMock.Object);
        }

        [Fact]
        public async void Validation_ShouldFail_WhenInvalidEmail()
        {
            #region Arrange

            var data = TestData.CreateUserDto();
            data.Email = "test123";

            #endregion

            #region Act

            var result = await _sut.ValidateAsync(data);

            #endregion

            #region Assert

            result.IsValid.Should().BeFalse();

            #endregion
        }

        [Fact]
        public async void Validation_ShouldFail_StartDateLessThanEndDate()
        {
            #region Arrange

            var data = TestData.CreateUserDto();
            data.Employments.ForEach(x => x.EndDate = x.StartDate.AddDays(-1));

            #endregion

            #region Act

            var result = await _sut.ValidateAsync(data);

            #endregion

            #region Assert

            result.IsValid.Should().BeFalse();

            #endregion
        }

        [Fact]
        public async void Validation_ShouldPass_WhenUserDoesNotExists()
        {
            #region Arrange

            _validationHelperMock.Setup(x => x.EmailNotExistsAsync(It.IsAny<string>(), new CancellationToken()))
                .ReturnsAsync(true);

            #endregion

            #region Act

            var result = await _sut.ValidateAsync(TestData.CreateUserDto(), new CancellationToken());

            #endregion

            #region Assert

            result.IsValid.Should().BeTrue();

            #endregion
        }

        [Fact]
        public async void Validation_ShouldFail_WhenUserExists()
        {
            #region Arrange

            _validationHelperMock.Setup(x => x.EmailNotExistsAsync(It.IsAny<string>(), new CancellationToken()))
                .ReturnsAsync(false);

            #endregion

            #region Act

            var result = await _sut.ValidateAsync(TestData.CreateUserDto(), new CancellationToken());

            #endregion

            #region Assert

            result.IsValid.Should().BeFalse();

            #endregion
        }
    }
}

