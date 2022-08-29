using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult List()
        {
            string keyword = Request.Form["txtKeyword"];
            //菜鳥寫的
            List<Member> datas = null;
            if (string.IsNullOrEmpty(keyword))
                datas = new MemberFactory().queryAll();
            else
                datas = new MemberFactory().queryByKeyword(keyword);
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
            Member c = new MemberFactory().queryById((int)id);

            if (c == null)
                return RedirectToAction("List");
            return View(c);
        }
        //網址重複模擬兩可
        //submit透過action 將post動作傳遞出去
        [HttpPost]
        public ActionResult Edit(Member member)
        {
            new MemberFactory().update(member);
            return RedirectToAction("List");//重新導向
        }

        public ActionResult Save()
        {
            Member member = new Member();
            member.MemberName = Request.Form["txtName"];
            member.MemberPhone = Request.Form["txtPhone"];
            member.MemberEmail = Request.Form["txtEmail"];
            new MemberFactory().create(member);
            return RedirectToAction("List");//List為 list.cshtml的title
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
                new MemberFactory().delete((int)id);
            return RedirectToAction("List");
        }
    }
}