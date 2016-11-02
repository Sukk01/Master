using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNB.Models
{
    public class StockModel
    {
        public int Id { get; set; }
        public MachinePart MachinePart { get; set; }
        

        public StockModel()
        { }

        public StockModel(MachinePart m)
        {
            MachinePart = m;
        }
    }
}