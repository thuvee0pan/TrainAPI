using Microsoft.EntityFrameworkCore;
using TreainBookingApi.Entities;

namespace TreainBookingApi.Helpers
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Locomotive> Locomotive { get; set; }
        public DbSet<Purchese> Purchese { get; set; }
        public DbSet<RailroadCar> RailroadCar { get; set; }
        public DbSet<TrainRoute> TrainRoute { get; set; }
        public DbSet<Train> Train { get; set; }

        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((EntityBase)entity.Entity).CreatedDate = DateTime.UtcNow;
                    ((EntityBase)entity.Entity).CreatedBy = "Your User"; // Replace with your actual user context
                }
                else
                {
                    Entry((EntityBase)entity.Entity).Property(x => x.UpdatedDate).IsModified = false;
                    Entry((EntityBase)entity.Entity).Property(x => x.UpdatedBy).IsModified = false;
                }
            }
        }
    }
}