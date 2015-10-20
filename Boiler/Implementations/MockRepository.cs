using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Newtonsoft.Json;
using System.IO;

namespace Boiler
{
    public class MockRepository : IBoilerRepository
    {

        public Boiler Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/data.json");

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

        public int GetTemperature()
        {
            Random r = new Random();
            return r.Next(10, 90);
        }

        private bool WriteData(Boiler boiler)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/data.json");

            var json = JsonConvert.SerializeObject(boiler, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }
    }
}