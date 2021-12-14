using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using projem.entity;



namespace projem.Models
{
    public class Product
    {
        //El işi ürünün id, adı, açıklaması, fiyatı bulunabilir. 

        public int ProductId { get; set; }

        //Adı olması zorunludur.
        [Required(ErrorMessage="Name zorunlu bir alan.")]
        public string Name { get; set; }

        public double? Price { get; set; }

        [Required(ErrorMessage="Description zorunlu bir alan.")]
        [StringLength(100,MinimumLength=5,ErrorMessage="Description 5-100 karakter aralığında olmalıdır.")]
      
        public string Description { get; set; }    
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }

    }
}
