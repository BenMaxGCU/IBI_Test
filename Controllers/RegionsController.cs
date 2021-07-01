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
    [Controller] // Declaring that this is a controller
    [Route("/[controller]")] // Giving the endpoint of /regions
    public class RegionsController : ControllerBase
    {
        // Creating an instance of DbContext
        private readonly ApplicationDbContext _context;

        // Constructor
        public RegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return await _context.Regions.ToListAsync(); // Returns a list of all regions
        }

        // Get: /regions/<region_id>
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
            var region = await _context.Regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }
    }
}
