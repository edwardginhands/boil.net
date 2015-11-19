using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Boiler
{
    public interface IBoilerStatus : IBoiler
    {
        [Key]
         int Id { get; set; }
         DateTime LoggedDate { get; set; }

        IBoiler ToBoiler();

    }
}
