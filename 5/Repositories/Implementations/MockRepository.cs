using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Dnx.Runtime;
using System.Threading;

namespace Boiler
{
    public class MockRepository : IBoilerRepository
    {
        private readonly IApplicationEnvironment _appEnvironment;
        private Boiler _boiler;
        private DateTime lastRecorded;
        private DateTime lastOff;
        private Timer stateTimer;
        private TimerCallback stateTCB;



        public MockRepository()
        {
            _boiler = new Boiler();
        }

        public MockRepository(IApplicationEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _boiler = new Boiler();
            lastRecorded = DateTime.Now;
            lastOff = DateTime.Now.AddHours(-1);
            _boiler.ActualTemp = 10;
            _boiler.TargetTemp = 20;

            stateTCB = this.MonitorState;

            // Create a timer
            stateTimer = new Timer(stateTCB, null,0,5000);

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
        
        private void MonitorState(object source)
        {

            if(_boiler.ActualTemp >= _boiler.TargetTemp && _boiler.IsElementOn == true)
            {
                _boiler.IsElementOn = false;
                lastOff = DateTime.Now;
            }
            if ((DateTime.Now - lastOff).TotalSeconds > 10 && _boiler.ActualTemp < _boiler.TargetTemp)
            {
                _boiler.IsElementOn = true;
            }

            decimal diffInSeconds = (decimal)((DateTime.Now - lastRecorded).TotalSeconds);

           
            _boiler.ActualTemp = _boiler.ActualTemp + (diffInSeconds * (_boiler.IsElementOn == false ? -1 : 1));

            using (var db = new BoilerDbContext())
            {
                BoilerStatus bs = new BoilerStatus(_boiler);
                bs.LoggedDate = DateTime.Now;

                db.Boiler.Add(bs);
                db.SaveChanges();
            }

            lastRecorded = DateTime.Now;
        }

    }
}