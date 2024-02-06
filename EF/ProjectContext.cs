using Domain.DTO;
using EF.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.DTO.Task> Tasks { get; set; }
        public DbSet<List> Lists { get; set; }

        public ProjectContext(DbContextOptions options)
            : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }

        public override int SaveChanges()
        {
            ChangeTracker.ChangeForEntityStateAdded();
            ChangeTracker.ChangeForEntityStateModified();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.ChangeForEntityStateAdded();
            ChangeTracker.ChangeForEntityStateModified();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.ChangeForEntityStateAdded();
            ChangeTracker.ChangeForEntityStateModified();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.ChangeForEntityStateAdded();
            ChangeTracker.ChangeForEntityStateModified();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
