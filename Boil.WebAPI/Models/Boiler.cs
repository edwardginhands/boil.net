using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Boil.Interfaces;
using Boil.Repositories;

namespace Boil.WebAPI.Models
{
    public class Boiler
    {
        public bool IsElementOn { get; set; }
        public bool IsPumpOn { get; set; }
        public bool IsBurstOn { get; set; }
        public int BurstTime { get; set; }
        public int BurstInterval { get; set; }
        public decimal TargetTemp { get; set; }
        public decimal TempOffset { get; set; }
    }
}