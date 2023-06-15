namespace Application.Dtos.Common
{
    public class BaseAddressRequest
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int? PostCode { get; set; }
    }
}
