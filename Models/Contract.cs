using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestIBI.Models
{
    public class Contract
    {
        // Unique ID for Contract, will be used as primary key
        [Key]
        public int ContractId { get; set; }

        // Start and End dates created using DateTime data type
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        [ForeignKey("RegionId")]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
