using MNB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MNB.Database
{
    public class StockDataContext: DbContext
    {
        public DbSet<MachinePart> SpareParts { get; set; }

        public StockDataContext(): base("DefaultConnection")
        {
            //System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<StockDataContext>());
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StockDataContext>());
        }
    }
}