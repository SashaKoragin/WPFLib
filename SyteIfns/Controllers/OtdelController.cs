using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyteIfns.Controllers
{
    public class OtdelController : Controller
    {
        // GET: Otdel
        public ActionResult MergeFace()
        {
            ViewBag.Message = "Модуль предназначен для слияния лиц!!!";
            //return View(new ReaderAnsvwer());
            return View("Analitics/MergeFace");
        }
        public ActionResult Reshenie()
        {
            ViewBag.Message = "Модуль для Решений!!!";
            return View("Yregulirovanie/Reshenie");
        }
    }
}