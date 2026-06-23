using EmployeeManagementAPI.Dto;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _service.GetAllEmployees();
            return Ok(employees);
        }


        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _service.GetEmployeeById(id);
            return Ok(employee);
        }


        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto employee)
        {
            var result = await _service.AddEmployee(employee);
            return Ok(result);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employee)
        {
            await _service.UpdateEmployee(employee);
            return Ok("Employee Updated Successfully");
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployee(id);
            return Ok("Employee Deleted Successfully");
        }
    }
}
