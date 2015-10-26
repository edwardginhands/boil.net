using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Boiler
{
    public class Boiler
    {
        public bool IsElementOn { get; set; }
        public bool IsPumpOn { get; set; }
        public decimal TargetTemp { get; set; }
        public decimal TempOffset { get; set; }
    }
}