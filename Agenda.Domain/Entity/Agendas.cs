namespace Agenda.Domain.Entity
{
    public class Agendas
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
        public Procedimento Procedimento { get; set; }
        public int IdProcedimento { get; set; }
        public bool Realizado { get; set; }

    }
}
