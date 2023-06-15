using Application.Dtos.Common;

namespace Application.Models.Response
{
    public class AddressResponse : BaseModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int? PostCode { get; set; }
    }
}
