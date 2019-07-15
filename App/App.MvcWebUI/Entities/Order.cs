using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public virtual List<OrderLine> Orderlines { get; set; }

        //siparişin gittiği adres bilgileri tutulmalı çünkü daha sonra adres bilgileri değişirse bundan
        //etkilenmemeli 
        public string UserName { get; set; }       
        public string AdresBaslik { get; set; }       
        public string Adres { get; set; }        
        public string Sehir { get; set; }
        public string Semt { get; set; }        
        public string Mahalle { get; set; }
        public string PostaKod { get; set; }
        
    }
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }//foreign key
        //lazy loading aktif hale getirmek için virtual keyword kullanıyoruz.
        public virtual Order Order { get; set; }//navigation property

        public int Quantity { get; set; }

        //ürünün o anki fiyatı tutulmalı.Daha sonra bu fiyat değişebilir.
        public double Price { get; set; }

        public int ProductId { get; set; }//foreign key
        public virtual Product Product { get; set; }//navigation property
    }
}