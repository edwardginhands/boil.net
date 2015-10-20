using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;

namespace Boiler
{
    public class TempTicker : IRegisteredObject
    {
        private Timer taskTimer;
        private IHubContext hub;


        public TempTicker()
        {
            HostingEnvironment.RegisterObject(this);

            hub = GlobalHost.ConnectionManager.GetHubContext<TempHub>();

            taskTimer = new Timer(OnTimerElapsed, null,
                TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(.1));
        }

        private void OnTimerElapsed(object sender)
        {
            IBoilerRepository repo = BoilerRepositoryFactory.GetRepository();
            int temp = repo.GetTemperature();

            hub.Clients.All.broadcastMessage(DateTime.UtcNow.ToString(), temp);

        }

        public void Stop(bool immediate)
        {
            taskTimer.Dispose();

            HostingEnvironment.UnregisterObject(this);
        }
    }
}