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
        decimal TargetTemp { get; set; }
        decimal TempOffset { get; set; }
        decimal ActualTemp { get; set; }
    }
}
