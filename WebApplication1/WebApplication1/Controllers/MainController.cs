using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Home()
        {
            Member user = Session[Dictionary.SK_LOGINUSER] as Member;
            if (user == null)
                return RedirectToAction("Login");
            ViewBag.LOGIN_USER = user.MemberName;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MemberLogin vModel)
        {
            Member user = new MemberFactory().queryByEmail(vModel.txtAccount);
            if (user != null)
            {
                if (user.MemberPWD.Equals(vModel.txtPWD))
                {
                    Session[Dictionary.SK_LOGINUSER] = user;
                    return RedirectToAction("Home");
                }
            }
            return View();
        }
    }
}