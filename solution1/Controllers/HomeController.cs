using database.Database;
using solution1.Models.Business.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace solution1.Controllers
{
    public partial class HomeController : BaseController
    {
        public HomeBC bc = new HomeBC();
        public ActionResult getDataGoods()
        {
            var goods = bc.getUser();

            return Json(new { data = goods });
        }
        public ActionResult getEditGoods()
        {
            var goods = bc.getUser();

            return Json(new { data = goods });
        }

        [HttpPost]
        public ActionResult bindSave(smGood model)
        {

            var goods = bc.bindSave(model);
            
            return Json(new { data = goods });
        }
        [HttpPost]
        public ActionResult bindEdit(smGood model)
        {
            var goods = bc.bindEdit(model);

            return Json(new { data = goods });
        }
        [HttpPost]
        public ActionResult bindDelete(string goodsID)
        {
           
            var goods = bc.bindDelete(goodsID);
            return Json(new { data = goods });
        }
    }
}