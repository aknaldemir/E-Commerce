using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Entities
{
    public class Category
    {
        
        public int Id { get; set; }

        [Display(Name="Kategori Adı")]
        public string Name { get; set; }

        [Display(Name = "Kategori Açıklaması")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}