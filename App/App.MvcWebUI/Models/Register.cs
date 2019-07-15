using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Models
{
    public class Register
    {
        [Required]
        [Display(Name="Adınız")]
        public string Name { get; set; }

        [Display(Name = "Soyadınız")]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Eposta")]
        [Required]
        [EmailAddress(ErrorMessage ="Eposta adresinizi kontrol ediniz.")]
        public string  Email { get; set; }

        [Display(Name = "Parola")]
            
        public string Password { get; set; }

        [Required]
        [Display(Name = "Parola Tekrar")]
        [Compare("Password",ErrorMessage ="Parola eşleşmeli")]
        public string RePassword { get; set; }
    }
}