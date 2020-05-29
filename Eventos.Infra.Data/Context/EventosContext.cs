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

            //modelBuilder.Entity<UserRole>(userRole =>
            //{
            //    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            //    userRole.HasOne(ur => ur.Role)
            //        .WithMany(r => r.UserRoles)
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();

            //    userRole.HasOne(ur => ur.User)
            //        .WithMany(r => r.UserRoles)
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();
            //}
            //);

            //Relacionamento N para N -> Palestrante_Evento
            modelBuilder.Entity<PalestranteEvento>().
            HasKey(PE => new { PE.EventoId, PE.PalestranteId });

        }
    }
}
