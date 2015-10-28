using System;
using System.Linq;
using System.IO;
using RaspberryGPIOManager;
using ExtensionMethods;

namespace Boiler.Repositories
{
    public class GPIORepository : IBoilerRepository
    {

        private GPIOPinDriver elementPin = null;
        private GPIOPinDriver pumpPin = null;
        private Boiler _boiler;

        public GPIORepository()
        {
            _boiler = new Boiler();

            elementPin = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO14);
            // Set it as an output pin.
            elementPin.Direction = GPIOPinDriver.GPIODirection.Out;
            // Give it power.
            elementPin.State = GPIOPinDriver.GPIOState.Low;

            pumpPin = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO15);
            // Set it as an output pin.
            pumpPin.Direction = GPIOPinDriver.GPIODirection.Out;
            // Give it power.
            pumpPin.State = GPIOPinDriver.GPIOState.Low;
        }

        public Boiler Retrieve()
        {
            _boiler.IsElementOn = elementPin.State.AsBool();
            _boiler.IsPumpOn = pumpPin.State.AsBool();

            return _boiler;
        }

        public BoilerStatus RetrieveStatus()
        {
            if(GetTemp() > _boiler.TargetTemp)
            {
                Boiler b = _boiler;
                b.IsElementOn = false;
                this.Save(b);
            }

            BoilerStatus bs = new BoilerStatus
            {
                IsElementOn = elementPin.State.AsBool(),
                IsPumpOn = pumpPin.State.AsBool(),
                Temp = GetTemp()
            };
            return bs;
        }

        public Boiler Save(Boiler boiler)
        {
            elementPin.State = boiler.IsElementOn.AsGPIOState();
            pumpPin.State = boiler.IsPumpOn.AsGPIOState();
            _boiler.TargetTemp = boiler.TargetTemp;
            _boiler.TempOffset = boiler.TargetTemp;

            return this.Retrieve();
        }

        private decimal GetTemp()
        {
            //http://j.tlns.be/2014/11/24/raspberry-pi-gpios-with-ds18b20-azure-c-internet-thermometer-part-12/

            DirectoryInfo devicesDir = new DirectoryInfo("/sys/bus/w1/devices");

            decimal temp = 0;
            foreach (var deviceDir in devicesDir.EnumerateDirectories("28*"))
            {
                var w1slavetext =
                    deviceDir.GetFiles("w1_slave").FirstOrDefault().OpenText().ReadToEnd();
                string temptext =
                    w1slavetext.Split(new string[] { "t=" }, StringSplitOptions.RemoveEmptyEntries)[1];

                temp = decimal.Parse(temptext) / 1000;

            }

            return temp;
        }



    }
}
