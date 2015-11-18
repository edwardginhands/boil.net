using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Boiler
{
    public interface IBoilerStatus
    {
        /*
        [Key]
        int Id { get; set; }
        DateTime LoggedDate { get; set; }
        DateTime LastOn { get; set; }
        DateTime LastOff { get; set; }
        IBoiler ToBoiler();
        string IsElementOn { get; set; }
        string IsPumpOn { get; set; }
        string IsAuto { get; set; }
        string IsBurstOn { get; set; }
        string TargetTemp { get; set; }
        string TempOffset { get; set; }
        string ActualTemp { get; set; }
        */

        [Key]
         int Id { get; set; }
         DateTime LoggedDate { get; set; }
         DateTime LastOn { get; set; }
         DateTime LastOff { get; set; }
         bool IsElementOn { get; set; }
         bool IsPumpOn { get; set; }
         bool IsBurstOn { get; set; }
         bool IsAuto { get; set; }
         decimal TargetTemp { get; set; }
         decimal TempOffset { get; set; }
         decimal ActualTemp { get; set; }

        IBoiler ToBoiler();

    }
}
