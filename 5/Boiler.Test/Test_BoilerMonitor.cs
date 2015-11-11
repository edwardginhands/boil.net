using System;
using Xunit;

namespace Boiler.Test
{
    public class Test_BoilerMonitor
    {
        private MockRepository repo;
        private MockTimerAdapter timer;
        private MockBoilerUtils utils;
        private MockBoilerLogger db;
        private BoilerMonitor m;

        public Test_BoilerMonitor()
        {
            repo = new MockRepository();
            timer = new MockTimerAdapter();
            utils = new MockBoilerUtils();
            db = new MockBoilerLogger();
            m = new BoilerMonitor(repo, timer,utils, db);

        }

        [Fact]
        public void WhenCreatingANewMonitorInitializeShouldBeCalled()
        {

            Assert.True(timer.isInitilaizedCalled);
        }

        [Fact]
        public void WhenCreatingANewMonitorInitializeShouldRecieveAValidCallback()
        {


            Assert.NotNull(timer.timerCallback);

        }

        public void WhenCreatingANewMonitorRepoRetrieveShouldBeCalled()
        {


            Assert.True(repo._retrieveCalledCount > 0);

        }

        public void WhenCreatingANewMonitorRepoSaveShouldBeCalled()
        {


            Assert.True(repo._saveCalledCount > 0);

        }

        public void WhenCreatingANewMonitorBoilerUtilsDisableOnHighTempShouldBeCalled()
        {


            Assert.True(utils.isDisableOnHighTempCalled);

        }

        public void WhenCreatingANewMonitorBoilerUtilsDisableOnHighTempShouldBeCalledWithAValidBoiler()
        {


            Assert.NotNull(utils.disabledBoiler);

        }


        public void WhenCreatingANewMonitorBoilerUtilsEnableOnLowTempShouldBeCalled()
        {


            Assert.True(utils.isEnableOnLowTempCalled);

        }

        public void WhenCreatingANewMonitorBoilerUtilsEnableOnLowTempShouldBeCalledAValidBoiler()
        {


            Assert.NotNull(utils.enabledBoiler);

        }

        public void WhenCreatingANewMonitorBoilerUtilsEnableOnLowTempShouldBeCalledAValidDateTime()
        {

            Assert.True(utils.enabledLastOff > DateTime.Now.AddMinutes(-61));

        }

        public void WhenCreatingANewMonitorLoggerIsCalled()
        {

            Assert.True(db.isLogBoilerStatus);

        }



    }
}
