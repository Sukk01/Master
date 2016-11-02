using MNB.Models;
using MNB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNB.Database
{
    public interface IDatahandler
    {
        void CreatePart(MachinePart m);
        MachinePart GetPart(int Id);
        IEnumerable<MachinePart> GetParts();
        void ModifyPart(MachinePart m);
        void DeletePart(int Id);

        void Add(int Id);
        void Withdraw(int Id);

        StatisticsViewModel GetStatistics();
    }
}