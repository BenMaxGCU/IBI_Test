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
    [Route("/[controller]")] // Giving the endpoint of /contracts
    public class ContractsController : ControllerBase
    {
        // Creating an instance of DbContext
        private readonly ApplicationDbContext _context;

        // Constructor
        public ContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts()
        {
            return await _context.Contracts.ToListAsync(); // Returns a list of all contracts
        }

        // Get: /contracts/<contract_id>
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetContract(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            return contract;
        }
    }
}
