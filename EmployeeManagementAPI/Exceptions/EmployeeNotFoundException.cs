
using System;

namespace EmployeeManagementAPI.Exceptions
{
    public class EmployeeNotFoundException : System.Exception
    {
        public EmployeeNotFoundException(int id)
            : base($"Employee with Id {id} not found.")
        {
        }
    }
}
