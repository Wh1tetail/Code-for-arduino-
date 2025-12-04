using Microsoft.EntityFrameworkCore;
using PmApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PmApi.Data
{
    public class PmDbContext : DbContext
    {
        public PmDbContext(DbContextOptions<PmDbContext> options) : base(options)
        {
        }

        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<MaintenanceTask> MaintenanceTasks => Set<MaintenanceTask>();
        public DbSet<PmSchedule> PmSchedules => Set<PmSchedule>();
        public DbSet<PmEvent> PmEvents => Set<PmEvent>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PmSchedule>()
                .Property(x => x.ScheduleType)
                .HasConversion<int>();

            modelBuilder.Entity<PmEvent>()
                .Property(x => x.Status)
                .HasConversion<int>();
        }
    }
}
