using Agenda.Domain.Entity;
using Agenda.Infrastruct.Context;
using Agenda.Infrastruct.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agenda.Infrastruct.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        AgendaContext context;
        public ClienteRepository(AgendaContext ctx) : base(ctx)
        {
            context = ctx;
        }
    }
}
