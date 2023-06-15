using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Unit.Test.Data
{
    public static class TestData
    {
        public static CreateUserRequest CreateUserDto()
        {
            return new CreateUserRequest()
            {
                FirstName = "Test",
                LastName = "User",
                Email = GenerateRandomEmail(),
                Address = new CreateAddressRequest
                {
                    City = "test city",
                    PostCode = 1234,
                    Street = "test street"
                },
                Employments = new List<CreateEmploymentRequest>
                {
                    new CreateEmploymentRequest
                    {
                        Company = "test  company",
                        MonthsOfExperience = 1,
                        Salary = 1000,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(5)
                    }
                }
            };
        }

        public static UpdateUserRequest UpdateUserDto()
        {
            return new UpdateUserRequest()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                Email = GenerateRandomEmail(),
                Address = new UpdateAddressRequest
                {
                    City = "test city",
                    PostCode = 1234,
                    Street = "test street"
                },
                Employments = new List<UpdateEmploymentRequest>
                {
                    new UpdateEmploymentRequest
                    {
                        Company = "test  company",
                        MonthsOfExperience = 1,
                        Salary = 1000,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(5)
                    }
                }
            };
        }

        public static User UserEntity()
        {
            return new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                Email = "test.user@gmail.com",
                Address = new Address
                {
                    City = "test city",
                    PostCode = 1234,
                    Street = "test street"
                },
                Employments = new List<Employment>
                {
                    new Employment
                    {
                        Id = 1,
                        Company = "test  company",
                        MonthsOfExperience = 1,
                        Salary = 1000,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(5)
                    }
                }
            };
        }

        public static UserResponse UserResponseDto()
        {
            return new UserResponse()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                Email = "test.user@gmail.com",
                Address = new AddressResponse
                {
                    City = "test city",
                    PostCode = 1234,
                    Street = "test street"
                },
                Employments = new List<EmploymentResponse>
                {
                    new EmploymentResponse
                    {
                        Id = 1,
                        Company = "test  company",
                        MonthsOfExperience = 1,
                        Salary = 1000,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(5)
                    }
                }
            };
        }

        private static string GenerateRandomEmail()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomString = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return $"{randomString}@gmail.com";
        }
    }
}
