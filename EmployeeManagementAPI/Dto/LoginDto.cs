using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Dto
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
