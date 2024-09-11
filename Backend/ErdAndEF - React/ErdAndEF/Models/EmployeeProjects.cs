
  namespace ErdAndEF.Models
{
    public class EmployeeProjects
    {
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }
}

