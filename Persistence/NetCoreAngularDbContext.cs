using Microsoft.EntityFrameworkCore;
using NetCore_Angular.Models;


namespace NetCore_Angular.Persistence
{
    public class NetCoreAngularDbContext: DbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Feature> Features { get; set; }

        public NetCoreAngularDbContext(DbContextOptions<NetCoreAngularDbContext> options) 
            : base(options)
        {
            //System.Configuration.ConfigurationManager
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId });
        }

    }
}
