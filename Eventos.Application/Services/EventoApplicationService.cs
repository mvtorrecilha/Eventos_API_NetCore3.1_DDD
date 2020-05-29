using Eventos.Application.Interfaces;
using Eventos.Domain.Core.Interfaces.Services;
using Eventos.Domain.Entities.Entities;

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
    }
}
