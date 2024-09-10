using ErdAndEF.Data;
using ErdAndEF.Models;
using ErdAndEF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ErdAndEF.Repositories.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly EmployeeDbContext _context;

        public EmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task DeleteEmployee(int id)
        {
            var getEmployee = await GetEmployeeById(id);
            _context.Entry(getEmployee).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();  

        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var allEmployees =  await  _context.employees.ToListAsync();
            return allEmployees;
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            //var emplyee = _context.employees.Where(x => x.Equals(employeeId));
            var employee = await _context.employees.FindAsync(employeeId);
            return employee;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            //_context.Entry(employee).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            var exsitingEmployee = await _context.employees.FindAsync(id);
            exsitingEmployee = employee;
            await _context.SaveChangesAsync();

            return employee;
        }

        // get all projects for a given employee by id
        public async Task<List<Project>> GetProjectsForEmployee(int employeeId)
        {
            var projetcsForEmployees = await _context.EmployeeProjectsDBset
                .Where(ep => ep.EmployeeID == employeeId)
                .Select(ep => ep.Project)
                .ToListAsync();

            return projetcsForEmployees;

        }

        public async Task<EmployeeTask> SubmitARequest(EmployeeTask task)
        {
            _context.EmployeeTasksDb.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        async Task<EmployeeTask> IEmployee.SubmitARequest(EmployeeTask task)
        {
            _context.EmployeeTasksDb.Add(task);

            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<List<EmployeeTask>> GetAllSubmittedTasks()
        {
            return await _context.EmployeeTasksDb.ToListAsync();
        }




        public async Task<EmployeeTask> UpdateRequestStatus(int taskId, string status)
        {

            var task = await _context.EmployeeTasksDb.FindAsync(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }
            task.Status = status;
            await _context.SaveChangesAsync();

            return task; 
        }
    }
}
