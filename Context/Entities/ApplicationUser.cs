using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [NotMapped]  // No se agrega a la tabla
        public string Role { get; set; }
    }
}
