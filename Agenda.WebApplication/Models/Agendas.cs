using System;
using System.Collections.Generic;
using Agenda.Domain.Entity;

namespace Agenda.WebApplication.Models
{
    public class Agendas
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
        public Procedimento Procedimento { get; set; }
        public int IdProcedimento { get; set; }
        public bool Realizado { get; set; }
        public DateTime? DataAgendamento { get; set; }


        //para preencher o select na hora de criar nova agenda

        public List<Cliente> ClienteList { get; set; }
        public List <Procedimento> ProcedimentoList { get; set; }
    }
}
