using App.MvcWebUI.Entities;
using App.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MvcWebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private DataContext db = new DataContext();
        
        
        // GET: Order
        //Index: Sistemde kayıtlı olan tüm siparişleri versin.
        public ActionResult Index()
        {
            var orders = db.Orders
                .Select(i => new AdminOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total,
                    Count = i.Orderlines.Count
                })
                .OrderByDescending(i => i.OrderDate)
                .ToList();
            return View(orders);
        }
        
        
        //siparişlerin detay bilgisi için
        public ActionResult Details(int id)
        {
            var entity = db.Orders
                .Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    UserName=i.UserName,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBaslik = i.AdresBaslik,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKod = i.PostaKod,
                    Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name,
                        Price = a.Price,
                        Image = a.Product.files,
                        Quantity = a.Quantity
                    }).ToList()
                })
                .FirstOrDefault();
            return View(entity);
        }


        //siparişin durumunu update etmek için
        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders
                .Where(i => i.Id == OrderId)
                .FirstOrDefault();
            if (order !=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi.";

                return RedirectToAction("Details",new {id=OrderId});
            }

            return RedirectToAction("Index");
        }
    }
}