using Microsoft.EntityFrameworkCore;
using Agenda.Domain.Entity;
using Agenda.Infrastruct.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Infrastruct.Context
{
    public class AgendaContext : IdentityDbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        { 
        }
        public AgendaContext()
        {
        }
        public DbSet<Agendas> Agendas { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Procedimento> Procedimento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agendas>(new AgendaMap().Configure);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Procedimento>(new ProcedimentoMap().Configure);
        }
    }
}
