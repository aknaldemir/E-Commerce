using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Entities
{
    public enum EnumOrderState
    {
        [Display(Name ="Tedarik Sürecinde")]
        Waiting,
        [Display(Name = "Sipariş Tamamlandı")]
        Completed
    }
}