using EmployeeManagementAPI.Dto;
using EmployeeManagementAPI.Exceptions;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {

            var employees = await _repository.GetAllAsync();

            return employees.Select(x => new EmployeeDto
            {
                EmployeeId = x.EmployeeId,
                EmployeeName = x.EmployeeName,
                Email = x.Email,
                Department = x.Department,
                DateOfJoining = x.DateOfJoining
            }).ToList();
        }



        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Email = employee.Email,
                Department = employee.Department,
                DateOfJoining = employee.DateOfJoining
            };
        }

        public async Task<EmployeeDto> AddEmployee(EmployeeDto dto)
        {

            var employee = new Employee
            {
                EmployeeName = dto.EmployeeName,
                Email = dto.Email,
                Department = dto.Department,
                DateOfJoining = dto.DateOfJoining
            };
           await _repository.AddAsync(employee);

            dto.EmployeeId = employee.EmployeeId;

            return dto;
        }

        public async Task UpdateEmployee(EmployeeDto dto)
        {
            if (dto.EmployeeId <= 0)
            {
                throw new ValidationException("Invalid Employee Id.");
            }
            var existingEmployee = await _repository.GetByIdAsync(dto.EmployeeId);
            if (existingEmployee == null)
            {
                throw new EmployeeNotFoundException(dto.EmployeeId);
            }

            existingEmployee.EmployeeName = dto.EmployeeName;
            existingEmployee.Email = dto.Email;
            existingEmployee.Department = dto.Department;
            existingEmployee.DateOfJoining = dto.DateOfJoining;

            await _repository.UpdateAsync(existingEmployee);
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new EmployeeNotFoundException(id);
            }

            await _repository.DeleteAsync(employee);
        }
    }
}