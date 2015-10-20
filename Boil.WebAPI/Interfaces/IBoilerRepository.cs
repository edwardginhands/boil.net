using Boil.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boil.Interfaces
{
    public interface IBoilerRepository
    {
        Boiler Save(Boiler boiler);
        Boiler Retrieve();
    }
}