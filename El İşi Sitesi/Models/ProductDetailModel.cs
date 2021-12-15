using ElİsiSitesi.Models;
using System.Collections.Generic;


namespace ElIsiSitesi.Models
{
    public class ProductDetailModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
