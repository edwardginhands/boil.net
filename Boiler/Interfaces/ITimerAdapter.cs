using System.Threading;
namespace Boiler
{
    public interface ITimerAdapter
    {
        void Initialize(TimerCallback callback);
    }
}
