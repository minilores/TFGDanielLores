using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaslavNijinskyOrgApp.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }
        public int SchoolId{ get; set; }
        public List<Choreography> Choreographies { get; set; }

    }
}
