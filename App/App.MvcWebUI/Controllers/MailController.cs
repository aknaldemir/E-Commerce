using App.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace App.MvcWebUI.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MailModel model)
        {
            //mail gönderme işlemi yapacağız. Bunun için bize host controlden aldığımız mail adresi,kullanıcı adı,parola ve
            //server adresi gerekli//bunları web.config dosyası altında tanımlıyoruz.
            //bunun sebebi uygulama boyunca ne zaman bu bilgilere ihtiyacımız olsa buradan alabiliriz.

            //web.config te appsetting'lere ulaşmak için  
            string server = ConfigurationManager.AppSettings["server"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            //eğer ssl 1 ise true 0 ise false 
            bool ssl = ConfigurationManager.AppSettings["ssl"].ToString() == "1" ? true : false;

            //from maili ile oluşturduğumuz mail adresinin serverina bağlanacağız ve kullanıcı adı parola vereceğiz
            string from = ConfigurationManager.AppSettings["from"];

            string password = ConfigurationManager.AppSettings["password"];

            string fromname = ConfigurationManager.AppSettings["fromname"];
            //from mailden to mailine mail göndereceğiz
            string to = ConfigurationManager.AppSettings["to"];

            //smtp client oluşturalım.
            var client = new SmtpClient()
            {
                //server bilgileri
                Host = server,
                Port = port,
                EnableSsl = ssl,
                UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential(from, password),//kendi mail server'ımıza bağlandık.
            };

            //göndereceğimiz mail
            var email = new MailMessage();
            email.From = new MailAddress(from, fromname);//mailin kimden gittiği
            email.To.Add(to);//kime geldiği

            //mail için konu
            email.Subject = model.Konu;

            email.IsBodyHtml = true;//html içeriği gönderebiliriz

            email.Body = $"ad soyad : {model.AdSoyad} \n konu : {model.Konu} \n mesaj : {model.Mesaj} \n eposta : {model.Email}";



            try
            {
                client.Send(email);//maili gönder 
                ViewData["result"] = true;//mail gitmiş ise result true olsun
            }
            catch (Exception)
            {
                ViewData["result"] = false;//mail ile ilgili hata varsa false olsun.

            }



            return View();
        }
    }
}