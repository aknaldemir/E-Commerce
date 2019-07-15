using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Models
{
    public class Login
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required]
        public string UserName { get; set; }        

        [Display(Name = "Parola")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}