using System;
using System.Threading;

namespace Boiler
{
    public class BoilerMonitor
    {
        private IBoilerRepository _repo;
        //private DateTime lastRecorded;
        private DateTime lastOff;
        private IBoilerStatusRepository _logger;


        public BoilerMonitor(IBoilerRepository repo, ITimerAdapter timer, IBoilerStatusRepository logger)
        {
            _repo = repo;
            _logger = logger;

           // lastRecorded = DateTime.Now;
            lastOff = DateTime.Now.AddHours(-1);

            IBoiler b = logger.Retrieve().ToBoiler();
            _repo.Save(b);

            timer.Initialize(MonitorState);
            //  GC.KeepAlive(timer);


        }
     
        private void MonitorState(object source)
        {
            IBoiler boiler = _repo.Retrieve();

            DateTime n = DateTime.Now;

            //boiler.DisableOnHighTemp();
            //boiler.EnableOnLowTemp(n);
            boiler.BurstCycleOff(n);
            boiler.BurstCycleOn(n);

            _repo.Save(boiler);

            LogState();

        }


        private void LogState()
        {
            IBoiler boiler = _repo.Retrieve();
            BoilerStatus bs = new BoilerStatus(boiler);
            bs.LoggedDate = DateTime.Now;
            _logger.Save(bs);

        }
    }
}
