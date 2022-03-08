using Agenda.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infrastruct.Mapping
{
    public class ClienteMap
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Nome);
            builder.Property(r => r.Telefone);
        }
    }
}
