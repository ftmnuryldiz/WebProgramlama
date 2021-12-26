//Controller'ı programımıza dahil edebilelim. Kalıtım alalım diye kullanıldı
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebOdevim.Data;
using WebOdevim.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//Controller uygulamaya gelen isteklerin karşılandığı ve yönelndirildiği yer. 
namespace WebOdevim.Controllers
{
    //.net core içerisinde varolan daha önce oluşturulmuş olan Controller'ın yeteneklerini de kulanmamamız için:
    public class HomeController : Controller
    {
       

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
            //localhost:5000/home dediğinde controller'a geliyor. 
            //localhost:5000/home/index dediğinde buraya gelir.
            //Action ismi neyse onu ilgili view içinde arar. 
            public IActionResult Index()
        {
            //Product türündeki listemizi direkt view'a göndermek yerine ProductViewModel'a gönderiyoruz. Çünkü liste içinde bir sürü farklı tür var. 
            //var viewModel = new ProductViewModel();
            //viewModel.Products = _context.Product.ToList();
            var productViewModel = new ProductListViewModel()
            {
                Products = ProductRepository.Products
            };
            return View(productViewModel);
        }

            
        

        // Dinamik bir html sayfası geriye göndermek için return view diyoruz. 
        //Geriye dönen view IActionResult'dan dönen bir response. 
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            //MyView view'ın adı. String parametresi olarak bekliyor. HomeController'dan MyView adındaki view e gitmesini bu sağlıyor.
            return View("MyView");
        }
    }
}
