using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Boiler.Startup))]

namespace Boiler
{
    public partial class Startup
    {
        private TempTicker _backgroundTicker;

        public void Configuration(IAppBuilder app)
        {
            _backgroundTicker = new TempTicker();
            app.MapSignalR();
        }
    }
}
