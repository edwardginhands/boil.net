using Microsoft.AspNet.Mvc;



namespace Boiler
{
    [Route("api/[controller]")]
    public class BoilerController : Controller
    {

        IBoilerRepository _repo;

        public BoilerController(IBoilerRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Boiler
        [HttpGet]
        public Boiler Get()
        {
            return _repo.Retrieve();
        }

        // POST: api/Boiler
        [HttpPost]
        public Boiler Post([FromBody]Boiler boiler)
        {
            return _repo.Save(boiler);
        }

        // PUT: api/Boiler/5
        [HttpPut]
        public Boiler Put([FromBody]Boiler boiler)
        {
            return _repo.Save(boiler);
        }

    }
}
