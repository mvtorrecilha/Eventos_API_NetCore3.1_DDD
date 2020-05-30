using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Entities.Entities;
using Eventos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Infra.Data.Repositories
{
    public class LoteRepository : RepositoryBase<Lote>, ILoteRepository
    {
        private readonly EventosContext _context;

        public LoteRepository(EventosContext context)
             : base(context)
        {
            _context = context;
        }

    }
}
