using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace App.MvcWebUI.Entities
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>()
            {
                new Category(){Name="Kamera",Description="Kamera ürünleri"},
                new Category(){Name="Bilgisayar",Description="Bilgisayar ürünleri"},
                new Category(){Name="Telefon",Description="Telefon ürünleri"},
                new Category(){Name="Tablet",Description="Tablet ürünleri"},
                new Category(){Name="Televizyon",Description="Televizyon ürünleri"},
                new Category(){Name="Diğer",Description="Diğer ürünler"}
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product(){CategoryId=1, Name="Canon SJ4000 Canon SJ4000 Canon SJ4000",Description="SJCAM SJ4000 SJCAM SJ4000 SJCAM SJ4000 SJCAM SJ4000 Wi-Fi Full HD Aksiyon Kamerası",Price=399.93,Stock=100,IsApproved=true,IsHome=true,files="cam1.jpg"},
                new Product(){CategoryId=1,Name="Nikon A6000 Nikon A6000 Nikon A6000 Nikon A6000 Nikon A6000",Description="16-50mm Aynasız Dijital Fotoğraf Makinesi 16-50mm Aynasız Dijital Fotoğraf Makinesi 16-50mm Aynasız Dijital Fotoğraf Makinesi 16-50mm Aynasız Dijital Fotoğraf Makinesi",Price=2939.00,Stock=0,IsApproved=true,IsHome=true,files="cam2.jpg"},

                new Product(){CategoryId=2,Name="Dell Inspiron 3580 Dell Inspiron 3580 Dell Inspiron 3580",Description="Intel Core i5 8265U 8GB Intel Core i5 8265U 8GB Intel Core i5 8265U 8GB Intel Core i5 8265U 8GB Intel Core i5 8265U 8GB",Price=3499.00,Stock=100,IsApproved=true,IsHome=true,files="pc1.jpg"},
                new Product(){CategoryId=2,Name="HP 15-RA012NT HP 15-RA012NT HP 15-RA012NT HP 15-RA012NT HP 15-RA012NT",Description="Intel Celeron N3060 4GB Intel Celeron N3060 4GB Intel Celeron N3060 4GB Intel Celeron N3060 4GB",Price=1399.93,Stock=1000,IsApproved=true,IsHome=true,files="pc2.jpg"},

                new Product(){CategoryId=3,Name="Samsung Galaxy J7 Samsung Galaxy J7 Samsung Galaxy J7",Description="Prime 2 32 GB (Samsung Türkiye Garantili) Prime 2 32 GB (Samsung Türkiye Garantili) Prime 2 32 GB (Samsung Türkiye Garantili) Prime 2 32 GB (Samsung Türkiye Garantili)",Price=1299,Stock=100,IsApproved=true,IsHome=true,files="tel1.jpg"},
                new Product(){CategoryId=3,Name="Samsung Galaxy M20 Samsung Galaxy M20 Samsung Galaxy M20 Samsung Galaxy M20",Description="32 GB (Samsung Türkiye Garantili) 32 GB (Samsung Türkiye Garantili) 32 GB (Samsung Türkiye Garantili) 32 GB (Samsung Türkiye Garantili) 32 GB (Samsung Türkiye Garantili)",Price=1699.93,Stock=0,IsApproved=true,IsHome=true,files="tel2.jpg"},

                new Product(){CategoryId=4,Name="Samsung Tab4 Samsung Tab4 Samsung Tab4 Samsung Tab4",Description="Wi-Fi 3G tablet Wi-Fi 3G tablet Wi-Fi 3G tablet Wi-Fi 3G tablet",Price=399.93,Stock=100,IsApproved=true,IsHome=true,files="tab1.jpg"},
                new Product(){CategoryId=4,Name="Samsung Tab7 Samsung Tab7 Samsung Tab7 Samsung Tab7 Samsung Tab7",Description="Wi-Fi Full HD Tablet Wi-Fi Full HD Tablet Wi-Fi Full HD Tablet Wi-Fi Full HD Tablet",Price=799,Stock=100,IsApproved=true,IsHome=true,files="tab2.jpg"},

                new Product(){CategoryId=5,Name="Samsung Samsung 49NU7100 Samsung Samsung 49NU7100 Samsung Samsung 49NU7100",Description=" 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV",Price=500,Stock=0,IsApproved=true,IsHome=true,files="tv5.jpg"},
                new Product(){CategoryId=5,Name="Samsung Samsung 49NU7100 Samsung Samsung 49NU7100 Samsung Samsung 49NU7100",Description=" 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV",Price=500,Stock=0,IsApproved=true,IsHome=true,files="tv6.jpg"},
                new Product(){CategoryId=5,Name="Samsung Samsung 49NU7100 Samsung Samsung 49NU7100 Samsung Samsung 49NU7100",Description=" 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV 49' 122 Ekran 4K Uydu Alıcılı Smart LED TV",Price=500,Stock=0,IsApproved=true,IsHome=true,files="tv7.jpg"},
                new Product(){CategoryId=5,Name="Grundig Grundig 32VLE6730",Description="BP 32' 82 Ekran Uydu Alıcılı Full HD Smart LED TV",Price=399.93,Stock=100,IsApproved=true,IsHome=false,files="tv5.jpg"},
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}