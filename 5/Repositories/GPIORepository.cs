using System;
using System.Linq;
using System.IO;
using RaspberryGPIOManager;

namespace Boiler.Repositories
{
    public class GPIORepository : IBoilerRepository
    {

        private GPIOPinDriver elementPin = null;
        private GPIOPinDriver pumpPin = null;

        public GPIORepository()
        {
            elementPin = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO14);
            // Set it as an output pin.
            elementPin.Direction = GPIOPinDriver.GPIODirection.Out;
            // Give it power.
            elementPin.State = GPIOPinDriver.GPIOState.High;

            elementPin = new GPIOPinDriver(GPIOPinDriver.Pin.GPIO15);
            // Set it as an output pin.
            elementPin.Direction = GPIOPinDriver.GPIODirection.Out;
            // Give it power.
            elementPin.State = GPIOPinDriver.GPIOState.High;
        }

        public Boiler Retrieve()
        {
            throw new NotImplementedException();
        }

        public BoilerStatus RetrieveStatus()
        {
            throw new NotImplementedException();
        }

        public Boiler Save(Boiler boiler)
        {
            throw new NotImplementedException();
        }

        private double GetTemp()
        {
            //http://j.tlns.be/2014/11/24/raspberry-pi-gpios-with-ds18b20-azure-c-internet-thermometer-part-12/

            DirectoryInfo devicesDir = new DirectoryInfo("/sys/bus/w1/devices");

            double temp = 0;
            foreach (var deviceDir in devicesDir.EnumerateDirectories("28*"))
            {
                var w1slavetext =
                    deviceDir.GetFiles("w1_slave").FirstOrDefault().OpenText().ReadToEnd();
                string temptext =
                    w1slavetext.Split(new string[] { "t=" }, StringSplitOptions.RemoveEmptyEntries)[1];

                temp = double.Parse(temptext) / 1000;

            }

            return temp;
        }

    }
}
