using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace xjmg.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        //添加产品项目到购物车，如果没有传入Amount参数则默认购买数量为1
        [HttpPost]
        //因为知道要通过Ajax调用这个Action，所以可以先标识[HttpPost]属性
        public ActionResult AddToCart(int ProductId, int Amount = 1)
        {
            return View();
        }

        //显示当前的购物车项目
        public ActionResult Index()
        {
            return View();
        }

        //移除购物车项目
        [HttpPost]
        public ActionResult Remove(int ProfuctId)
        {
            return View();
        }

        //更新购物车中特定项目的购买数量
        [HttpPost]
        public ActionResult UpdateAmount(int ProductId, int NewAmount)
        {
            return View();
        }

    }
}
