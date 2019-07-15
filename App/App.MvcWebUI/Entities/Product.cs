using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        public double Price { get; set; }

        [DisplayName("Stok Adet")]
        public int Stock { get; set; }

        [DisplayName("Ürün Resmi")]
        public string files { get; set; }

        [DisplayName("Onay Durumu")]
        public bool IsApproved { get; set; }

        [DisplayName("Anasayfa Ürünü")]
        public bool IsHome { get; set; }

        [DisplayName("Kategori Adı")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

   
    }
}