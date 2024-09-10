using ErdAndEF.Models;

namespace ErdAndEF.Repositories.Interfaces
{
    public interface IEmployee
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int employeeId);

        Task<Employee> UpdateEmployee(int id,Employee employee);

        Task DeleteEmployee(int id);

        Task<List<Project>> GetProjectsForEmployee( int employeeId);

        Task<EmployeeTask> SubmitARequest(EmployeeTask task);

        Task<List<EmployeeTask>> GetAllSubmittedTasks();

        Task<EmployeeTask> UpdateRequestStatus(int taskId, string status);
    }
}
