using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestIBI.Models
{
    public class ContractGroupContract
    {
        [Key, ForeignKey("ContractGroupId")]
        public int ContractGroupId { get; set; }

        [Key, ForeignKey("ContractGroupId")]
        public int ContractId { get; set; }
    }
}
