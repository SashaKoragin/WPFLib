using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyteIfns.Models.PostRestAplication.ModelFaceError;

namespace SyteIfns.Controllers
{
    public class MerginController : Controller
    {
        // GET: Mergin
        public ActionResult FaceMergin()
        {
            ViewBag.Message = "Отчеты по слиянию лиц!!!";
            return View(new ReaderAnsvwer());
        }

        public ActionResult AddFace(int? nold, int? nnew)
        {
            var model = new ReaderAnsvwer();
                model.AddFaces(nold, nnew);
           return View("FaceMergin",model);
        }
    }
}