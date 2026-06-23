namespace EmployeeManagementAPI
{
    using EmployeeManagementAPI.Dto;
    using FluentValidation;

    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeName)
                .NotEmpty()
                .WithMessage("Employee Name is required.")
                .MinimumLength(3)
                .WithMessage("Employee Name must be at least 3 characters.")
                .MaximumLength(100)
                .WithMessage("Employee Name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Department)
                .NotEmpty()
                .WithMessage("Department is required.")
                .Must(BeValidDepartment)
                .WithMessage("Invalid Department.");

            RuleFor(x => x.DateOfJoining)
                .NotEmpty()
                .WithMessage("Date Of Joining is required.")
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Date Of Joining cannot be a future date.");
        }

        private bool BeValidDepartment(string department)
        {
            var validDepartments = new[]
            {
            "IT",
            "HR",
            "Finance",
            "Admin"
        };

            return validDepartments.Contains(department);
        }
    }
}
