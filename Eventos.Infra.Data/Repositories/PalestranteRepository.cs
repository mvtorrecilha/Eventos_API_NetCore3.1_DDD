using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Entities.Entities;
using Eventos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infra.Data.Repositories
{
    public class PalestranteRepository : RepositoryBase<Palestrante>, IPalestranteRepository
    {
        private readonly EventosContext _context;

        public PalestranteRepository(EventosContext context)
             : base(context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
