using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTicket.Areas.Admin.Controllers
{
     [Authorize(Roles = "Admin")]
    [HandleError(View = "~/Views/Shared/Error.cshtml")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult ChangePassword()
        {

            return PartialView("/Views/Shared/ChangePassword.cshtml");
        }

    }
}