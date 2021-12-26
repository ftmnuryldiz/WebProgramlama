using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebOdevim.Models
{
    public class UserDetails : IdentityUser
    {
        public string UserRealName { get; set; }
        public string UserSurname{ get; set; }
        public string UserSanalName { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public int ProductId{ get; set; }
        public string Role { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
    }
}