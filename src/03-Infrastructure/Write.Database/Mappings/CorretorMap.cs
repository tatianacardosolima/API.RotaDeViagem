using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaDeViagem.DatabaseRepository.Abastractions;
using RotaDeViagem.Domain.Entities;

namespace RotaDeViagem.DatabaseRepository.Mappings
{
    public class CorretorMap : AuditColumnsMap<Rota>, IEntityTypeConfiguration<Rota>
    {

        public void Configure(EntityTypeBuilder<Rota> builder)
        {


            builder.ToTable("Rota", "dbo");
            base.Configure(builder);

            builder.Property(x => x.Origem).HasColumnType("varchar(3)").IsRequired();
            builder.Property(x => x.Destino).HasColumnType("varchar(3)").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal(8,2)").IsRequired();
        }
    }
}
