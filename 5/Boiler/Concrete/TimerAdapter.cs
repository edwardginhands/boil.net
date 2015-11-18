using System;
using System.Threading;


namespace Boiler
{
    public class TimerAdapter: ITimerAdapter
    {
        private Timer _timer;
        private TimerCallback _callback;
        private int _dueTime;
        private int _period;

        public TimerAdapter(int dueTime, int period)
        {
            
            _dueTime = dueTime;
            _period = period;
        }

        public void Initialize(TimerCallback callback)
        {
            _callback = callback;
              _timer = new Timer(_callback, this, _dueTime, _period);
           // _timer = new Timer(_callback);


        }
    }
}
