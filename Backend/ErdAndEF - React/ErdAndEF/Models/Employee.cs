using System.ComponentModel.DataAnnotations;

namespace ErdAndEF.Models
{
    public class Employee
    {
        public int Id { get; set; } // PK
        
        [MaxLength(255)]  // Limits the length to 255 characters
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]  // Assuming phone number is shorters
        public string Phone { get; set; } = string.Empty;

        public ICollection<EmployeeProjects> EmployeeProjects { get; set; } = new List<EmployeeProjects>();
        public ICollection<EmployeeTask> EmployeeTasks { get; set; } = new List<EmployeeTask>();
    }
}
