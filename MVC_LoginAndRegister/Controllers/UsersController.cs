using MVC_LoginAndRegister.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVC_LoginAndRegister.Controllers
{
    
    public class UsersController : Controller
    {
        ApplicationDbContext myContext = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {

            return View("Index", new User());
        }
        public ActionResult ListUser()
        {
            var list = myContext.UsersLogin.ToList();
            return View(list);
        }
        public ActionResult Welcome()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register", new User());
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Password = Hashing.EnncryptPassword(user.Password);
            myContext.UsersLogin.Add(user);
            myContext.SaveChanges();
            MailMessage mm = new MailMessage("mridwan0706@gmail.com", user.Username);
            mm.Subject = "[Password]" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            mm.Body = "Hi " + user.Username + "\n This is Your New Password :" + user.Password;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("codeliveproject@gmail.com", "mypassword");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Password Has Benn Sent.Check Your Email to Login";
            return RedirectToAction("ListUser", "Users");
        }

        // GET: Users

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult LoginMember(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult LoginMember(User user)
        {
            var currentAccount = myContext.UsersLogin.FirstOrDefault(u => u.Username.Equals(user.Username));
            if (currentAccount != null)
            {
                if (BCrypt.Net.BCrypt.Verify(user.Password, currentAccount.Password))
                {
                    Session["id"] = user.Id;
                    Session.Add("username", user.Username);
                    //return View("Welcome");
                    return View("Welcome");
                }
                //else
                //{
                //    Session.Add("username", user.Username);
                //    return View("Welcome");
                //}
            }
            ViewBag.error = "Invalid";
            return View("Index");

        }

        public ActionResult Logout()
        {
            Session.Remove("id");
            Session.Remove("Username");

            return RedirectToAction("Index","Home");
        }

      

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var list = myContext.UsersLogin.Find(id);
            return View(list);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
