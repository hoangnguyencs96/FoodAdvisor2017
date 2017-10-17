using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheOnlineShop.Areas.Admin.Models;
using Model.Dao;
using Model.EF;
using TheOnlineShop.Common;

namespace TheOnlineShop.Areas.Admin.Controllers
{
    public class SignInController : Controller
    {
        // GET: Admin/SignIn
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }
    }
}