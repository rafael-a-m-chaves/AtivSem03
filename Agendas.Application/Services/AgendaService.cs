using Agenda.Application.IServices;
using Agenda.Domain.Entity;
using Agenda.Infrastruct.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Services
{
    public class AgendaService : BaseService<Agendas>, IAgendaService
    {
        private readonly IAgendaRepository repository;
        public AgendaService(IAgendaRepository agendaRepository) : base(agendaRepository)
        {
            repository = agendaRepository;
        }
    }
}
