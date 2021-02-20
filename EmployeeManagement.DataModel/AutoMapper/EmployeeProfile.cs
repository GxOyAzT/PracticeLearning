using AutoMapper;

namespace EmployeeManagement.DataModel
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeModel, EmployeeBasicDTO>();
            CreateMap<EmployeeBasicDTO, EmployeeModel>();
        }
    }
}
