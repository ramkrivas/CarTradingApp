using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Demo.CarTrade.Entity;

namespace Demo.CarTrade.Repository
{
    public class CarTradeContext: DbContext
    {
        public CarTradeContext() : base("name=dbConnectionString")
        {
            Database.SetInitializer<CarTradeContext>(new CreateDatabaseIfNotExists<CarTradeContext>());
        }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
    }
}
