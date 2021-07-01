using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestIBI.Models
{
    public class User
    {
        // Unique ID for User to be used as primary key
        [Key]
        public Guid UserId { get; set; }

        // User's name (Could be a username or real name either works)
        public string Name { get; set; }
    }
}
