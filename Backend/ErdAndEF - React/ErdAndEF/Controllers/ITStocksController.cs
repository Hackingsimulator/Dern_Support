using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErdAndEF.Data;
using ErdAndEF.Models;

namespace ErdAndEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITStocksController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public ITStocksController(EmployeeDbContext context)
        {
            _context = context;
        }

        // Get all spare parts
        [HttpGet("allStocks")]
        public async Task<IActionResult> GetAllStocks()
        {
            var spareParts = await _context.ITStocksDb.ToListAsync();
            return Ok(spareParts);
        }

        // Search spare parts by name or category
        [HttpGet("search")]
        public async Task<IActionResult> Search(string name = "", string category = "")
        {
            var spareParts = await _context.ITStocksDb
                .Where(sp => (string.IsNullOrEmpty(name) || sp.Name.Contains(name)) &&
                             (string.IsNullOrEmpty(category) || sp.Category.Contains(category)))
                .ToListAsync();

            if (spareParts == null || !spareParts.Any())
            {
                return NotFound("No spare parts found.");
            }

            return Ok(spareParts);
        }

        // Edit spare parts by id
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ITStocks updatedPart)
        {
            var sparePart = await _context.ITStocksDb.FindAsync(id);
            if (sparePart == null)
            {
                return NotFound("Spare part not found.");
            }

            // Update part details
            sparePart.Name = updatedPart.Name;
            sparePart.Category = updatedPart.Category;
            sparePart.Description = updatedPart.Description;
            sparePart.QuantityInStock = updatedPart.QuantityInStock;

            await _context.SaveChangesAsync();

            return Ok(sparePart);
        }

        // Add a new spare part
        [HttpPost("add")]   
        public async Task<IActionResult> Add([FromBody] ITStocks newPart)
        {
            if (newPart == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                // Clear the Id to ensure the database auto-assigns it
                newPart.Id = 0; // Ensure the ID is not manually set, and let the database handle it.

                // Add the new spare part to the database
                await _context.ITStocksDb.AddAsync(newPart);
                await _context.SaveChangesAsync();

                // Return the newly created part with its auto-generated ID
                return CreatedAtAction(nameof(GetAllStocks), new { id = newPart.Id }, newPart);
            }
            catch (DbUpdateException ex)
            {
                // Log and return detailed exception information
                return StatusCode(500, new
                {
                    StatusCode = 500,
                    Message = "An unexpected error occurred.",
                    DetailedMessage = ex.InnerException?.Message ?? ex.Message,
                    ExceptionType = ex.GetType().Name
                });
            }
        }


    }
}
