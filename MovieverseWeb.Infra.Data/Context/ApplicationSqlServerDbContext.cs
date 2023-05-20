using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieverseWeb.Domain.Entities;
using System;
using System.Linq;

namespace MovieverseWeb.Infra.Data.Context
{
    public class ApplicationSqlServerDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationSqlServerDbContext(DbContextOptions<ApplicationSqlServerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationSqlServerDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBase)entityEntry.Entity).Created = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((EntityBase)entityEntry.Entity).Modified = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
