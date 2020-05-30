using Eventos.Domain.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Application.Interfaces
{
    public interface IEventoApplicationService : IApplicationServiceBase<Evento>
    {
        Task<IEnumerable<Evento>> GetAllEventoAsync(bool includePalestrantes = false);
    }
}
