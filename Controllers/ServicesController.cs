using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTestIBI.Context;
using TechTestIBI.Models;

namespace TechTestIBI.Controllers
{
    [ApiController] // Declaring that this is a controller
    [Route("/[controller]")] // Giving the endpoint of /services
    public class ServicesController : ControllerBase
    {
        // Creating an instance of DbContext
        private readonly ApplicationDbContext _context;

        // Constructor
        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /services
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync(); // Returns a list of all services
        }

        // Get: /services/<service_id>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }
    }
}
