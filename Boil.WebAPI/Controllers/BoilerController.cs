using Boil.Interfaces;
using Boil.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Boil.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class BoilerController : ApiController
    {
        // GET: api/Boiler
        
        public Boiler Get()
        {
            IBoilerRepository repo = BoilerRepositoryFactory.GetRepository();
            return repo.Retrieve();
        }

        // POST: api/Boiler
        public Boiler Post([FromBody]Boiler boiler)
        {
            IBoilerRepository repo = BoilerRepositoryFactory.GetRepository();
            return repo.Save(boiler);
        }

        // PUT: api/Boiler/5
        public Boiler Put([FromBody]Boiler boiler)
        {
            IBoilerRepository repo = BoilerRepositoryFactory.GetRepository();
            return repo.Save(boiler);
        }

    }
}
