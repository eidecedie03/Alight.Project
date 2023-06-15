using Application.Models.Common;

namespace Application.Models.Request
{
    public class UpdateUserRequest : BaseUserRequest
    {
        public UpdateUserRequest()
        {
            Employments = new List<UpdateEmploymentRequest>();
        }
        public int Id { get; set; }
        public UpdateAddressRequest? Address { get; set; }
        public List<UpdateEmploymentRequest> Employments { get; set; }

    }
}
