using Agenda.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastruct.Mapping
{
    public class AgendaMap
    {
        public void Configure(EntityTypeBuilder<Agendas> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(x => x.IdCliente);
            builder.HasOne(r => r.Procedimento)
                .WithMany()
                .HasForeignKey(x => x.IdProcedimento);
            builder.Property(r => r.DataAgendamento);
            builder.Property(r => r.Realizado);
        }
    }
}
