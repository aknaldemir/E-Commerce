using App.MvcWebUI.Entities;
using App.MvcWebUI.Identity;
using App.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MvcWebUI.Controllers
{
 
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        
        [Authorize]
        public ActionResult Index()
        {           
            var orders = db.Orders
                .Where(i=>i.UserName==User.Identity.Name) 
                .Include(i => i.Orderlines)//sipariş detayı için index sayfasında kullanabiliriz. Eager Loading
                .Select(i => new UserOrderModel()
                {
                    Id=i.Id,
                    OrderDate=i.OrderDate,
                    OrderNumber=i.OrderNumber,
                    Total=i.Total,
                    OrderState=i.OrderState
                })
                .OrderByDescending(i=>i.OrderDate)
                .ToList();
            return View(orders);
        }



        //--------------------------------------------------
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders
                .Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel() {
                    OrderId=i.Id,
                    OrderNumber=i.OrderNumber,
                    Total=i.Total,
                    OrderDate=i.OrderDate,
                    OrderState=i.OrderState,
                    AdresBaslik=i.AdresBaslik,
                    Adres=i.Adres,
                    Sehir=i.Sehir,
                    Semt=i.Semt,
                    Mahalle=i.Mahalle,
                    PostaKod=i.PostaKod,
                    Orderlines=i.Orderlines.Select(a=> new OrderLineModel() {
                        ProductId=a.ProductId,
                        ProductName=a.Product.Name,
                        Price=a.Price,
                        Image=a.Product.files,
                        Quantity=a.Quantity
                    }).ToList()
                })
                .FirstOrDefault();
            return View(entity);
        }




        //--------------------------------------------------
        public ActionResult Register()
        {

            return View();
        }






        //--------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt İşlemleri
                ApplicationUser user = new ApplicationUser() {
                   Name=model.Name,
                   Surname=model.Surname,
                   UserName=model.UserName,
                   Email=model.Email
                };

                var result= UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //kullanıcı oluştu bir role atanabilir.
                  
                    if (RoleManager.RoleExists("user"))//User rolü varsa
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login","Account");
                }
                else
                {
                    ModelState.AddModelError("UserCreateProblem", "Kullanıcı oluşturma hatası");
                }


            }
            return View(model);
        }






        //--------------------------------------------------
        public ActionResult Login()
        {

            return View();
        }






        //--------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login İşlemleri
                var user=UserManager.Find(model.UserName, model.Password);
                if (user!=null)
                {
                    //varolan kullanıcıyı sisteme dahil et.
                    //ApplicationCookie oluşturup sisteme bırak
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = model.RememberMe
                    };
                    authManager.SignOut();
                    authManager.SignIn(authProperties, identityclaims);
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Kullanıcı Login Hatası");
                }
               


            }
            return View(model);
        }







        //--------------------------------------------------
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            
            Session.Abandon();//sepetin içerisini kullanıcı çıkış yaptığı anda boşaltıyoruz.
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }
    }
}