using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.DatabaseRepository.Mappings;
using RotaDeViagem.Domain.Entities;
using RotaDeViagem.Shared.Abstractions.Entities;

namespace RotaDeViagem.DatabaseRepository.Context
{
    public  class RotaDeViagemContext : DbContext
    {
        private readonly string _userId;

        public RotaDeViagemContext()
        { }

        public RotaDeViagemContext(DbContextOptions<RotaDeViagemContext> options, string userId) : base(options)
        {
            _userId = userId;
        }

        public DbSet<Rota> Corretor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TemplateContext).Assembly);
            modelBuilder.ApplyConfiguration(new CorretorMap());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetEntityBaseData();
            return base.SaveChangesAsync(true, cancellationToken);
        }

        public override int SaveChanges()
        {
            SetEntityBaseData();
            return base.SaveChanges();
        }

        private void SetEntityBaseData()
        {
            if (string.IsNullOrEmpty(_userId))
                throw new InvalidOperationException("The userId is required to create and update operations");

            var entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is AuditEntityBase &&
                            (x.State is EntityState.Added or EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((AuditEntityBase)entity.Entity).UniqueId = Guid.NewGuid();
                    ((AuditEntityBase)entity.Entity).CreatedAt = DateTime.UtcNow;
                    ((AuditEntityBase)entity.Entity).CreatedBy = _userId;
                }
                else
                {
                    ((AuditEntityBase)entity.Entity).ModifiedAt = DateTime.UtcNow;
                    ((AuditEntityBase)entity.Entity).ModifiedBy = _userId;
                }
            }
        }
    }
}
