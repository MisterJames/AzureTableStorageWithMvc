using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureTableStorageWithMvc.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureTableStorageWithMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITableStorageRepository<KittehEntity> _kittehRepository;

        public HomeController(ITableStorageRepository<KittehEntity> kittehRepository)
        {
            _kittehRepository = kittehRepository;
        }

        public ActionResult Index()
        {
            var kittehs = _kittehRepository.GetByPartition("FunnyKittehs");
            return View(kittehs);
        }

        [HttpPost]
        public ActionResult Index(KittehEntity entity)
        {
            _kittehRepository.Insert(entity);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}