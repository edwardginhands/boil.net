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
            Random r = new Random();
            _boiler.ActualTemp = r.Next(10, 90);

            using (var db = new BoilerDbContext())
            {
                BoilerStatus bs = new BoilerStatus(_boiler);
                bs.LoggedDate = DateTime.Now;

                db.Boiler.Add(bs);
                db.SaveChanges();
            }

            return _boiler;


        }

        public Boiler Save(Boiler boiler)
        {
            _boiler = boiler;
            return this.Retrieve();
        }


    }
}