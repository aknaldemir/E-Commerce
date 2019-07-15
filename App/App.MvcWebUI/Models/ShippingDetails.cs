using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Models
{
    public class ShippingDetails
    {
        
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad giriniz.")]
        public string UserName { get; set; }

        [Display(Name ="Adres Tanımı")]
        [Required(ErrorMessage ="Lütfen adres tanımı giriniz.")]
        public string AdresBaslik { get; set; }

        [Display(Name = "Adres Bilgisi")]
        [Required(ErrorMessage = "Lütfen adres giriniz.")]
        public string Adres { get; set; }

        [Display(Name = "Şehir")]
        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string Sehir { get; set; }

       
        [Required(ErrorMessage = "Lütfen semt giriniz.")]
        public string Semt { get; set; }

        
        [Required(ErrorMessage = "Lütfen mahalle giriniz.")]
        public string Mahalle { get; set; }
        
        public string PostaKod { get; set; }
    }
}