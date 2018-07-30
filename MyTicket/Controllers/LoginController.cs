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
                AuthorizeAttribute a = new AuthorizeAttribute();
                a.Roles = "Admin";
                Session["userid"] = userid;
               return Redirect(utype);
             
            }
            return View();

           
        }

        /*
        [HandleError()]
        public ActionResult Geterror()
        {
            throw new Exception("test");
        }

    
        public ActionResult GetNewerror()
        {
            try
            {
                throw new Exception("test");
            }
            catch(Exception ex)
            {
                return View("~/Views/shared/error.cshtml");
            }
        }
*/
        public ActionResult Error()
        {
            return View("error");
        }
    }
}