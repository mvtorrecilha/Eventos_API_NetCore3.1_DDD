using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Entities.Entities;
using Eventos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Infra.Data.Repositories
{
    public class RedeSocialRepository : RepositoryBase<RedeSocial>, IRedeSocialRepository
    {
        private readonly EventosContext _context;

        public RedeSocialRepository(EventosContext context)
             : base(context)
        {
            _context = context;
        }

    }
}
