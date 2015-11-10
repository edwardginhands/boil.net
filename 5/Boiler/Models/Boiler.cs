
namespace Boiler
{
    public class Boiler : IBoiler
    {
        public bool IsElementOn { get; set; }
        public bool IsPumpOn { get; set; }
        public bool IsAuto { get; set; }
        public decimal TargetTemp { get; set; }
        public decimal TempOffset { get; set; }
        public decimal ActualTemp { get; set; }

        
        public Boiler()
        {
            IsElementOn = false;
            IsPumpOn = false;
            TargetTemp = 0;
            TempOffset = 0;
            ActualTemp = 0;
        }
        

        public Boiler(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp)
        {
            this.IsElementOn = IsElementOn;
            this.IsPumpOn = IsPumpOn;
            this.IsAuto = IsAuto;
            this.TargetTemp = TargetTemp;
            this.TempOffset = TempOffset;
            this.ActualTemp = ActualTemp;
        }
    }
}