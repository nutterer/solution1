using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace solution1.Controllers
{
    public partial class HomeController : BaseController
    {
        [SetDefaultContent]
        public ActionResult List()
        {
            var goodsID = "";
            ViewBag.goods = bc.getUser(goodsID);

            

            return View();
        }

        [SetDefaultContent]
        public ActionResult Edit(String id)
        {
            ViewBag.goods = bc.getUser(id).FirstOrDefault();

            return View();
        }

        [SetDefaultContent]
        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [SetDefaultContent]
        public ActionResult Detail(string id)
        {
            ViewBag.goods = bc.getUser(id).FirstOrDefault();
            return View();
        }

        [SetDefaultContent]
        public ActionResult Login(string id)
        {
            ViewBag.goods = bc.getUser(id).FirstOrDefault();
            return View();
        }
    }
}