using Application.Dtos.Common;

namespace Application.Models.Request
{
    public class UpdateEmploymentRequest : BaseEmploymentRequest
    {
        public int Id { get; set; }
    }
}
