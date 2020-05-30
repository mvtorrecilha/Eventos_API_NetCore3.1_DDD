using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Entities.Entities;
using Eventos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<IEnumerable<Evento>> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                        .Include(pe => pe.PalestrantesEventos)
                        .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderByDescending(c => c.DataEvento);

            return await query.ToListAsync();
        }
    }
}
