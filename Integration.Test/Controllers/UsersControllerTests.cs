using Application.Models.Response;
using FluentAssertions;
using Integration.Test.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Integration.Test.Controllers
{
    public class UsersControllerTests
    {
        private readonly HttpClient _httpClient;

        public UsersControllerTests()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task UsersController_Create_CreateUser()
        {
            #region Arrange

            var url = "/api/users";
            var data = TestData.CreateUserDto();

            #endregion

            #region Act

            var response = await _httpClient.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadFromJsonAsync<UserResponse>();

            #endregion

            #region Assert

            user.Should().NotBeNull();
            user.Email.Equals(data.Email);
            user.Id.Should().NotBe(0);

            #endregion
        }

        [Fact]
        public async Task UsersController_Update_UpdateUser()
        {
            #region Arrange

            var url = "/api/users";
            var data = TestData.UpdateUserDto();

            #endregion

            #region Act

            var response = await _httpClient.PutAsJsonAsync(url, data);

            #endregion

            #region Assert

            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadFromJsonAsync<UserResponse>();
            user.Should().NotBeNull();
            user.Email.Equals(data.Email);
            user.Id.Should().NotBe(0);

            #endregion
        }


        [Fact]
        public async Task UsersController_Get_GetUser()
        {
            #region Arrange

            var url = "/api/users/1";
            var data = TestData.UpdateUserDto();

            #endregion

            #region Act

            var response = await _httpClient.GetAsync(url);

            #endregion

            #region Assert

            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadFromJsonAsync<UserResponse>();
            user.Should().NotBeNull();
            user.Email.Equals(data.Email);
            user.Id.Should().NotBe(0);

            #endregion
        }

        [Fact]
        public async Task UsersController_Get_NotFound()
        {
            #region Arrange

            var url = "/api/users/100000012";

            #endregion

            #region Act

            var response = await _httpClient.GetAsync(url);

            #endregion

            #region Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);

            #endregion
        }
    }
}