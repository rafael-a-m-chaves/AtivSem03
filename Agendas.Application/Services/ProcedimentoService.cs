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
    public class ProcedimentoService : BaseService<Procedimento>, IProcedimentoService
    {
        private readonly IProcedimentoRepository repository;
        public ProcedimentoService(IProcedimentoRepository procedimentoRepository) : base(procedimentoRepository)
        {
            repository = procedimentoRepository;
        }
    }
}
