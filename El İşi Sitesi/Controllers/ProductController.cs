using System;
using System.Collections.Generic;
using System.Linq;
//Controller'ı programımıza dahil edebilelim. Kalıtım alalım diye kullandım:
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebOdevim.Data;
using WebOdevim.Models;

namespace WebOdevim.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {

            var product = new Product { Name = "Şallar", Price = 400, Description = "El emeği göz nuru, güzel mi güzel şallar. " };
            //    //Üç çeşit view'e veri aktarım yöntemi var. Model, ViewData, ViewBag. Onlardan ViewData'yı kullandım. 
            ViewData["Category"] = "Şallar";

            return View(product);
        }

        //Tanımlamış olduğun listeyi sayfaya göndermek:
        //Controller içerisindeki metodlar aynı addaki view'den içeriğini alır. 
        public IActionResult list(int? id, string q, double? min_price, double? max_price)
        {
            var products = ProductRepository.Products;

            if (id != null)
            {
                products = products.Where(p => p.CategoryId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                products = products.Where(i => i.Name.Contains(q) || i.Description.Contains(q)).ToList();
            }

            var productViewModel = new ProductListViewModel()
            {
                Products = products
            };

            return View(productViewModel);
        }




        //Biz Edit, Create viewler'ında Post kulandığımız için HttpGet'ler sadece formu döndürürken bir tane daha Post olmak zorunda.
        //İlk önce default olan [HttpGet] e gider. Sonra sen Create'de kaydet dediğin anda formumuzun tipi Post olduğu için [HttpPost] olana geçer.
        //Yüklenir yüklenmez kategorileri getirmek için:
        public IActionResult Create()
        {
            //Create kısmında SelectList beklediğinden dolayı (Alt alta yazacaklar) 
            //Birinci paremetre senin gönderecek olduğun liste, dataValueField: CategoryId, dataTextField: Name
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            //Referansı yoktu Create.html'de ne aççak.
            Product product2 = new Product();
            return View(product2);
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            //Beklediğin valid değerleri oluşmuş mu kontrolü, kurallara uyuyor mu product nesnesi 

            if (ModelState.IsValid)
            {
                ProductRepository.AddProduct(p);
                return RedirectToAction("list");
            }
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");

            return View(p);

        }


        // Varsayılan olarak [HttpGet]
        public IActionResult Details(int id)
        {

            return View(ProductRepository.GetProductById(id));


        }


        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View(ProductRepository.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductRepository.EditProduct(product);
            return RedirectToAction("list");
        }

        [HttpPost]
        public IActionResult Delete(int ProductId)
        {


            ProductRepository.DeleteProduct(ProductId);
            return RedirectToAction("list");

        }
    }
}