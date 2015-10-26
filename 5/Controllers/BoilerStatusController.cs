using Microsoft.AspNet.Mvc;

namespace Boiler
{
    public class BoilerStatusController : Controller
    {
        // GET: api/BoilerStatus
        
        public BoilerStatus Get()
        {
            IBoilerRepository repo = BoilerRepositoryFactory.GetRepository();
            return repo.RetrieveStatus();
        }

    }
}
