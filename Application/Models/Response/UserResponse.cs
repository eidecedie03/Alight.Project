using Application.Dtos.Common;

namespace Application.Models.Response
{
    public class UserResponse : BaseModel
    {
        public UserResponse()
        {
            Employments = new List<EmploymentResponse>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressResponse? Address { get; set; }
        public List<EmploymentResponse> Employments { get; set; }
    }
}
