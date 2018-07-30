using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTicket.Areas.Director.Controllers
{
  // [Authorize(Roles = "Director")]
    public class DirectorController : Controller
    {
        // GET: Director/Director
        public ActionResult Index()
        {
            return View();
        }
    }
}