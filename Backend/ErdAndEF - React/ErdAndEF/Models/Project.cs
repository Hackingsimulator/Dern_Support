using System.ComponentModel.DataAnnotations.Schema;

namespace ErdAndEF.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Budget { get; set; }
        public double Hours { get; set; }


        public ICollection<EmployeeProjects> employeeProjects { get; set;}

    }
}
