using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CancerScreening.Domain.Entities;
using CancerScreening.Persistence.Identity;

namespace CancerScreening.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<CancerAssessment> CancerAssessments => Set<CancerAssessment>();
        public DbSet<CancerQuestion> CancerQuestions => Set<CancerQuestion>();
        public DbSet<Admin> Admins => Set<Admin>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Important: Must call base for Identity tables

            // Additional Fluent API configurations can go here
        }
    }
}
