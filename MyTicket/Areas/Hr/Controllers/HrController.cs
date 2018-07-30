using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTicket.Areas.Hr.Controllers
{
   // [Authorize(Roles ="H.R")]
    public class HrController : Controller
    {
        // GET: Hr/Hr
        public ActionResult Index()
        {
            return View();
        }
    }
}