using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Boiler.Test
{
    public class MockBoilerLogger :  IBoilerStatusRepository
    {
        public bool isLogBoilerStatus;
        public bool isLogRetrieveStatus;

        public MockBoilerLogger()
        {
            isLogBoilerStatus = false;
        }

        public void LogBoilerStatus(BoilerStatus item)
        {
            isLogBoilerStatus = true;
        }

        public IBoilerStatus Retrieve()
        {
            isLogRetrieveStatus = true;
            return new BoilerStatus();
        }

        public IBoilerStatus Save(IBoilerStatus boiler)
        {
            isLogBoilerStatus = true;
            return boiler;
        }
    }
}
