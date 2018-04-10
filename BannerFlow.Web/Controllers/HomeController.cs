using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BannerFlow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                ViewBag.BannerId = id;
            }
            else
                ViewBag.Error = "Banner Id required";
            return View();
        }

        public ActionResult ShowBanner(int id)
        {
            if (id > 0)
            {
                ViewBag.BannerId = id;
            }
            else
                ViewBag.Error = "Banner Id required";
            return View();
        }
    }
}
