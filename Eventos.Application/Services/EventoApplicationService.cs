using Eventos.Application.Interfaces;
using Eventos.Domain.Core.Interfaces.Services;
using Eventos.Domain.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Application.Services
{
    public class EventoApplicationService : ApplicationServiceBase<Evento>, IEventoApplicationService
    {
        private readonly IEventoService _eventoService;

        public EventoApplicationService(IEventoService eventoService)
            : base(eventoService)
        {
            _eventoService = eventoService;
        }

        public async Task<IEnumerable<Evento>> GetAllEventoAsync(bool includePalestrantes = false)
        {
            return await _eventoService.GetAllEventoAsync(includePalestrantes);
        }
    }
}
