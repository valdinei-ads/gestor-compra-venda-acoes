using FluentValidation.Results;
using HomeBroker.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBroker.Infrastructure.Data.Mappings
{
    public class CotacaoAcaoMap : IEntityTypeConfiguration<CotacaoAcao>
    {
        public void Configure(EntityTypeBuilder<CotacaoAcao> builder)
        {
            builder.HasKey(m => m.IdCotacaoAcao);

            builder.Property(m => m.IdCotacaoAcao);

            builder.Property(m => m.CodigoAcao)
                .IsRequired()
                .HasColumnName("CodigoAcao")
                .HasMaxLength(10);

            builder.Property(m => m.DataCotacao)
                .IsRequired()
                .HasColumnType("Datetime");

            builder.Property(m => m.ValorCotacao)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Ignore(m => m.ValidationResult);
            builder.Ignore(m => m.Valid);
        }
    }
}
