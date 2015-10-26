using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Dnx.Runtime;

namespace Boiler
{
    public class MockRepository : IBoilerRepository
    {
        private readonly IApplicationEnvironment _appEnvironment;

        public MockRepository()
        {

        }

        public MockRepository(IApplicationEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            // filepath = _appEnvironment.ApplicationBasePath + "data.json";
        }

        public Boiler Retrieve()
        {
            //var filePath = HostingEnvironment.MapPath(@"~/data.json");


            var filePath = Path.Combine(_appEnvironment.ApplicationBasePath, "data.json");

             var json = System.IO.File.ReadAllText(filePath);


            var boiler = JsonConvert.DeserializeObject<Boiler>(json);
            if(boiler == null)
            {
                boiler = new Boiler();
                this.Save(boiler);

            }

            return boiler;

        }

        public Boiler Save(Boiler boiler)
        {
            WriteData(boiler);
            return boiler;
        }

        public BoilerStatus RetrieveStatus()
        {
            Random r = new Random();
            Boiler b = this.Retrieve();
            int i = r.Next(10, 90);

            BoilerStatus bs = new BoilerStatus { IsElementOn = b.IsElementOn, IsPumpOn = b.IsPumpOn, Temp = r.Next(10, 90) };

            return bs;
        }


        private bool WriteData(Boiler boiler)
        {
            // Write out the Json
            // var filePath = HostingEnvironment.MapPath(@"~/data.json");

            var filePath = Path.Combine(_appEnvironment.ApplicationBasePath, "data.json");
        

            //var json = JsonConvert.SerializeObject(boiler, Formatting.Indented);
            var json = System.IO.File.ReadAllText("data.json");
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }

    }
}