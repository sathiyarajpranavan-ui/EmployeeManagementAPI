using EmployeeManagementAPI.Dto;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<EmployeeDto> AddEmployee(EmployeeDto employee);
        Task UpdateEmployee(EmployeeDto employee);
        Task DeleteEmployee(int id);
    }
}
