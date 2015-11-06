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
            _boiler = new Boiler();
        }

        public MockRepository(IApplicationEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _boiler = new Boiler();
            _boiler.ActualTemp = 10;
            _boiler.TargetTemp = 20;

        }

        public Boiler Retrieve()
        {
            //MonitorState();
            return _boiler;
        }

        public Boiler Save(Boiler boiler)
        {
            _boiler = boiler;
            return this.Retrieve();
        }
        
       

    }
}