using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EWSApplication.BussinessLayers;
using EWSApplication.Entities.DBContext;

namespace EWSApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index(string mode = "all")
        {
            List<Post> lst = new List<Post>();
            // xử lí mode render
            // mode = all ->> GetAllPost
            // mode = popular ->> GetTopPopularPost
            // mode = topview ->> GetTopViewpost
            // mode = lastest ->> GetTopLastPost
            if(mode == "all")
            {
                lst= PostBLL.Post_GetAllPost();
            }
            if (mode == "popular")
            {
                lst =PostBLL.Post_GetTopPopularPost();
            }
            if (mode == "topview")
            {
                lst= PostBLL.Post_GetTopViewPost();
            }
            if (mode == "lastest")
            {
                lst= PostBLL.Post_GetTopLastPost();
            }
            return View(lst);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
                var userInfo = SystemBLL.System_Login(userName, password);
            if (userInfo == null)
            {
                ModelState.AddModelError("", "Login Failed!");
                return View();
            }
            Session["uid"] = userInfo.userid;
            FormsAuthentication.SetAuthCookie("isLogin", false);
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}