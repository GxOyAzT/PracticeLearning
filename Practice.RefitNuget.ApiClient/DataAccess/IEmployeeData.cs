using Practice.RefitNuget.ApiClient.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice.RefitNuget.ApiClient.DataAccess
{
    public interface IEmployeeData
    {
        [Get("/Employee/get")]
        Task<List<EmployeeModel>> GetEmployees();

        [Get("/Employee/get/{id}")]
        Task<EmployeeModel> GetEmployee(int id);

        [Post("/Employee/post")]
        Task CreateEmployee([Body] EmployeeModel employee);

        [Put("/Employee/put/{id}")]
        Task CreateEmployee(int id, [Body] EmployeeModel employee);

        [Delete("/Employee/delete/{id}")]
        Task DeleteEmployee(int id);
    }
}
