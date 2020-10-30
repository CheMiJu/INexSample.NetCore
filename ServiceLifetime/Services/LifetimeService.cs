using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLifetime.Services
{
    public class LifetimeService : ISingletonService, ITransientService, IScopedService
    {
        private Guid _id;
        public Guid Id => _id;

        public LifetimeService()
        {
            _id = Guid.NewGuid();
        }
    }
}
