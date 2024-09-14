using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ErdAndEF.Data;
using ErdAndEF.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ErdAndEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduledRepairsController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public ScheduledRepairsController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleRepair([FromBody] ScheduledRepairDto repairDto)
        {
            if (!ModelState.IsValid)
            {
                // Log model state errors
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}");
                    foreach (var err in error.Value.Errors)
                    {
                        Console.WriteLine($"Error: {err.ErrorMessage}");
                    }
                }
                return BadRequest(ModelState);
            }

            try
            {
                var newRepair = new ScheduledRepair
                {
                    Title = repairDto.Title,
                    Description = repairDto.Description,
                    RepairDate = repairDto.RepairDate,
                    Status = "Pending",
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreatedAt = DateTime.Now
                };

                _context.ScheduledRepairs.Add(newRepair);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(ScheduleRepair), new { id = newRepair.Id }, newRepair);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scheduling repair: {ex}");
                return StatusCode(500, "An error occurred while scheduling the repair.");
            }
        }

        [HttpGet("myrepairs")]
        public async Task<IActionResult> GetMyScheduledRepairs()
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                {
                    return Unauthorized();
                }

                var repairs = await _context.ScheduledRepairs
                    .Where(r => r.UserId == userId)
                    .OrderBy(r => r.RepairDate)
                    .ToListAsync();

                return Ok(repairs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching scheduled repairs: {ex}");
                return StatusCode(500, "An error occurred while fetching scheduled repairs.");
            }
        }

    }
}
