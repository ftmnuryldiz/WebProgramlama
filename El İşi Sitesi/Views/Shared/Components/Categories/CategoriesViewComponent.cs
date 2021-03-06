using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebOdevim.Data;
using WebOdevim.Models;

namespace WebOdevim.ViewComponents
    //[View Component] şeklinde de yapılabilirdi.
{
    public class CategoriesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["action"].ToString()=="list")
                ViewBag.SelectedCategory = RouteData?.Values["id"];
            return View(CategoryRepository.Categories);
        }
        
    }
}
