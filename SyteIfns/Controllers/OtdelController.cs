using System.Web.Mvc;
using SyteIfns.PostResponse.FileStream;

namespace SyteIfns.Controllers
{
    public class OtdelController : Controller
    {
        public ActionResult MergeFace()
        {
            ViewBag.Message = "Модуль предназначен для слияния лиц!!!";
            return View("Analitics/MergeFace");
        }
        public ActionResult Reshenie()
        {
            ViewBag.Message = "Модуль для Решений!!!";
            return View("Yregulirovanie/Reshenie");
        }

        public ActionResult Bdk()
        {
            ViewBag.Message = "Модуль для работы с Бдк!!!";
            return View("It/Bdk");
        }

        public ActionResult BdkLetter()
        {
            ViewBag.Message = "Модуль формирование писем Бдк!!!";
            return View("It/FormLetter");
        }

        public ActionResult AddTemplate()
        {
            ViewBag.Message = "Модуль создания шаблонов!!!";
            return View("It/AddTemplate");
        }

        public ActionResult PredproverkaSoprovod()
        {
            ViewBag.Message = "Модуль для предпроверки!!!";
            return View("Predproverka/PredproverkaSoprovod");
        }

        public ActionResult AnalizNo()
        {
            ViewBag.Message = "Модуль преднозначен для анализа КРСБ прием!!!";
            return View("Analitics/AnalizNo");
        }

        /// <summary>
        /// Загрузка файла Требований
        /// </summary>
        /// <returns></returns>
        public ActionResult DonloadTrebovanie()
        {
            DonloadFileReport donload = new DonloadFileReport();
            return File(donload.DonloadFile(PostResponse.FileStream.AddresFile.AdressFile.AdressTrebovanie), "application/xlsx", "Требования.xlsx");
        }
        /// <summary>
        /// Загрузка файла Бдк
        /// </summary>
        /// <returns></returns>
        public ActionResult DonloadBdk()
        {
            DonloadFileReport donload = new DonloadFileReport();
            return File(donload.DonloadFile(PostResponse.FileStream.AddresFile.AdressFile.AdressBdk), "application/xlsx", "Бдк.xlsx");
        }
        /// <summary>
        /// Загрузка файла Бдк
        /// </summary>
        /// <returns></returns>
        public ActionResult DonloadIstrebovanie()
        {
            DonloadFileReport donload = new DonloadFileReport();
            return File(donload.DonloadFile(PostResponse.FileStream.AddresFile.AdressFile.AdressIstrebovanie), "application/xlsx", "Истребование.xlsx");
        }
    }
}