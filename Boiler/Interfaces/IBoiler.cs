using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boiler
{
 
    public interface IBoiler
    {
        bool IsElementOn { get; set; }
        bool IsPumpOn { get; set; }
        bool IsAuto { get; set; }
        bool IsBurstOn { get; set; }
        decimal TargetTemp { get; set; }
        decimal TempOffset { get; set; }
        decimal ActualTemp { get; set; }
        int BurstTime { get; set; }
        int BurstInterval { get; set; }
        DateTime LastOn { get; }
        DateTime LastOff { get; }

        bool DisableOnHighTemp();
        bool EnableOnLowTemp(DateTime DueDate);
        bool BurstCycleOff(DateTime DueDate);
        bool BurstCycleOn(DateTime DueDate);
    }

}
