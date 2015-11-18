using System;
using Xunit;

namespace Boiler.Test
{
    public class Test_BoilerUtils
    {
        [Theory]
        [InlineData(80, 90, false, true),
        InlineData(80, 70, false,  true),
        InlineData(80, 80, false, true),
        InlineData(80, 79.99, false, true),
        InlineData(80, 80.01, false, true),
        InlineData(80, 90, true, false),
        InlineData(80, 70, true, true),
        InlineData(80, 80, true, false),
        InlineData(80, 79.99, true, true),
        InlineData(80, 80.01, true, false)]
        public void WhenActualTemp_IsGreaterThanOrEqualToTargetAndElementIsOnAndIsAutoTrue_DisableElement(decimal target, decimal actual, bool isAuto, bool expected)
        {
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = target;
            boiler.ActualTemp = actual;
            boiler.IsElementOn = true;
            boiler.IsAuto = isAuto;

            BoilerUtils utils = new BoilerUtils();

            IBoiler alteredBoiler = utils.DisableOnHighTemp(boiler);
            Assert.Equal(alteredBoiler.IsElementOn,expected);

        }
        /*
        [Theory]
        [InlineData(80, 90,true, false),
        InlineData(80, 70, true, false),
        InlineData(80, 80, true, false),
        InlineData(80, 79.99, true, false),
        InlineData(80, 80.01, true, false)]
        [InlineData(80, 90, false, false),
        InlineData(80, 70, false, false),
        InlineData(80, 80, false, false),
        InlineData(80, 79.99, false, false),
        InlineData(80, 80.01, false, false)]
        public void WhenActualTemp_IsGreaterThanOrEqualToTargetAndElementIsOffAndIsAutoFalse_ElementStaysDisabled(decimal target, decimal actual, bool expected)
        {
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = target;
            boiler.ActualTemp = actual;
            boiler.IsElementOn = false;
            BoilerUtils utils = new BoilerUtils();

            IBoiler alteredBoiler = utils.DisableOnHighTemp(boiler);
            Assert.Equal(alteredBoiler.IsElementOn, expected);

        }
        */

        [Theory]
        [InlineData(80, 90, 0,true, false),
        InlineData(80, 70, 0, true, false),
        InlineData(80, 80, 0, true, false),
        InlineData(80, 79.99, 0, true, false),//
        InlineData(80, 80.01, 0, true, false),
        InlineData(80, 90, 9.9, true, false),
        InlineData(80, 70, 9.9, true, false),
        InlineData(80, 80, 9.9, true, false),
        InlineData(80, 79.99, 9.9, true, false),//
        InlineData(80, 80.01, 9.9, true, false),
        InlineData(80, 90, 10, true, false),
        InlineData(80, 70, 10, true, true),
        InlineData(80, 80, 10, true, false),
        InlineData(80, 79.99, 10, true,true),//
        InlineData(80, 80.01, 10, true, false),
        InlineData(80, 90, 10.1, true, false),
        InlineData(80, 70, 10.1, true, true),
        InlineData(80, 80, 10.1, true, false),
        InlineData(80, 79.99, 10.1, true, true),//
        InlineData(80, 80.01, 10.1, true, false)]
        public void WhenActualTemp_IsBelowTargetAndElementIsOffForMoreThan10SecondsAndIsAutoTrue_EnableElement(decimal target, decimal actual, double offSeconds, bool isAuto, bool expected)
        {
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = target;
            boiler.ActualTemp = actual;
            boiler.IsElementOn = false;
            boiler.IsAuto = isAuto;

            BoilerUtils utils = new BoilerUtils();

            DateTime lastOff = DateTime.Now.AddSeconds(-offSeconds);

            IBoiler alteredBoiler = utils.EnableOnLowTemp(boiler, lastOff);

            Assert.Equal(alteredBoiler.IsElementOn, expected);

        }

        [Theory]
        [InlineData(80, 90, 0),
        InlineData(80, 70, 0),
        InlineData(80, 80, 0),
        InlineData(80, 79.99, 0),
        InlineData(80, 80.01, 0),
        InlineData(80, 90, 9.9),
        InlineData(80, 70, 9.9),
        InlineData(80, 80, 9.9),
        InlineData(80, 79.99, 9.9),
        InlineData(80, 80.01, 9.9),
        InlineData(80, 90, 10),
        InlineData(80, 70, 10),
        InlineData(80, 80, 10),
        InlineData(80, 79.99, 10),
        InlineData(80, 80.01, 10),
        InlineData(80, 90, 10.1),
        InlineData(80, 70, 10.1),
        InlineData(80, 80, 10.1),
        InlineData(80, 79.99, 10.1),
        InlineData(80, 80.01, 10.1)]
        public void WhenActualTemp_IsBelowTargetAndElementIsOffForMoreThan10SecondsAndIsAutoFalse_ElementStausDisabled(decimal target, decimal actual, double offSeconds)
        {
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = target;
            boiler.ActualTemp = actual;
            boiler.IsElementOn = false;
            boiler.IsAuto = false;

            BoilerUtils utils = new BoilerUtils();

            DateTime lastOff = DateTime.Now.AddSeconds(-offSeconds);

            IBoiler alteredBoiler = utils.EnableOnLowTemp(boiler, lastOff);

            Assert.Equal(alteredBoiler.IsElementOn, false);

        }

    }
}
