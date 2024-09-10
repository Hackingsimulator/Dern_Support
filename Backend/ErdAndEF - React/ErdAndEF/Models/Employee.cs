namespace ErdAndEF.Models
{
    public class Employee
    {
        public int Id { get; set; } // PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



        public ICollection<EmployeeProjects> employeeProjects { get; set; }

        public ICollection<EmployeeTask> EmployeeTasks { get; set; }  // An employee can have many tasks
    }
}
