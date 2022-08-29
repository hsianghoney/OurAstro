using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ReserveController : Controller
    {
        // GET: Reserve
        public ActionResult CartView()
        {
            List<Reserve> cart = Session[Dictionary.SK_PRODUCTS_PURCHASED_LIST] as List<Reserve>;
            if (cart == null)
                return RedirectToAction("List");
            return View(cart);
        }

        public ActionResult List()
        {
            OurAstroEntities db = new OurAstroEntities();
            var table = from t in db.ProForm
                        select t;
            return View(table);
        }

        public ActionResult AddToCart(int? id)
        {
            Pro pro = new OurAstroEntities().ProSkillList.FirstOrDefault(p => p.ProID == id);
            if (pro == null)
                return RedirectToAction("List");
            return View(pro);
        }

        [HttpPost]
        public ActionResult AddToCart(ReserveView vModel)
        {
            OurAstroEntities db = new OurAstroEntities();
            Pro pro = db.ProSkillList.FirstOrDefault(p => p.ProID == vModel.rID);
            if (pro == null)
                return RedirectToAction("List");
            ReserveView item = new ReserveView();
            Member mem = new Member();
            item.ProID = vModel.ProID;
            item.MemberID = vModel.MemberID;
            item.ReserveDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            item.ProCost = pro.ProCost;
            db.ReserveForm.Add(item);
            db.SaveChanges();
            return View(pro);
        }

        public ActionResult AddToSession(int? id)
        {
            Pro pro = new OurAstroEntities().ProForm.FirstOrDefault(p => p.ProID == id);
            if (pro == null)
                return RedirectToAction("List");
            return View(pro);
        }

        [HttpPost]
        public ActionResult AddToSession(ReserveView vModel)
        {
            OurAstroEntities db = new OurAstroEntities();
            Pro pro = db.ProSkillList.FirstOrDefault(p => p.ProID == vModel.ProID);
            if (pro == null)
                return RedirectToAction("List");

            List<Reserve> cart = Session[Dictionary.SK_PRODUCTS_PURCHASED_LIST] as List<Reserve>;
            if (cart == null)
            {
                cart = new List<Reserve>();
                Session[Dictionary.SK_PRODUCTS_PURCHASED_LIST] = cart;
            }
            Reserve x = new Reserve();
            x.MemberID = vModel.MemberID;
            x.ProCost = (int)pro.ProCost;
            x.ProID = vModel.ProID;
            x.ProName = vModel.ProName;
            x.ProSkill = vModel.ProSkill;
            x.ProAddress = vModel.ProAddress;
            x.ReserveDate = vModel.ReserveDate;
            cart.Add(x);
            return RedirectToAction("List");
        }
    }
}