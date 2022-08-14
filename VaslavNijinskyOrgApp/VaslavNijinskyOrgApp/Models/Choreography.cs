using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaslavNijinskyOrgApp.Models
{
    public class Choreography
    {
        private int Id_Coreography { get; set; }
        private string Name_Coreoography { get; set; }
        private string Category_Coreoography { get; set; }
        private List<ParticipantController> Members { get; set; }
        private int Id_School { get; set; }
        private string GroupCoach { get; set; }
        
    }
}
