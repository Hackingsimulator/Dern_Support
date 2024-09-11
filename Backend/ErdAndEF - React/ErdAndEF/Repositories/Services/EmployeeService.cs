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
            _context.Employees.Add(employee); // Corrected reference
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployee(int id)
        {
            var getEmployee = await GetEmployeeById(id);
            if (getEmployee != null)
            {
                _context.Employees.Remove(getEmployee); // Corrected reference
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync(); // Corrected reference
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId); // Corrected reference
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                throw new Exception("Employee not found");
            }

            // Update properties of existing employee with the new employee data
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Phone = employee.Phone;

            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task<List<Project>> GetProjectsForEmployee(int employeeId)
        {
            return await _context.EmployeeProjectsDBset
                .Where(ep => ep.EmployeeID == employeeId)
                .Select(ep => ep.Project)
                .ToListAsync();
        }

        public async Task<EmployeeTask> SubmitARequest(EmployeeTask task)
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
