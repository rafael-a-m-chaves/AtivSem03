using Agenda.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastruct.Mapping
{
    public class ProcedimentoMap
    {
        public void Configure(EntityTypeBuilder<Procedimento> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.NomeProcedimento);
            builder.Property(r => r.Valor);
        }
    }
}
