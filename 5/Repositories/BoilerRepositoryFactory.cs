using System;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Configuration.Json;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.ConfigurationModel;

namespace Boiler
{
    public class BoilerRepositoryFactory
    {

        public static IBoilerRepository GetRepository()
        {
            string typeName = "Boiler.MockRepository";// ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(typeName);
            object repoInstance = Activator.CreateInstance(repoType);
            IBoilerRepository repo = repoInstance as IBoilerRepository;
            return repo;
        }
    }
}