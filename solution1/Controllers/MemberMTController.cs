using database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace solution1.Controllers
{
    public partial class MemberController : BaseController
    {
        // GET: MemberMT
        [HttpPost]
        public ActionResult bindEdit(smUser model)
        {
            var User = mb.bindEdit(model);
            return Json(new { data = User});
        }
        [HttpPost]
        public ActionResult bindSave(smUser model)
        {

            var User = mb.bindSave(model);

            return Json(new { data = User });
        }
        [HttpPost]
        public ActionResult bindDelete(string UserID)
        {

            var User = mb.bindDelete(UserID);
            return Json(new { data = User });
        }
        public ActionResult bindlogin( string UserName, string Password, bool IsRemember)
        {
            mb.isResult = false;
            try
            {
                var user = mb.bindlogin(UserName, Password);
                if (user != null)
                {
                    AddCookiesAuth(user, IsRemember);
                    mb.isResult = true;
                    
                }
                return Json(new { isResult = mb.isResult });
              

            }
            catch (Exception) { 
                return Json(new { isResult = mb.isResult }); 
            }
        }
        public ActionResult bindlogout(bool IsReMember = false)
        {
            
            if (IsReMember)
            {
                
                return Redirect("~/Member/Login");
            }else
            {
                RemoveCookiesAuth();
            }
            
            return Redirect("~/Member/Login");
        }
    }
}