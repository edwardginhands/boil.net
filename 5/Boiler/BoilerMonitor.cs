using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Dnx.Runtime;

namespace Boiler
{
    public class BoilerMonitor
    {
        private IBoilerRepository _repo;
        private DateTime lastRecorded;
        private DateTime lastOff;
        private Timer stateTimer;
        private TimerCallback stateTCB;


        public BoilerMonitor(IBoilerRepository repo)
        {
            _repo = repo;
          //  lastStatus = new BoilerStatus(_repo.Retrieve());

            lastRecorded = DateTime.Now;
            lastOff = DateTime.Now.AddHours(-1);

            stateTCB = this.MonitorState;
            // Create a timer
            stateTimer = new Timer(stateTCB, null, 0, 5000);
        }

        private void MonitorState(object source)
        {
            //BoilerStatus boilerStatus = new BoilerStatus(_repo.Retrieve());

            Boiler boiler = _repo.Retrieve();

            if (boiler.ActualTemp >= boiler.TargetTemp && boiler.IsElementOn == true)
            {
                boiler.IsElementOn = false;
                lastOff = DateTime.Now;
            }
            if ((DateTime.Now - lastOff).TotalSeconds > 10 && boiler.ActualTemp < boiler.TargetTemp)
            {
                boiler.IsElementOn = true;
            }

            _repo.Save(boiler);


            // fudge to make the clock tick, doesnt belong here
            decimal diffInSeconds = (decimal)((DateTime.Now - lastRecorded).TotalSeconds);
            boiler.ActualTemp = boiler.ActualTemp + (diffInSeconds * (boiler.IsElementOn == false ? -1 : 1));

            /* logging to be added
            using (var db = new BoilerDbContext())
            {
                BoilerStatus bs = new BoilerStatus(boilerStatus);
                bs.LoggedDate = DateTime.Now;

                db.Boiler.Add(bs);
                db.SaveChanges();
            }
            */

            lastRecorded = DateTime.Now;

            _repo.Save(boiler);
        }
    }
}
