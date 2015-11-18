using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Boiler
{
    public class BoilerStatusRepository : IBoilerStatusRepository
    {

        public BoilerStatusRepository()
        {
        }

        public IBoilerStatus Retrieve()
        {
            using (var db = new BoilerDbContext())
            {
               // db.ChangeTracker.AutoDetectChangesEnabled = false;
                var b = db.Set<BoilerStatus>().OrderByDescending(t => t.Id).First();

                //var x = db.Set<BoilerStatus>().AsNoTracking().ToList();
                //var xx=db.Set<BoilerStatus>().Where(w => 1 == 1).AsNoTracking().ToList();
                // var b = db.Boiler.OrderByDescending(t => t.Id).First();
                //return b == null ? new BoilerStatus() : b;]
                // var a = db.Boiler.ToList();
                return b == null ? new BoilerStatus() : b;
            }

        }

        public IBoilerStatus Save(IBoilerStatus boiler)
        {

            using (var db = new BoilerDbContext())
            {
                db.Boiler.Add((BoilerStatus)boiler);
                db.SaveChanges();
            }

            return boiler;
        }
    }
}
