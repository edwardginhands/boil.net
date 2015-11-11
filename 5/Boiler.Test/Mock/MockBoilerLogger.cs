using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Boiler.Test
{
    public class MockBoilerLogger :  IBoilerLogger
    {
        public bool isLogBoilerStatus;

        public MockBoilerLogger()
        {
            isLogBoilerStatus = false;
        }

        public void LogBoilerStatus(BoilerStatus item)
        {
            isLogBoilerStatus = true;
        }

    }
}
