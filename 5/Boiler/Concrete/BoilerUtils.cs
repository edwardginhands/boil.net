using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boiler
{
    public static class BoilerUtils
    {
        public static IBoiler DisableOnHighTemp(IBoiler boiler)
        {
            if (boiler.ActualTemp >= boiler.TargetTemp && boiler.IsElementOn == true)
            {
                boiler.IsElementOn = false;
                return boiler;
            }
            else
                return boiler;
        }

        public static IBoiler EnableOnLowTemp(IBoiler boiler, DateTime lastOff)
        {
            if ((DateTime.Now - lastOff).TotalSeconds >= 10 && boiler.ActualTemp < boiler.TargetTemp)
            {
                boiler.IsElementOn = true;
                return boiler;
            }
            else
                return boiler;
        }
    }
}
