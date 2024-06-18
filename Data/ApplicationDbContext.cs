using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FireSafetyManager.Models;

namespace FireSafetyManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Vehicle-Employee relationship
            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Employees)
                .WithOne(e => e.Vehicle)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.SetNull);

            // Vehicle-Incident relationship
            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Incidents)
                .WithOne(i => i.Vehicle)
                .HasForeignKey(i => i.VehicleId)
                .OnDelete(DeleteBehavior.SetNull);

            // Employee-Incident relationship
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Incidents)
                .WithOne(i => i.Employee)
                .HasForeignKey(i => i.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
