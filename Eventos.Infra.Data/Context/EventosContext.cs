using Eventos.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infra.Data.Context
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relacionamento N para N -> Palestrante_Evento
            modelBuilder.Entity<PalestranteEvento>().
            HasKey(PE => new { PE.EventoId, PE.PalestranteId });

        }
    }
}
