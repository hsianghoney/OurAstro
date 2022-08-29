using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProController : Controller
    {
        // GET: Pro
        public ActionResult List()
        {
            string keyword = Request.Form["txtKeyword"];
            //菜鳥寫的
            List<Pro> datas = null;
            if (string.IsNullOrEmpty(keyword))
                datas = new ProFactory().queryAll();
            else
                datas = new ProFactory().queryByKeyword(keyword);
            return View(datas);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            //edit把想修改的資料讀取出來 (顯示資料畫面 為筆記上的edit())
            if (id == null)
                return RedirectToAction("List");
            Pro c = new ProFactory().queryById((int)id);

            if (c == null)
                return RedirectToAction("List");
            return View(c);
        }
        //網址重複模擬兩可
        //submit透過action 將post動作傳遞出去
        [HttpPost]
        public ActionResult Edit(Pro pro)
        {
            new ProFactory().update(pro);
            return RedirectToAction("List");//重新導向
        }

        public ActionResult Save()
        {
            Pro pro = new Pro();
            pro.ProName = Request.Form["txtName"];
            pro.ProPhone = Request.Form["txtPhone"];
            pro.ProEmail = Request.Form["txtEmail"];
            new ProFactory().create(pro);
            return RedirectToAction("List");//List為 list.cshtml的title
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
                new ProFactory().delete((int)id);
            return RedirectToAction("List");
        }
    }
}