using MNB.Models;
using MNB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNB.Database
{
    public class DatabaseDatahandler : IDatahandler
    {
        private StockDataContext context;

        public DatabaseDatahandler()
        {
            context = new StockDataContext();
        }


        public void CreatePart(MachinePart m)
        {
            try
            {
                context.SpareParts.Add(m);
                context.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        public MachinePart GetPart(int Id)
        {
            var r = context.SpareParts.FirstOrDefault(e => e.Id == Id);
            return r;
        }

        public IEnumerable<MachinePart> GetParts()
        {
            return context.SpareParts;
        }

        public void ModifyPart(MachinePart m)
        {
            MachinePart found = context.SpareParts.FirstOrDefault(e => e.Id == m.Id);
            if (found != null)
            {
                found.Name = m.Name;
                found.Price = m.Price;
                found.Summary = m.Summary;
                found.Weight = m.Weight;
                context.SaveChanges();
            }
        }

        public void DeletePart(int Id)
        {
            MachinePart found = context.SpareParts.FirstOrDefault(e => e.Id == Id);
            if (found != null)
            {
                context.SpareParts.Remove(found);
                context.SaveChanges();
            }
        }

        public StatisticsViewModel GetStatistics()
        {
            //TO DO: getting the number of each items available and then multiplying 
            //the result of the aggregate functions could fasten the db a bit
            if (context.SpareParts.Any())
            {
                double fullWeight = context.SpareParts.Sum(e => e.Weight * (e.Added - e.Withdrawn));
                double fullValue = context.SpareParts.Sum(e => e.Price * (e.Added - e.Withdrawn));
                string mostCountName = "";
                double mostC = context.SpareParts.Max(e => (e.Added - e.Withdrawn));
                MachinePart mostCountPart = context.SpareParts.FirstOrDefault(r => (r.Added - r.Withdrawn) == mostC);
                if (mostCountPart != null)
                {
                    mostCountName = mostCountPart.Name;
                }

                string mostWeightName = "";
                double mostW = context.SpareParts.Max(e => (e.Added - e.Withdrawn) * e.Weight);
                MachinePart mostWeightPart = context.SpareParts.FirstOrDefault(r => (r.Added - r.Withdrawn) * r.Weight == mostW);
                if (mostWeightPart != null)
                {
                    mostWeightName = mostWeightPart.Name;
                }

                return new StatisticsViewModel(fullWeight, fullValue, mostCountName, mostWeightName);
            }

            return new StatisticsViewModel(0, 0, "None", "None");
        }

        private MachinePart GetbyId(int id)
        {
            return context.SpareParts.FirstOrDefault(m => m.Id == id);
        }


        public void Add(int id)
        {
            MachinePart m = GetbyId(id);
            if (m != null)
            {
                m.Added++;
                context.SaveChanges();
            }
        }

        public void Withdraw(int id)
        {
            MachinePart m = GetbyId(id);
            if (m != null)
            {
                m.Withdrawn++;
                context.SaveChanges();
            }
        }
    }
}