using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaslavNijinskyOrgApp.Models;

namespace VaslavNijinskyOrgApp.Data
{
    public partial class EventDb : DbContext
    {
        public DbSet<Choreography> Choreography { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<School> School { get; set; }

        public EventDb(DbContextOptions<EventDb> options) : base(options)
        {
            
        }

    }
}
