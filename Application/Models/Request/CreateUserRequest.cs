using Application.Models.Common;

namespace Application.Models.Request
{
    public class CreateUserRequest : BaseUserRequest
    {
        public CreateUserRequest()
        {
            Employments = new List<CreateEmploymentRequest>();
        }
        public CreateAddressRequest? Address { get; set; }
        public List<CreateEmploymentRequest> Employments { get; set; }
    }
}
