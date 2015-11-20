using System;
using Xunit;

namespace Boiler.Test
{
    public class Test_Boiler_Methods
    {
        // Burst enabled tests
        #region
        [Fact]
        public void WhenBurstTimeHasElapsed_DisableElement_WhenAutoOff()
        {
            Boiler b = new Boiler();
            b.BurstTime = 10;
            b.BurstInterval= 100;
            b.IsElementOn = true;
            b.IsBurstOn = true;
            b.IsAuto = false;

            bool ret = b.BurstCycleOff(DateTime.Now.AddSeconds(11));

            Assert.True(ret);
            Assert.False(b.IsElementOn);
        }

        public void WhenBurstTimeHasElapsed_DisableElement_WhenAutoOn()
        {
            Boiler b = new Boiler();
            b.BurstTime = 10;
            b.BurstInterval = 100;
            b.IsElementOn = true;
            b.IsBurstOn = true;
            b.IsAuto = true;

            bool ret = b.BurstCycleOff(DateTime.Now.AddSeconds(11));

            Assert.False(ret);
            Assert.True(b.IsElementOn);
        }

        [Fact]
        public void WhenBurstTimeHasNotElapsed_DoNotDisableElement_WhenAutoOff()
        {
            Boiler b = new Boiler();
            b.BurstTime = 10;
            b.BurstInterval = 100;
            b.IsElementOn = true;
            b.IsBurstOn = true;
            b.IsAuto = false;

            bool ret = b.BurstCycleOff(DateTime.Now.AddSeconds(5));

            Assert.False(ret);
            Assert.True(b.IsElementOn);
        }

        [Fact]
        public void WhenBurstTimeHasNotElapsed_DoNotDisableElement_WhenAutoOn()
        {
            Boiler b = new Boiler();
            b.BurstTime = 10;
            b.BurstInterval = 100;
            b.IsElementOn = true;
            b.IsBurstOn = true;
            b.IsAuto = true;

            bool ret = b.BurstCycleOff(DateTime.Now.AddSeconds(5));

            Assert.False(ret);
            Assert.True(b.IsElementOn);
        }

        [Fact]
        public void WhenBurstIntervalHasElapsed_EnableElement_WhenAutoOff()
        {
            Boiler b = new Boiler();
            b.BurstTime = 100;
            b.BurstInterval = 10;
            b.IsElementOn = true;
            b.IsBurstOn = true;
            b.IsAuto = false;

            bool ret = b.BurstCycleOn(DateTime.Now.AddSeconds(11));

            Assert.True(ret);
            Assert.True(b.IsElementOn);

        }

        [Fact]
        public void WhenBurstIntervalHasElapsed_EnableElement_WhenAutoOn()
        {
            Boiler b = new Boiler();
            b.BurstTime = 100;
            b.BurstInterval = 10;
            b.IsElementOn = false;
            b.IsBurstOn = true;
            b.IsAuto = true;

            bool ret = b.BurstCycleOn(DateTime.Now.AddSeconds(11));

            Assert.False(ret);
            Assert.False(b.IsElementOn);

        }

        [Fact]
        public void WhenBurstIntervalHasNotElapsed_DoNotEnableElement_WhenAutoOff()
        {
            Boiler b = new Boiler();
            b.BurstTime = 100;
            b.BurstInterval = 10;
            b.IsElementOn = true;
            b.IsBurstOn = true;
            b.IsAuto = false;

            bool ret = b.BurstCycleOn(DateTime.Now.AddSeconds(5));

            Assert.False(ret);
            Assert.False(b.IsElementOn);

        }

        [Fact]
        public void WhenBurstIntervalHasNotElapsed_DoNotEnableElement_WhenAutoOn()
        {
            Boiler b = new Boiler();
            b.BurstTime = 100;
            b.BurstInterval = 10;
            b.IsElementOn = true;
            b.IsBurstOn = true;
            b.IsAuto = true;

            bool ret = b.BurstCycleOn(DateTime.Now.AddSeconds(5));

            Assert.False(ret);
            Assert.True(b.IsElementOn);

        }
        #endregion

        // Burst not enabled tests, state should remain same
        #region
        [Fact]
        public void WhenBurstTimeHasElapsed_DisableElement_UnlessBurstIsOff()
        {
            Boiler b = new Boiler();
            b.BurstTime = 10;
            b.BurstInterval = 100;
            b.IsElementOn = true;
            b.IsBurstOn = false;

            bool ret = b.BurstCycleOff(DateTime.Now.AddSeconds(11));

            Assert.False(ret);
            Assert.True(b.IsElementOn);
        }

        [Fact]
        public void WhenBurstTimeHasNotElapsed_DoNotDisableElement_UnlessBurstIsOff()
        {
            Boiler b = new Boiler();
            b.BurstTime = 10;
            b.BurstInterval = 100;
            b.IsElementOn = true;
            b.IsBurstOn = false;

            bool ret = b.BurstCycleOff(DateTime.Now.AddSeconds(5));

            Assert.False(ret);
            Assert.True(b.IsElementOn);
        }


        [Fact]
        public void WhenBurstIntervalHasElapsed_EnableElement_UnlessBurstIsOff()
        {
            Boiler b = new Boiler();
            b.BurstTime = 100;
            b.BurstInterval = 10;
            b.IsElementOn = true;
            b.IsBurstOn = false;

            bool ret = b.BurstCycleOn(DateTime.Now.AddSeconds(11));

            Assert.False(ret);
            Assert.True(b.IsElementOn);

        }

        [Fact]
        public void WhenBurstIntervalHasNotElapsed_DoNotEnableElement_UnlessBurstIsOff()
        {
            Boiler b = new Boiler();
            b.BurstTime = 100;
            b.BurstInterval = 10;
            b.IsElementOn = true;
            b.IsElementOn = false;
            b.IsBurstOn = false;

            bool ret = b.BurstCycleOn(DateTime.Now.AddSeconds(5));

            Assert.False(ret);
            Assert.False(b.IsElementOn);

        }
        #endregion



        [Fact]
        public void When_DisableOnHighTemp_DisablesTheElement_TheLastOffDateIsSet()
        {
            Boiler b = new Boiler();
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = 10;
            boiler.ActualTemp = 11;
            boiler.IsElementOn = true;
            boiler.IsAuto = true;

            DateTime dt = boiler.LastOff;
            bool ret = boiler.DisableOnHighTemp();
            Assert.True(dt.Ticks < boiler.LastOff.Ticks);

        }

        //auto mode tests
        #region 
        [Theory]
        [InlineData(80, 90, false, true),
        InlineData(80, 70, false, true),
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

            //BoilerUtils utils = new BoilerUtils();
            bool ret = boiler.DisableOnHighTemp();
            Assert.Equal(boiler.IsElementOn, expected);

        }

        [Theory]
        [
        // less than 10 secs can enable element if diff is > 1
        InlineData(80, 90, 0, true, false),
        InlineData(80, 70, 0, true, true),
        InlineData(80, 80, 0, true, false),
        InlineData(80, 79.99, 0, true, false),//
        InlineData(80, 80.01, 0, true, false),
        InlineData(80, 90, 9.9, true, false),
        InlineData(80, 70, 9.9, true, true),
        InlineData(80, 80, 9.9, true, false),
        InlineData(80, 79.99, 9.9, true, false),//
        InlineData(80, 80.01, 9.9, true, false),

        InlineData(80, 90, 10, true, false),
        InlineData(80, 70, 10, true, true),
        InlineData(80, 80, 10, true, false),
        InlineData(80, 79.99, 10, true, true),//
        InlineData(80, 80.01, 10, true, false),
        InlineData(80, 90, 10.1, true, false),
        InlineData(80, 70, 10.1, true, true),
        InlineData(80, 80, 10.1, true, false),
        InlineData(80, 79.99, 10.1, true, true),//
        InlineData(80, 80.01, 10.1, true, false)
        ]
        public void WhenActualTemp_IsBelowTargetAndElementIsOffForMoreThan10SecondsAndIsAutoTrue_EnableElement(decimal target, decimal actual, double offSeconds, bool isAuto, bool expected)
        {
            IBoiler boiler = new Boiler();
            boiler.TargetTemp = target;
            boiler.ActualTemp = actual;
            boiler.IsElementOn = false;
            boiler.IsAuto = isAuto;



            DateTime dueDate = DateTime.Now.AddSeconds(offSeconds);
            boiler.EnableOnLowTemp(dueDate);

            Assert.Equal(boiler.IsElementOn, expected);

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


            DateTime dueDate = DateTime.Now.AddSeconds(offSeconds);
        
            boiler.EnableOnLowTemp(dueDate);

            Assert.Equal(boiler.IsElementOn, false);

        }
        #endregion

    }
}
