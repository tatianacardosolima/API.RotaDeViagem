using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaDeViagem.Shared.Abstractions.Entities;

namespace RotaDeViagem.DatabaseRepository.Abastractions
{
    public abstract class AuditColumnsMap<TBase> :
            IEntityTypeConfiguration<TBase> where TBase : AuditEntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.UniqueId)
                .IsRequired();

            builder
                .Property(x => x.CreatedAt)
                .IsRequired();

            builder
                .Property(x => x.ModifiedAt);

            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(45).HasColumnType("varchar(45)");

            builder
                .Property(x => x.ModifiedBy)
                .HasMaxLength(45).HasColumnType("varchar(45)");

            builder
                .Property(x => x.IsDeleted)
                .IsRequired();
        }
    }
}
