using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLifetime.Services
{
    public class DILifeTimeService
    {
        private readonly ISingletonService _singleton;
        private readonly ITransientService _transient;
        private readonly IScopedService _scoped;

        public ISingletonService Singleton => _singleton;
        public ITransientService Transient => _transient;
        public IScopedService Scoped => _scoped;

        public DILifeTimeService(ISingletonService singleton, ITransientService transient, IScopedService scoped)
        {
            _singleton = singleton;
            _transient = transient;
            _scoped = scoped;
        }
    }
}
