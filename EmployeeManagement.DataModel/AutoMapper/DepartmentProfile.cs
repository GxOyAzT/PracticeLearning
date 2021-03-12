using AutoMapper;

namespace EmployeeManagement.DataModel
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentModel, DepartmentDTO>();
        }
    }
}
