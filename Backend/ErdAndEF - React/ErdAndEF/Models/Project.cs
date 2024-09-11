using System.ComponentModel.DataAnnotations.Schema;

namespace ErdAndEF.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Budget { get; set; } = string.Empty;

        public double Hours { get; set; }


       public ICollection<EmployeeProjects> EmployeeProjects { get; set; } = new List<EmployeeProjects>();


    }
}
