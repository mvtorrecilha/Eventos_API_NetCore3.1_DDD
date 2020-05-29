using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Entities.Entities;
using Eventos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infra.Data.Repositories
{
    public class EventoRepository : RepositoryBase<Evento>, IEventoRepository
    {
        private readonly EventosContext _context;

        public EventoRepository(EventosContext context)
             : base(context)
        {
            _context = context;
        }
    }
}
