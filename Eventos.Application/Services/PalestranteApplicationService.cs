using Eventos.Application.Interfaces;
using Eventos.Domain.Core.Interfaces.Services;
using Eventos.Domain.Entities.Entities;

namespace Eventos.Application.Services
{
    public class PalestranteApplicationService : ApplicationServiceBase<Palestrante>, IPalestranteApplicationService
    {
        private readonly IPalestranteService _palestranteService;

        public PalestranteApplicationService(IPalestranteService palestranteService)
            : base(palestranteService)
        {
            _palestranteService = palestranteService;
        }
    }
}
