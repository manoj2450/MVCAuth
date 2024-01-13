using Authorasation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Authorasation.Controllers
{
    [AllowAnonymous]//to exclude from autorazation 
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            EmployeeEntities3 emp = new EmployeeEntities3();
            var count = emp.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).Count();
            if (count == 0)
            {
                ViewBag.msg = "User is Invalid !!!";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Home");
               
            }
            

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Account");
        }
    }
}