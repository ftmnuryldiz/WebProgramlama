using System.Collections.Generic;
using System.Linq;
using WebOdevim.Models;
namespace WebOdevim.Data
{
    public class ProductRepository
    {
        private static List<Product> _products = null;

        static ProductRepository()
        {
            _products = new List<Product>
            {
                new Product {ProductId=1,Name="Chelsea Şal",Price=350,Description="Sadeliği sevenler için buluştu. ", ImageUrl="sal1.jpg",CategoryId=1},
                  new Product {ProductId=2,Name="Dream Şal",Price=450,Description="Pembe rengiyle hayallerinize renk katacak.", ImageUrl="sal2.jpg",CategoryId=1},
                new Product {ProductId=3,Name="RainBow Şapka",Price=80,Description="İçinizi sıcak sararken, dünyanız renklensin.", ImageUrl="sapka1.jpeg",CategoryId=2},
                new Product {ProductId=4,Name="Elizabeth Yelek",Price=450,Description="Kraliyet ailesi asilliğinde, siz sevenlerimiz için.", ImageUrl="yelek1.png",CategoryId=3},
                new Product {ProductId=5,Name="Yeni Başlangıçlar Yelek",Price=500 ,Description="Yeni başlangıçlarınız temizliğinde ve asilliğinde. ", ImageUrl="yelek2.jpg",CategoryId=3},
                new Product {ProductId=6,Name="Eski Sevgilim Atkı",Price=200,Description="Eski sevgiliniz gibi sarıp sarmalayacak ama asla bırakmayacak bir atkı.", ImageUrl="atki1.jpg",CategoryId=4},
                new Product {ProductId=7,Name="Beyaz Düşler Atkı",Price=4000,Description="Yalnızlığında sımsıkı sarılabileceğiniz yumuşacık bir atkı.", ImageUrl="atki2.jpg",CategoryId=4},
                new Product {ProductId=8,Name="Kaynanam Seviyor Oya",Price=5000,Description="Kaynanız artık siz hep sevecek!", ImageUrl="oya1.jpg",CategoryId=5},
           
            };
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public static Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        public static void EditProduct(Product product)
        {
            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.ImageUrl = product.ImageUrl;
                    p.Description = product.Description;
                    p.CategoryId = product.CategoryId;
                }
            }
        }

        public static void DeleteProduct(int id)
        {
            var product = GetProductById(id);

            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}