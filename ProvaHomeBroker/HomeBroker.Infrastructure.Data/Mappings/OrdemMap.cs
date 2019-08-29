using HomeBroker.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBroker.Infrastructure.Data.Mappings
{
    public class OrdemMap : IEntityTypeConfiguration<Ordem>
    {
        public void Configure(EntityTypeBuilder<Ordem> builder)
        {
            builder.HasKey(m => m.IdOrdem);

            builder.Property(m => m.IdOrdem);

            builder.Property(m => m.TipoOrdem)
                .IsRequired()
                .HasConversion<string>()
                .HasColumnType("char(1)")
                .HasMaxLength(1);

            builder.Property(m => m.CodigoAcao)
                .IsRequired()
                .HasColumnType("string");

            builder.Property(m => m.QuantidadeAcoes)
                .IsRequired()
                .HasColumnName("QuantidadeAcoes")
                .HasColumnType("int");

            builder.Property(m => m.DataOrdem)
                .IsRequired()
                .HasColumnName("DataOrdem")
                .HasColumnType("Datetime");

            builder.Property(m => m.DataCompra)
                .HasColumnName("DataCompra")
                .HasColumnType("Datetime");

            builder.Property(m => m.ValorOrdem)
                   .HasColumnName("ValorOrdem")
                   .HasColumnType("decimal");

            builder.Property(m => m.TaxaCorretagem)
                   .HasColumnName("TaxaCorretagem")
                   .HasColumnType("decimal");

            builder.Property(m => m.IR)
                   .HasColumnName("IR")
                   .HasColumnType("decimal");

            builder.Ignore(m => m.ValidationResult);
            builder.Ignore(m => m.Valid);
        }
    }
}
