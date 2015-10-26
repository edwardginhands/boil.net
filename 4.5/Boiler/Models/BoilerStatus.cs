using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Boiler
{
    public class BoilerStatus
    {
        public bool IsElementOn { get; set; }
        public bool IsPumpOn { get; set; }
        public decimal Temp { get; set; }


    }
}