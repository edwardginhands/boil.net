using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;

namespace Boiler
{
    public class BoilerDbContext : DbContext
    {
        public DbSet<BoilerStatus> Boiler { get; set; }



        // This method connects the context with the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "boiler.sqlite" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }



    }
}
