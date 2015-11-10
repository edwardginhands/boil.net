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

          lastRecorded = DateTime.Now;
          lastOff = DateTime.Now.AddHours(-1);

          stateTCB = this.MonitorState;
          // Create a timer
          stateTimer = new Timer(stateTCB, null, 0, 5000);
      }
     
        private void MonitorState(object source)
        {
            CheckHighTemp();
            CheckLowTemp();
            LogState();
            lastRecorded = DateTime.Now;
        }

        private void CheckHighTemp()
        {

            IBoiler boiler = _repo.Retrieve();

            IBoiler alteredBoiler = BoilerUtils.DisableOnHighTemp(boiler);

            _repo.Save(alteredBoiler);
        }

        private void CheckLowTemp()
        {

            IBoiler boiler = _repo.Retrieve();

            IBoiler alteredBoiler = BoilerUtils.EnableOnLowTemp(boiler, lastOff);

            _repo.Save(alteredBoiler);

        }

        private void LogState()
        {
            IBoiler boiler = _repo.Retrieve();
            using (var db = new BoilerDbContext())
            {
                BoilerStatus bs = new BoilerStatus(boiler);
                bs.LoggedDate = DateTime.Now;

                db.Boiler.Add(bs);
                db.SaveChanges();
            }

        }
    }
}
