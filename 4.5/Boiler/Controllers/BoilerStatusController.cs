using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Boiler
{
    public class BoilerStatusController : ApiController
    {
        // GET: api/BoilerStatus
        public BoilerStatus Get()
        {
            IBoilerRepository repo = BoilerRepositoryFactory.GetRepository();
            return repo.RetrieveStatus();
        }

    }
}
