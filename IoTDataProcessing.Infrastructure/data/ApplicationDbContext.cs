using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTDataProcessing.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IoTDataProcessing.Infrastructure.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DeviceData> DeviceData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DeviceData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DeviceId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Timestamp).IsRequired();
                entity.Property(e => e.Temperature).IsRequired();
            });
        }
    }
}