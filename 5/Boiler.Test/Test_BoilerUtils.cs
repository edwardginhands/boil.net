using System;
using Xunit;

namespace Boiler.Test
{
    public class Test_BoilerUtils
    {
        [Theory]
        [InlineData(80, 90, false),
        InlineData(80, 70, true),
        InlineData(80, 80, false),
        InlineData(80, 79.99, true),
        InlineData(80, 80.01, false)]
        public void WhenActualTemp_IsGreaterThanOrEqualToTargetAndElementIsOn_DisableElement(decimal target, decimal actual, bool expected)
        {
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = target;
            boiler.ActualTemp = actual;
            boiler.IsElementOn = true;

            BoilerUtils utils = new BoilerUtils();

            IBoiler alteredBoiler = utils.DisableOnHighTemp(boiler);
            Assert.Equal(alteredBoiler.IsElementOn,expected);

        }

        [Theory]
        [InlineData(80, 90, false),
        InlineData(80, 70, false),
        InlineData(80, 80, false),
        InlineData(80, 79.99, false),
        InlineData(80, 80.01, false)]
        public void WhenActualTemp_IsGreaterThanOrEqualToTargetAndElementIsOff_ElementStaysDisabled(decimal target, decimal actual, bool expected)
        {
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = target;
            boiler.ActualTemp = actual;
            boiler.IsElementOn = false;
            BoilerUtils utils = new BoilerUtils();

            IBoiler alteredBoiler = utils.DisableOnHighTemp(boiler);
            Assert.Equal(alteredBoiler.IsElementOn, expected);

        }


        [Theory]
        [InlineData(80, 90, 0, false),
        InlineData(80, 70, 0, false),
        InlineData(80, 80, 0, false),
        InlineData(80, 79.99, 0, false),
        InlineData(80, 80.01, 0, false),
        InlineData(80, 90, 9.9, false),
        InlineData(80, 70, 9.9, false),
        InlineData(80, 80, 9.9, false),
        InlineData(80, 79.99, 9.9, false),
        InlineData(80, 80.01, 9.9, false),
        InlineData(80, 90, 10, false),
        InlineData(80, 70, 10, true),
        InlineData(80, 80, 10, false),
        InlineData(80, 79.99, 10, true),
        InlineData(80, 80.01, 10, false),
        InlineData(80, 90, 10.1, false),
        InlineData(80, 70, 10.1, true),
        InlineData(80, 80, 10.1, false),
        InlineData(80, 79.99, 10.1, true),
        InlineData(80, 80.01, 10.1, false)]
        public void WhenActualTemp_IsBelowTargetAndElementIsOffForMoreThan10Seconds_EnableElement(decimal target, decimal actual, double offSeconds, bool expected)
        {
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = target;
            boiler.ActualTemp = actual;
            boiler.IsElementOn = false;
            BoilerUtils utils = new BoilerUtils();

            DateTime lastOff = DateTime.Now.AddSeconds(-offSeconds);

            IBoiler alteredBoiler = utils.EnableOnLowTemp(boiler, lastOff);

            Assert.Equal(alteredBoiler.IsElementOn, expected);

        }

    }
}
