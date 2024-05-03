using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaDeViagem.DatabaseRepository.Abastractions;
using RotaDeViagem.Domain.Entities;
using System.Drawing;

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
            PopulateData(builder);
        }

        private static void PopulateData(EntityTypeBuilder<Rota> builder)
        {
            builder.HasData(new[]
            {
                new { Id = 6,UniqueId = Guid.NewGuid(),  Origem = "GRU", Destino = "BRC", Valor = 10.0, CreatedAt = DateTime.Now,  CreatedBy = "1", IsDeleted = false  },
                new { Id = 7,UniqueId = Guid.NewGuid(),  Origem = "BRC", Destino = "SCL", Valor = 5.0 , CreatedAt = DateTime.Now,CreatedBy = "1", IsDeleted = false  },
                new { Id = 8,UniqueId = Guid.NewGuid(),  Origem = "GRU", Destino = "CDG", Valor = 75.0, CreatedAt = DateTime.Now,CreatedBy = "1", IsDeleted = false  },
                new { Id = 9,UniqueId = Guid.NewGuid(),  Origem = "GRU", Destino = "SCL", Valor = 20.0, CreatedAt = DateTime.Now,CreatedBy = "1", IsDeleted = false  },
                new { Id = 10,UniqueId = Guid.NewGuid(),  Origem = "GRU", Destino = "ORL", Valor = 56.0, CreatedAt = DateTime.Now,CreatedBy ="1", IsDeleted = false  },
                new { Id = 11,UniqueId = Guid.NewGuid(),  Origem = "ORL", Destino = "CDG", Valor = 5.0 , CreatedAt = DateTime.Now,CreatedBy= "1", IsDeleted = false  },
                new { Id = 12,UniqueId = Guid.NewGuid(),  Origem = "SCL", Destino = "ORL", Valor = 20.0, CreatedAt = DateTime.Now, CreatedBy = "1", IsDeleted = false },
            });
        }

    }
}
