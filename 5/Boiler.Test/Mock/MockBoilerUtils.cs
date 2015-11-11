using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boiler.Test
{
    public class MockBoilerUtils : IBoilerUtils
    {
        public bool isDisableOnHighTempCalled;
        public bool isEnableOnLowTempCalled;
        public IBoiler disabledBoiler;
        public IBoiler enabledBoiler;
        public DateTime enabledLastOff;

        public MockBoilerUtils()
        {
            isDisableOnHighTempCalled = false;
            isEnableOnLowTempCalled = false;
        }

        public IBoiler DisableOnHighTemp(IBoiler boiler)
        {
            isDisableOnHighTempCalled = true;
            disabledBoiler = boiler;
            return new Boiler();
        }

        public IBoiler EnableOnLowTemp(IBoiler boiler, DateTime lastOff)
        {
            isEnableOnLowTempCalled = true;
            enabledBoiler = boiler;
            enabledLastOff = lastOff;
            return new Boiler();
        }
    }
}
