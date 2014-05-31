using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using xjmg.Models;

namespace xjmg.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        //会员注册页面
        public ActionResult Register()
        {
            return View();
        }

        //写入会员信息
        [HttpPost]
        public ActionResult Register([Bind(Exclude="RegisterOn,AuthCode")] Member member)
        {
            return View();
        }

        //显示会员登陆界面
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        //运行会员登录
        [HttpPost]
        public ActionResult Login(string email, string password, string returnUrl)
        {
            if(ValidateUser(email,password))
            {
                FormsAuthentication.SetAuthCookie(email,false);

                if(String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            ModelState.AddModelError("", "您输入的账号或密码错误");
            return View();
        }

        private bool ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        //运行会员注销
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
