using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErdAndEF.Data;
using ErdAndEF.Models;
using ErdAndEF.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ErdAndEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee context)
        {
            _employee = context;
        }

        // GET: api/Employees
        [Route("/employees/GetAllEmployees")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Getemployees()
        {
          return  await _employee.GetAllEmployees();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            
            return await _employee.GetEmployeeById(id); 
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            var updateEmployee = await _employee.UpdateEmployee(id, employee);
            return Ok(updateEmployee);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var newEmployee =  await _employee.CreateEmployee(employee);
            return Ok(newEmployee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deletedEmployee = _employee.DeleteEmployee(id);
            return Ok(deletedEmployee);
        }

        [HttpGet("{id}/allProjects")]
        public async Task<ActionResult<List<Project>>> GetProjectsForEmployee(int id)
        {
            var projects = await _employee.GetProjectsForEmployee(id);
            return Ok(projects);
        }


        [Authorize(Roles = "User")]
        [HttpPost("SubmitRequest")]
        public async Task<ActionResult<EmployeeTask>> SubmitARequest(EmployeeTask task)
        {
            var newTask = await _employee.SubmitARequest(task);
            return Ok(newTask);
        }


        [Authorize(Roles = "Admin")] 
        [HttpGet("GetEmployeesRequests")]
        public async Task<ActionResult<List<EmployeeTask>>> GetAllTasks()
        {
            var tasks = await _employee.GetAllSubmittedTasks();
            return Ok(tasks);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateRequestStatus/{taskId}")]
        public async Task<IActionResult> UpdateRequestStatus(int taskId, [FromBody] string status)
        {
                var updatedTask = await _employee.UpdateRequestStatus(taskId, status);
                return Ok(new { message = "Request status approved", task = updatedTask });

        }

    }
}
