using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElİsiSitesi.Models
{
    //Ürünümüzün ad, fiyat, id, açıklama, kategori id'si gibi özellikleri olur. 
    public class Urun
    {
        //DataAnnotations'u ekliyoruz.  
        //UrunAdi zorunludur ve 10-60 karakter arası olmalıdır.

        [Required]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Ürün ismi 10-60 karakter arasında olmalıdır.")]
        public string urunAdi { get; set; }

        [Required(ErrorMessage = "Fiyat Girmelisiniz.")]
        [Range(1, 10000)]
        //Null değer atınımı için ? kullanıldı.(double normalde null almazdı.)
        public double? Price { get; set; }

        public string Description { get; set; }

        //Ürün linki ve kategori idsi zorunlu.
        [Required]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }

        [Required]
        public int? CategoryId { get; set; }
    }
}
