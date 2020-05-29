using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Core.Interfaces.Services;
using Eventos.Domain.Entities.Entities;

namespace Eventos.Domain.Services.Services
{
    public class PalestranteService : ServiceBase<Palestrante>, IPalestranteService
    {
        public readonly IPalestranteRepository _repositoryPalestrante;
        public PalestranteService(IPalestranteRepository repositoryPalestrante)
            : base(repositoryPalestrante)
        {
            _repositoryPalestrante = repositoryPalestrante;
        }
    }
}
