using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaslavNijinskyOrgApp.Models
{
    public class Choreography
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Participant> Members { get; set; }
        public int SchoolId { get; set; }
        public string GroupCoach { get; set; }
        
    }
}
