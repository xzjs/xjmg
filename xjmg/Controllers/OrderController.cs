﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace xjmg.Controllers
{
    [Authorize]//必须登录会员才可以使用订单结账功能
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        //显示完成订单的窗体页面
        public ActionResult Complete()
        {
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
