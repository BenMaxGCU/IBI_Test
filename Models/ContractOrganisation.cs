using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestIBI.Models
{
    public class ContractOrganisation
    {
        // Unique ID for Organisations
        [Key]
        public int OrganisationId { get; set; }

        // Name of Organisation
        public string OrgName { get; set; }
    }
}
