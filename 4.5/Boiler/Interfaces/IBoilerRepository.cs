using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boiler
{
    public interface IBoilerRepository
    {
        Boiler Save(Boiler boiler);
        Boiler Retrieve();
        BoilerStatus RetrieveStatus();
    }
}