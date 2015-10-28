using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Dnx.Runtime;

namespace Boiler
{
    public class MockRepository : IBoilerRepository
    {
        private readonly IApplicationEnvironment _appEnvironment;
        private Boiler _boiler;

        public MockRepository()
        {

        }

        public MockRepository(IApplicationEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _boiler = new Boiler();
        }

        public Boiler Retrieve()
        {
            return _boiler;
        }

        public Boiler Save(Boiler boiler)
        {
            _boiler = boiler;
            return this.Retrieve();
        }

        public BoilerStatus RetrieveStatus()
        {
            Random r = new Random();
            Boiler b = this.Retrieve();
            int i = r.Next(10, 90);

            BoilerStatus bs = new BoilerStatus { IsElementOn = b.IsElementOn, IsPumpOn = b.IsPumpOn, Temp = r.Next(10, 90) };

            return bs;
        }

    }
}