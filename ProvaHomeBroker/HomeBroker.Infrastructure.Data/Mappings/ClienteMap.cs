using HomeBroker.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBroker.Infrastructure.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(m => m.IdCliente);

            builder.Property(m => m.IdCliente)
                   .ValueGeneratedOnAdd();

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(350);

            builder.Property(m => m.TipoPessoa)
                .IsRequired()
                .HasConversion<string>()
                .HasColumnType("char(1)")
                .HasMaxLength(1);

            builder.Property(m => m.CpfCnpj)
                .HasColumnType("string");

            builder.Property(m => m.DataNascimento)
                .IsRequired()
                .HasColumnType("Datetime");

            builder.Ignore(m => m.ValidationResult);
            builder.Ignore(m => m.Valid);
        }
    }
}
