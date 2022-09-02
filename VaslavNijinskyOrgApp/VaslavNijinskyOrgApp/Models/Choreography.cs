using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VaslavNijinskyOrgApp.Models
{
    public class Choreography
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SchoolName { get; set; }
        public string GroupCoach { get; set; }

        [NotMapped]
        public int[] Members { get; set; }

        public int SemifinalMark { get; set; }
        public bool IsFinalist { get; set; }
        public int FinalMark { get; set; }

    }
}
