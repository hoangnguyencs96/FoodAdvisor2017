using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TheOnlineShop.Areas.Admin.Controllers
{
    public class GirlfriendController : Controller
    {
        // GET: Admin/Girlfriend
        public ActionResult Index()
        {
            GirlfriendDao gfd = new GirlfriendDao();
            List<Girlfriend> lgf = new List<Girlfriend>();
            lgf = gfd.Girlfriends.ToList();
            return View(lgf);
        }
    }
}