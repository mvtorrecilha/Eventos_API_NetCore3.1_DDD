using Eventos.Domain.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Core.Interfaces.Services
{
    public interface IEventoService : IServiceBase<Evento>
    {
        Task<IEnumerable<Evento>> GetAllEventoAsync(bool includePalestrantes = false);
    }
}
