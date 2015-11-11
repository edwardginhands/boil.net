using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boiler
{
    public class BoilerLogger : IBoilerLogger
    {

        public BoilerLogger()
        {
        }

        public void LogBoilerStatus(BoilerStatus item)
        {
            using (var db = new BoilerDbContext())
            {

                db.Boiler.Add(item);
                db.SaveChanges();
            }
        }
    }
}
