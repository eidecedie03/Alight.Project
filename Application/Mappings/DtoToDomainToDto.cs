using Application.Models.Request;
using Application.Models.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DtoToDomainToDto : Profile
    {
        public DtoToDomainToDto()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<CreateAddressRequest, Address>();
            CreateMap<CreateEmploymentRequest, Employment>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<UpdateAddressRequest, Address>();
            CreateMap<UpdateEmploymentRequest, Employment>();
            CreateMap<User, UserResponse>();
            CreateMap<Address, AddressResponse>();
            CreateMap<Employment, EmploymentResponse>();
        }
    }
}
