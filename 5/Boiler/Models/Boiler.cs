
using System;

namespace Boiler
{
    public class Boiler : IBoiler
    {
        private bool _isElementOn;
        public bool IsElementOn
        {
            get { return _isElementOn; }
            set
            {
                //if (_isElementOn != value)
                //{
                //    switch (value)
                //    {
                //        case true:
                //            _lastOn = DateTime.Now;
                //            break;
                //        case false:
                //            _lastOff = DateTime.Now;
                //            break;
                //    }
                //}

                _isElementOn = value;
            }
        }
        public bool IsPumpOn { get; set; }
        public bool IsBurstOn { get; set; }
        public bool IsAuto { get; set; }
        public decimal TargetTemp { get; set; }
        public decimal TempOffset { get; set; }
        public decimal ActualTemp { get; set; }
        public int BurstTime { get; set; }
        public int BurstInterval { get; set; }

        public DateTime LastOn { get { return _lastOn; } }
        public DateTime LastOff {get { return _lastOff; } }

        private DateTime _lastOn;
        private DateTime _lastOff;

        public Boiler()
        {
            _isElementOn = false;
            IsBurstOn = false;
            IsPumpOn = false;
            IsAuto = false;
            TargetTemp = 0;
            TempOffset = 0;
            ActualTemp = 0;
            _lastOn = DateTime.Now;
            _lastOff = DateTime.Now;
        }
        

        public Boiler(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp)
        {
            _isElementOn = IsElementOn;
            this.IsPumpOn = IsPumpOn;
            this.IsBurstOn = IsBurstOn;
            this.IsAuto = IsAuto;
            this.TargetTemp = TargetTemp;
            this.TempOffset = TempOffset;
            this.ActualTemp = ActualTemp;
            _lastOn = DateTime.Now;
            _lastOff = DateTime.Now;
        }


        public bool DisableOnHighTemp()
        {
            if (ActualTemp >= TargetTemp && IsElementOn == true && IsAuto == true)
            {
                IsElementOn = false;
                return true;
            }
            return false;

        }

        public bool EnableOnLowTemp(DateTime DueDate)
        {
            if ((DueDate - _lastOff).TotalSeconds >= 10 && ActualTemp < TargetTemp && IsAuto == true)
            {
                if (IsElementOn == false) _lastOn = DueDate;
                IsElementOn = true;
                return true;
            }
            return false;
        }


        public bool BurstCycleOff(DateTime DueDate)
        {


            DateTime timeToTurnOff = _lastOn.AddSeconds(BurstTime);
            if (timeToTurnOff < DueDate)
            {
                if (IsElementOn == true)
                {
                    _lastOff = DateTime.Now;
                }
                IsElementOn = false;
                return true;
            }
            IsElementOn = true;
            return false;

        }

        public bool BurstCycleOn(DateTime DueDate)
        {

            DateTime timeToTurnOn = _lastOff.AddSeconds(BurstInterval);
            if (timeToTurnOn < DueDate)
            {
                if (IsElementOn == false)
                {
                    _lastOn = DateTime.Now;
                }
                IsElementOn = true;
                return true;
            }
            IsElementOn = false;
            return false;
        }
    }
}