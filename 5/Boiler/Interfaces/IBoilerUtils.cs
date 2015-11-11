using System;


namespace Boiler
{
    public interface IBoilerUtils
    {
        IBoiler DisableOnHighTemp(IBoiler boiler);
        IBoiler EnableOnLowTemp(IBoiler boiler, DateTime lastOff);
    }
}
