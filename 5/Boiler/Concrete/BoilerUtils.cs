using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boiler
{
    public class BoilerUtils : IBoilerUtils
    {
        public IBoiler DisableOnHighTemp(IBoiler boiler)
        {
            if (boiler.ActualTemp >= boiler.TargetTemp && boiler.IsElementOn == true && boiler.IsAuto==true)
            {
                boiler.IsElementOn = false;
                return boiler;
            }
            else
                return boiler;
        }

        public IBoiler EnableOnLowTemp(IBoiler boiler, DateTime lastOff)
        {
            if ((DateTime.Now - lastOff).TotalSeconds >= 10 && boiler.ActualTemp < boiler.TargetTemp && boiler.IsAuto == true)
            {
                boiler.IsElementOn = true;
                return boiler;
            }
            else
                return boiler;
        }
    }
}
