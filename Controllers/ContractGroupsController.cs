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
    [Route("/[controller]")] // Giving the endpoint of /contractgroups
    public class ContractGroupsController : ControllerBase
    {
        // Creating an instance of DbContext
        private readonly ApplicationDbContext _context;

        // Constructor
        public ContractGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractGroup>>> GetContractGroups()
        {
            return await _context.ContractGroups.ToListAsync(); // Returns a list of all contract groups
        }

        // Get: /contractgroups/<contractgroup_id>
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractGroup>> GetContractGroup(int id)
        {
            var conGroup = await _context.ContractGroups.FindAsync(id);

            if (conGroup == null)
            {
                return NotFound();
            }

            return conGroup;
        }
    }
}
