using Microsoft.AspNet.Mvc;

namespace Boiler
{
    [Route("api/[controller]")]
    public class BoilerStatusController : Controller
    {

        IBoilerRepository _repo;

        public BoilerStatusController(IBoilerRepository repo)
        {
            _repo = repo;
        }

        // GET: api/BoilerStatus
        [HttpGet]
        public BoilerStatus Get()
        {
            
            return _repo.RetrieveStatus();
        }

    }
}
