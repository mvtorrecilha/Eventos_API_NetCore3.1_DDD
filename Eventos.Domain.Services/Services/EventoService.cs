using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Core.Interfaces.Services;
using Eventos.Domain.Entities.Entities;

namespace Eventos.Domain.Services.Services
{
    public class EventoService : ServiceBase<Evento>, IEventoService
    {
        public readonly IEventoRepository _repositoryEvento;

        public EventoService(IEventoRepository repositoryEvento)
            : base(repositoryEvento)
        {
            _repositoryEvento = repositoryEvento;
        }

    }
}
