using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourManagement.Core.Repository;

namespace TourManagement.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITourRepository _tourRepository;
        public HomeController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }
        public ActionResult Index()
        {
            var tours = _tourRepository.GetAll();
            return View(tours);
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