using Agenda.Domain.Entity;
using Agenda.Infrastruct.Context;
using Agenda.Infrastruct.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agenda.Infrastruct.Repository
{
    public class AgendaRepository : BaseRepository<Agendas>, IAgendaRepository
    {
        AgendaContext context;
        public AgendaRepository(AgendaContext ctx) : base(ctx)
        {
            context = ctx;
        }

        public override ICollection<Agendas> Get()
        {
            return context.Agendas
                      .Include(r => r.Cliente)
                      .Include(r => r.Procedimento)
                      .ToList();
        }

        public override Agendas Find(Expression<System.Func<Agendas, bool>> predicate)
        {
            return context.Agendas
                      .Include(t => t.Cliente).DefaultIfEmpty()
                      .Include(t => t.Procedimento).DefaultIfEmpty()
                      .FirstOrDefault(predicate);
        }

        public override Agendas FindById(int id)
        {
            return context.Agendas
                      .Include(t => t.Cliente).DefaultIfEmpty()
                      .Include(t => t.Procedimento).DefaultIfEmpty()
                      .FirstOrDefault(t => t.Id == id);
        }
    }
}
