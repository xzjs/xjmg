using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xjmg.Models;

namespace xjmg.Controllers
{
    [Authorize]//必须登录会员才可以使用订单结账功能
    public class OrderController : BaseController
    {
        //
        // GET: /Order/

        //显示完成订单的窗体页面
        public ActionResult Complete(OrderHeader form)
        {
            var member = db.Members.Where(p => p.Email == User.Identity.Name).FirstOrDefault();
            if (member == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (this.Carts.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }
            //将订单信息与购物车信息写入数据库
            OrderHeader oh = new OrderHeader()
            {
                Member = member,
                ContantName = form.ContantName,
                ContantAddress = form.ContantAddress,
                ContactPhoneNo = form.ContactPhoneNo,
                BuyOn = DateTime.Now,
                Memo = form.Memo,
                OrderDetailItems = new List<OrderDetail>()
            };
            double total_price = 0;
            foreach (var item in this.Carts)
            {
                var product = db.Products.Find(item.Product.Id);
                if (product == null)
                {
                    return RedirectToAction("Index", "Cart");
                }
                total_price += item.Product.Price * item.Amount;
                oh.OrderDetailItems.Add(new OrderDetail()
                {
                    Product = product,
                    Price = product.Price,
                    Amount = item.Amount
                });
                oh.TotalPrice = total_price;

                db.Orders.Add(oh);
                db.SaveChanges();

                //订单完成后必须清空现有购物车信息
                this.Carts.Clear();

                //订单完成后回到网站首页
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //将订单信息与购物车信息写入数据库
        [HttpPost]
        public ActionResult Complete(FormCollection form)
        {
            //TODO:将订单信息与购物车信息写入数据库

            //TODO: 订单完成后必须清空现有购物车信息

            //订单完成后返回到网站首页
            return RedirectToAction("Index", "Home");
        }

    }
}
