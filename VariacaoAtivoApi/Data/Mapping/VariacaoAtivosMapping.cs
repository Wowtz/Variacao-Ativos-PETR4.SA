using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VariacaoAtivoApi.Models;

namespace VariacaoAtivoApi.Data.Mapping
{
    public class VariacaoAtivosMapping : IEntityTypeConfiguration<VariacaoAtivos>
    {
        public void Configure(EntityTypeBuilder<VariacaoAtivos> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).IsRequired();
            builder.Property(e => e.Dia).IsRequired();
            builder.Property(e => e.Data).IsRequired();
            builder.Property(e => e.Valor).IsRequired();
            builder.Property(e => e.VariacaoD1).IsRequired();
        }
    }
}
