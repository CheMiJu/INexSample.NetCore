using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLifetime.Services;

namespace ServiceLifetime.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly ISingletonService _singleton;
        private readonly ITransientService _transient;
        private readonly IScopedService _scoped;
        private readonly DILifeTimeService _dILifeTime;

        public TestController(ISingletonService singleton, ITransientService transient, IScopedService scoped, DILifeTimeService dILifeTime)
        {
            _singleton = singleton;
            _transient = transient;
            _scoped = scoped;
            _dILifeTime = dILifeTime;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new
            {
                singleton_id = _singleton.Id,
                singleton_DIService_id = _dILifeTime.Singleton.Id,
                transient_id = _transient.Id,
                transient_DIService_id = _dILifeTime.Transient.Id,
                scoped_id = _scoped.Id,
                scoped_DIService_id = _dILifeTime.Scoped.Id,
            });
        }
    }
}
