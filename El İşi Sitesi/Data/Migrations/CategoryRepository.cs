//Veri tabanı oluşturmadan önce örnek iki repository oluşturdum. Burada ürünlerin örnek listeleri var
using System.Collections.Generic;
using System.Linq;
using WebOdevim.Models;
namespace WebOdevim.Data
{
    public class CategoryRepository
    {
        private static List<Category> _categories=null;
  
        static CategoryRepository()
        {
          
            _categories = new List<Category>
            {
                new Category {CategoryId=1,Name="Şallar",Description="Şal Kategorisi"},
                new Category {CategoryId=2,Name="Şapkalar",Description="Şapka Kategorisi"},
                new Category {CategoryId=3,Name="Yelekler",Description="Yelekler Kategorisi"},
                new Category {CategoryId=4,Name="Atkılar",Description="Atkılar Kategorisi"},
                 new Category {CategoryId=5,Name="Oyalar",Description="Oyalar Kategorisi"},
                  new Category {CategoryId=6,Name="Patikler",Description="Patikler Kategorisi"},
            };
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public static Category GetCategorybyId(int id)
        {
            return _categories.FirstOrDefault(c=>c.CategoryId==id);
        }



    }

   
}