using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Boiler
{
    public class BoilerStatus : IBoiler
    {
        [Key]
        public int Id { get; set; }
        public DateTime LoggedDate { get; set; }
        public DateTime LastOn { get; set; }
        public DateTime LastOff { get; set; }
        private IBoiler _boiler;

        public BoilerStatus(IBoiler boiler)
        {
            _boiler = boiler;

        }

        public decimal ActualTemp
        {
            get
            {
                return _boiler.ActualTemp;
            }

            set
            {
                _boiler.ActualTemp = ActualTemp;
            }
        }



        public bool IsElementOn
        {
            get
            {
                return _boiler.IsElementOn;
            }

            set
            {
                _boiler.IsElementOn = IsElementOn;
            }
        }

        public bool IsPumpOn
        {
            get
            {
                return _boiler.IsPumpOn;
            }

            set
            {
                _boiler.IsPumpOn = IsPumpOn;
            }
        }

        public bool IsAuto
        {
            get
            {
                return _boiler.IsAuto;
            }

            set
            {
                _boiler.IsAuto = IsAuto;
            }
        }



        public decimal TargetTemp
        {
            get
            {
                return _boiler.TargetTemp;
            }

            set
            {
                _boiler.TargetTemp = TargetTemp;
            }
        }

        public decimal TempOffset
        {
            get
            {
                return _boiler.TempOffset;
            }

            set
            {
                _boiler.TempOffset = TempOffset;
            }
        }
    }
}
