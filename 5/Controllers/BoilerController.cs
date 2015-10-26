using Microsoft.AspNet.Mvc;



namespace Boiler
{
    [Route("api/[controller]")]
    public class BoilerController : Controller
    {

        IBoilerRepository _repo;

        public BoilerController(MockRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Boiler
        [HttpGet]
        public Boiler Get()
        {
          // IBoilerRepository repo = BoilerRepositoryFactory.GetRepository();
            return _repo.Retrieve();
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
