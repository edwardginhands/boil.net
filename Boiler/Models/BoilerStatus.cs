using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity.Metadata;



namespace Boiler
{
    public class BoilerStatus : Boiler, IBoilerStatus
    {
        [Key]
        public int Id { get; set; }
        public DateTime LoggedDate { get; set; }
 

        public BoilerStatus()
        {

        }


        public BoilerStatus(IBoiler boiler)
        {
            IsElementOn= boiler.IsElementOn;
            IsPumpOn = boiler.IsPumpOn;
            IsBurstOn = boiler.IsBurstOn;
            IsAuto = boiler.IsAuto;
            TargetTemp = boiler.TargetTemp;
            TempOffset = boiler.TempOffset;
            ActualTemp = boiler.ActualTemp;

            BurstTime = boiler.BurstTime;
            BurstInterval = boiler.BurstInterval;
        }


        public IBoiler ToBoiler()
        {
            Boiler b = new Boiler
            {
                IsElementOn = IsElementOn,
                IsPumpOn = IsPumpOn,
                IsBurstOn = IsBurstOn,
                IsAuto = IsAuto,
                TargetTemp = TargetTemp,
                TempOffset = TempOffset,
                ActualTemp = ActualTemp,
                BurstTime = BurstTime,
                BurstInterval = BurstInterval
            };

            return b;
        }
    }
}
