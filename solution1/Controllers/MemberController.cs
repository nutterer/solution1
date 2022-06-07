using database.Database;
using solution1.Models.Business.Home;
using solution1.Models.Business.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace solution1.Controllers
{
    public partial class MemberController : BaseController
    {
        // GET: Member
        
        public MemberBC mb = new MemberBC();
        
        public ActionResult Login()
        {
            if (UserStatus != null)
            {
                return Redirect("~/Home/List");
            }

            return View();
        }
        [SetDefaultContent]
        public ActionResult AdminList()

        {
            var UserID = "";
            ViewBag.user = mb.getUsers(UserID);
            if (!UserStatus.IsAdmin)
            {
                return Redirect("~/Home/List");
            }
            return View();
        }
        [SetDefaultContent]
        public ActionResult AdminEdit(string id)
        {
            ViewBag.user = mb.getUsers(id).FirstOrDefault();
            return View();
        }
        [SetDefaultContent]
        public ActionResult AdminCreate()
        {
            var UserID = "";
            ViewBag.user = mb.getUsers(UserID);
            if (!UserStatus.IsAdmin)
            {
                return Redirect("~/Home/List");
            }
            return View();
        }
       
        
    }
}