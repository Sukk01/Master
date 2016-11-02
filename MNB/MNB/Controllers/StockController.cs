using MNB.Database;
using MNB.Models;
using MNB.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
namespace MNB.Controllers
{
    public class StockController : Controller
    {
        private IDatahandler DataHandler { get; set; }

        public StockController(IDatahandler handler)
        {
            DataHandler = handler;
        }

        [HttpGet]
        public ActionResult GetAllParts()
        {
            var parts = DataHandler.GetParts();
            JsonResult r = Json(parts);
            r.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return r;
        }

        [HttpPost]
        public void CreatePart(MachinePart m)
        {
            DataHandler.CreatePart(m);
        }

        public void Add(int Id)
        {
            DataHandler.Add(Id);
        }

        public void Withdraw(int Id)
        {
            DataHandler.Withdraw(Id);
        }

        public void Edit(MachinePart part)
        {
            DataHandler.ModifyPart(part);
        }

        public void Delete(int Id)
        {
            DataHandler.DeletePart(Id);
        }

        public JsonResult Statistics()
        {
            JsonResult r = Json(DataHandler.GetStatistics());
            r.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return r;
        }
    }
}
