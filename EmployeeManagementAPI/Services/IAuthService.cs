using EmployeeManagementAPI.Dto;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username);

    }
}
