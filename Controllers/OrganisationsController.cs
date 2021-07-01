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
    [Route("/[controller]")] // Giving the endpoint of /organisations
    public class OrganisationsController : ControllerBase
    {
        // Creating an instance of DbContext
        private readonly ApplicationDbContext _context;

        // Constructor
        public OrganisationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /organisations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractOrganisation>>> GetOrganisations()
        {
            return await _context.Organisations.ToListAsync(); // Returns a list of all organisations
        }

        // Get: /organisations/<organisation_id>
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractOrganisation>> GetOrganisation(int id)
        {
            var organisation = await _context.Organisations.FindAsync(id);

            if (organisation == null)
            {
                return NotFound();
            }

            return organisation;
        }
    }
}
