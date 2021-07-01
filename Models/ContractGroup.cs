using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestIBI.Models
{
    public class ContractGroup
    {
        // Unique ID for Contract Group, PK for this class
        [Key]
        public int ContractGroupId { get; set; }

        // Contract Group Name
        public string Name { get; set; }
        
        [ForeignKey("OrganisationId")]
        public int OrganisationId { get; set; }
        public virtual ContractOrganisation ContractOrganisation { get; set; }
    }
}
