using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace xjmg.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //商品列表
        public ActionResult ProductList(int id)
        {
            return View();
        }

        //商品明细
        public ActionResult ProductDatail(int id)
        {
            return View();
        }
    }
}
