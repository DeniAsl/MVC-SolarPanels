using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolarPanelsBelgium.Core.Data.Seeding;
using SolarPanelsBelgium.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<SolarPanel> SolarPanels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Seeder.Seed(builder);
            base.OnModelCreating(builder);
        }
    }
}
