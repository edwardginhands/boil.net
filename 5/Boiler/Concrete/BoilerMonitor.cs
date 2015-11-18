using System;
using System.Threading;

namespace Boiler
{
    public class BoilerMonitor
    {
        private IBoilerRepository _repo;
        private DateTime lastRecorded;
        private DateTime lastOff;
        private IBoilerUtils _utils;
        private IBoilerStatusRepository _logger;


        public BoilerMonitor(IBoilerRepository repo, ITimerAdapter timer, IBoilerUtils utils, IBoilerStatusRepository logger)
        {
            _repo = repo;
            _utils = utils;
            _logger = logger;

            lastRecorded = DateTime.Now;
            lastOff = DateTime.Now.AddHours(-1);

            IBoiler b = logger.Retrieve().ToBoiler();
            _repo.Save(b);

            timer.Initialize(MonitorState);
            //  GC.KeepAlive(timer);


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

            IBoiler alteredBoiler = _utils.DisableOnHighTemp(boiler);

            _repo.Save(alteredBoiler);
        }

        private void CheckLowTemp()
        {

            IBoiler boiler = _repo.Retrieve();

            IBoiler alteredBoiler = _utils.EnableOnLowTemp(boiler, lastOff);

            _repo.Save(alteredBoiler);

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
