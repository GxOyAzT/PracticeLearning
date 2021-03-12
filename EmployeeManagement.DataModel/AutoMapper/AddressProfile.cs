using AutoMapper;

namespace EmployeeManagement.DataModel
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressModel, AddressBasicDTO>();
            CreateMap<AddressBasicDTO, AddressModel>();
        }
    }
}
