using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Models
{
    public class MailModel
    {
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
    }
}