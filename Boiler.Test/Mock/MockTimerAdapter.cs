using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Boiler.Test
{
    public class MockTimerAdapter : ITimerAdapter
    {
        public bool isInitilaizedCalled;
        public TimerCallback timerCallback; 

        public MockTimerAdapter()
        {
            isInitilaizedCalled = false;
        }

        public void Initialize(TimerCallback callback)
        {
            isInitilaizedCalled = true;
            timerCallback = callback;
            callback.Invoke(null);
        }
    }
}
