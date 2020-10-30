using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLifetime.Services
{
    public interface ILifetime
    {
        public Guid Id { get; }
    }
}
