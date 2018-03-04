using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Calculator.Models;
using CalcWin.Models.User;

namespace CalcWin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<Flavor> Flavors { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<WineProject> WineProjects { get; set; }
        public virtual DbSet<Supplement> Supplements { get; set; }
        public virtual DbSet<NormalizedName> NormalizedNames { get; set; }
    }
}
