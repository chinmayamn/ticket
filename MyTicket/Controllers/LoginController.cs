using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTicket.Models;
using System.ComponentModel.DataAnnotations;

namespace MyTicket.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Users u = new Users();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Index([Bind(Include = "Username,Password", Exclude ="Level")] Users user)
        {

            if (ModelState.IsValid)
            {
                 string userid = "";
                string utype = u.ReturnUser(user,ref userid);
                Session["userid"] = userid;
               return Redirect(utype);
             
            }
            return View();

           
        }

    }
}