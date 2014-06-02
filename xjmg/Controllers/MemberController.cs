using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using xjmg.Models;

namespace xjmg.Controllers
{
    public class MemberController : BaseController
    {
        //
        // GET: /Member/

        //会员注册页面
        public ActionResult Register()
        {
            return View();
        }

        private string pwSalt = "xzjsxzjsxzjsxzjsxzjsxzjsxzjsxzjsxzjs";

        //写入会员信息
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn,AuthCode")] Member member)
        {
            //检测会员是否存在
            var chk_member = db.Members.Where(p => p.Email == member.Email).FirstOrDefault();
            if (chk_member != null)
            {
                ModelState.AddModelError("Email", "您输入的EMail已经有人注册过了");
            }
            if (ModelState.IsValid)
            {
                //将密码加盐进行哈希运算
                member.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + member.Password, "SHA1");
                //会员注册时间
                member.RegisterOn = DateTime.Now;
                //会员验证码，采用Guid当成验证码属性，避免会员使用到重复验证码
                member.AuthCode = Guid.NewGuid().ToString();

                db.Members.Add(member);
                db.SaveChanges();

                //SendAuthCodeToMember(member);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        private void SendAuthCodeToMember(Member member)
        {
            string mailBody = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/MemberRegisterEmailTemplate.htm"));

            mailBody = mailBody.Replace("{{Name}}", member.Name);
            mailBody = mailBody.Replace("{{RegisterOn}}", member.RegisterOn.ToString("F"));
            var auth_url = new UriBuilder(Request.Url)
            {
                Path = Url.Action("ValidateRegister", new { id = member.AuthCode }),
                Query = ""
            };
            mailBody=mailBody.Replace("{{AUTH_URL}}",auth_url.ToString());
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
            if (ValidateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
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
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + password, "SHA1");
            var member = (from p in db.Members
                          where p.Email == email && p.Password == hash_pw
                          select p).FirstOrDefault();
            //如果member对象不为null则代表会员的账号、密码输入正确
            return (member != null);
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
