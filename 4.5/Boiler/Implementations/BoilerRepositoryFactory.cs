using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Boiler
{
    public class BoilerRepositoryFactory
    {
        public static IBoilerRepository GetRepository()
        {
            string typeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(typeName);
            object repoInstance = Activator.CreateInstance(repoType);
            IBoilerRepository repo = repoInstance as IBoilerRepository;
            return repo;
        }
    }
}