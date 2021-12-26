using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//Bir kategorinin ad�, a��klamas� ve Id'si olur. 
namespace WebOdevim.Models
{

    public class Category
    {
     [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //Liste i�erdi�ini belirtmek i�in:
        public List<Product> Products { get; set; }
     

        //public ICollection<Product> Products{get; set;} demedim yava�lama yapar. 

    }
}