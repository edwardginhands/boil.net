using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Boiler
{
    public class BoilerStatus : IBoilerStatus
    {
        [Key]
        public int Id { get; set; }
        public DateTime LoggedDate { get; set; }
        public DateTime LastOn { get; set; }
        public DateTime LastOff { get; set; }
        //private IBoiler _boiler;
        public bool IsElementOn { get; set; }
        public bool IsPumpOn { get; set; }
        public bool IsBurstOn { get; set; }
        public bool IsAuto { get; set; }
        public decimal TargetTemp { get; set; }
        public decimal TempOffset { get; set; }
        public decimal ActualTemp { get; set; }


        
        public BoilerStatus(IBoiler boiler)
        {
            //_boiler = boiler;

            IsElementOn= boiler.IsElementOn;
            IsPumpOn = boiler.IsPumpOn;
            IsBurstOn = boiler.IsBurstOn;
            IsAuto = boiler.IsAuto;
            TargetTemp = boiler.TargetTemp;
            TempOffset = boiler.TempOffset;
            ActualTemp = boiler.ActualTemp;
        }

        public BoilerStatus()
        {
           // _boiler = new Boiler();
            //_boiler.ActualTemp = 999;
        }

        public IBoiler ToBoiler()
        {
            /*
            bool boilerIsElementOn = bool.Parse(IsElementOn);
             bool boilerIsPumpOn = bool.Parse(IsPumpOn);
            bool boilerIsBurstOn = bool.Parse(IsBurstOn);
            bool boilerIsAuto = bool.Parse(IsAuto);
            decimal boilerTargetTemp = decimal.Parse(TargetTemp);
             decimal boilerTempOffset = decimal.Parse(TempOffset);
            decimal boilerActualTemp = decimal.Parse(ActualTemp);

            Boiler b = new Boiler(boilerIsElementOn, boilerIsPumpOn, boilerIsBurstOn, boilerIsAuto, boilerTargetTemp, boilerTempOffset, boilerActualTemp);
            */
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);

            return b;

        }
        /*
        public string ActualTemp
        {
            get
            {
                return _boiler.ActualTemp.ToString();
            }

            set
            {
                _boiler.ActualTemp = decimal.Parse(ActualTemp);
            }
        }



        public string IsElementOn
        {
            get
            {
                return _boiler.IsElementOn.ToString();
            }

            set
            {
                _boiler.IsElementOn = bool.Parse(IsElementOn);
            }
        }

        public string IsPumpOn
        {
            get
            {
                return _boiler.IsPumpOn.ToString();
            }

            set
            {
                _boiler.IsPumpOn = bool.Parse(IsPumpOn);
            }
        }

        public string IsAuto
        {
            get
            {
                return _boiler.IsAuto.ToString();
            }

            set
            {
                _boiler.IsAuto = bool.Parse(IsAuto);
            }
        }

        public string IsBurstOn
        {
            get
            {
                return _boiler.IsBurstOn.ToString();
            }

            set
            {
                _boiler.IsBurstOn = bool.Parse(IsBurstOn);
            }
        }



        public string TargetTemp
        {
            get
            {
                return _boiler.TargetTemp.ToString();
            }

            set
            {
                _boiler.TargetTemp = decimal.Parse(TargetTemp);
            }
        }

        public string TempOffset
        {
            get
            {
                return _boiler.TempOffset.ToString();
            }

            set
            {
                _boiler.TempOffset = decimal.Parse(TempOffset);
            }
        }
        */
    }
}
