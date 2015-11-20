using System;
using RaspberryGPIOManager;

namespace ExtensionMethods
{
    public static class BoilerExtensionMethods
    {
        public static bool AsBool(this GPIOPinDriver.GPIOState state)
        {
            switch(state)
            {
                case GPIOPinDriver.GPIOState.High:
                    return true;
                case GPIOPinDriver.GPIOState.Low:
                    return false;
                default:
                    throw new InvalidOperationException("State was not valid");
            }

        }

        public static GPIOPinDriver.GPIOState AsGPIOState(this bool state)
        {
            switch (state)
            {
                case true:
                    return GPIOPinDriver.GPIOState.High;
                case false:
                     return GPIOPinDriver.GPIOState.Low;
                default:
                    throw new InvalidOperationException("State was not valid");
            }

        }
    }
}
