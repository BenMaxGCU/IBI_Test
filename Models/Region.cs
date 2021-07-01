using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestIBI.Models
{
    public class Region
    {
        // Unique ID for Region
        [Key]
        public int RegionId { get; set; }

        // Name of the Region
        public string RegionName { get; set; }
    }
}
