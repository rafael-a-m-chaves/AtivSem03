using Agenda.Domain.Entity;
using Agenda.Infrastruct.Context;
using Agenda.Infrastruct.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agenda.Infrastruct.Repository
{
    public class ProcedimentoRepository : BaseRepository<Procedimento>, IProcedimentoRepository
    {
        AgendaContext context;
        public ProcedimentoRepository(AgendaContext ctx) : base(ctx)
        {
            context = ctx;
        }

    }
}
