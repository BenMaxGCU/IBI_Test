using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestIBI.Models
{
    // While following the brief I was dedicated to using the class diagrams labels but I would prefer changing Service to something like TransportService or TransportLink to avoid any confusion for actual services
    public class Service
    {
        // Unique ID for Service
        [Key]
        public int ServiceId { get; set; }

        // Number for the service i.e. the No. 5 Train
        public int ServiceNumber { get; set; }

        // We need to use the primary key from the Contract key as a foreign key
        [ForeignKey("ContractId")]
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
