using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNB.ViewModels
{
    public class StatisticsViewModel
    {
        public double FullWeight { get; set; }
        public double FullValue { get; set; }
        public string MostCount { get; set; }
        public string MostWeight { get; set; }

        public StatisticsViewModel(double fw, double fv, string mc, string mw)
        {
            FullWeight = fw;
            FullValue = fv;
            MostCount = mc;
            MostWeight = mw;
        }
    }
}