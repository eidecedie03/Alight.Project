using Application.Dtos.Common;

namespace Application.Models.Request
{
    public class UpdateAddressRequest : BaseAddressRequest
    {
        public int Id { get; set; }
    }
}
