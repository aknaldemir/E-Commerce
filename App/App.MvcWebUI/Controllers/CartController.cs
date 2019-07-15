using App.MvcWebUI.Entities;
using App.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {          
            
            return View(GetCart());
        }

        
        public ActionResult AddToCart(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            
            return Redirect("/Home/Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }


        public Cart GetCart()
        {            
            Cart cart = (Cart)Session["Cart"];
           //eğer oturumda bir sepet yok ise yeni sepet oluşturulur.
           //var ise o sepet gönderilir.
           //böylece her sepet ihtiyacında yeni sepet gönderilmesi olayının önüne geçmiş oluruz.
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
        
        public PartialViewResult Summary()
        {

            return PartialView(GetCart());
        }
     
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("NullProduct", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                //Siparişi veritabanına kaydet

                SaveOrder(cart, entity);




                //cart'ı temizle
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber= "S" + (new Random().Next(111111, 999999).ToString());
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.UserName = entity.UserName;
            order.AdresBaslik = entity.AdresBaslik;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKod = entity.PostaKod;           
            order.Orderlines = new List<OrderLine>();

            foreach (var pr in cart.CartLines)
            {
                OrderLine orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price =pr.Quantity*pr.Product.Price;
                orderline.ProductId = pr.Product.Id;
                order.Orderlines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}