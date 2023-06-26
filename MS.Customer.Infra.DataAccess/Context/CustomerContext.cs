using MS.Customer.CrossCutting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Net;
using System;
using MS.Customer.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using MS.Customer.Domain.Base;
using MS.Customer.Domain.Exceptions;
using MS.Customer.Infra.DataAccess.Mappings;

namespace MS.Customer.Infra.Context
{
    public  class CustomerContext : DbContext
    {

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            optionsBuilder.EnableSensitiveDataLogging();

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine,
                new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted },
                LogLevel.Information,
                DbContextLoggerOptions.LocalTime);

            optionsBuilder.EnableDetailedErrors();
#endif
        }

        public virtual DbSet<Customers> Customer { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerMap());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var entries = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseEntity)entityEntry.Entity).SetCreatedAt(DateTime.Now);
                    }
                    else
                    {
                        entityEntry.Property("CreatedAt").IsModified = false;
                        ((BaseEntity)entityEntry.Entity).SetUpdatedAt(DateTime.Now);
                    }
                }

                return await base.SaveChangesAsync(true, cancellationToken);
            }
            catch (DbUpdateException dbUpdateEx)
            {
                throw new DatabaseException(dbUpdateEx.Message, dbUpdateEx);
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message);
            }
        }
    }
}