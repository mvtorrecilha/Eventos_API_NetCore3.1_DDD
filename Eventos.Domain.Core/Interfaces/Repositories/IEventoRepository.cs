using Eventos.Domain.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Core.Interfaces.Repositories
{
    public interface IEventoRepository : IRepositoryBase<Evento>
    {
        Task<IEnumerable<Evento>> GetAllEventoAsync(bool includePalestrantes = false);
    }
}
