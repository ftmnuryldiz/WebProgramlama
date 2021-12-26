//Veri ek açıklama doğrulayıcıları için kullandım:
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//Tek tek controller'da değişkenleri viewbag'le view'e göndermek yerine models oluşturmak çok daha kolay.
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebOdevim.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        //Ürünün adı zorunludur ve karakter sınırı vardır. 
        [Required]
        [StringLength(60,MinimumLength=5,ErrorMessage="Ürün ismi 5-60 karakter arasında olmalıdır.")]
        [Display(Prompt = "Ürünün adını girmeniz zorunludur.")]
        public string Name { get; set; }

        [Display(Prompt = "Ürünün fiyatını girmeniz zorunludur.")]
        [Required(ErrorMessage="Fiyat Girmelisiniz.")]
        [Range(1,10000)]
        //? koymazsam default olarak create kısmında 0 yazar. O yüzden null olabilmesi lazım. 
        public double? Price { get; set; } 
        public string Description { get; set; } 
         [Required]
        public string ImageUrl { get; set; }    
        [Required]

        //Kategoriyle ilişkisi için:
       
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public  Category Category { get; set; }

        public List<Category> SelectedCategories { get; set; }

    }
}