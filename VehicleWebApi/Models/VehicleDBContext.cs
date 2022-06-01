using VehicleWebApi.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using VehicleWebApi.Helpers;

namespace VehicleWebApi.Models
{
    public class VehicleDBContext : DbContext
    {
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options) 
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }



    }
}
