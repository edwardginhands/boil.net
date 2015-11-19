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
                var b = db.Set<BoilerStatus>().OrderByDescending(t => t.Id).FirstOrDefault();
                return b == null ? new BoilerStatus() : b;
            }

        }

        public IBoilerStatus Save(IBoilerStatus boiler)
        {

            using (var db = new BoilerDbContext())
            {
                var b = db.Set<BoilerStatus>().OrderByDescending(t => t.Id).Select(i => i.Id).FirstOrDefault();

                db.Boiler.RemoveRange(db.Boiler.Where(w => w.Id < b - 1000000));

                db.Boiler.Add((BoilerStatus)boiler);

                db.SaveChanges();
            }

            return boiler;
        }
    }
}
