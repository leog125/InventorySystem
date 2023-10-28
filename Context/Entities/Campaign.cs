using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Entities
{

    public class Campaign //Jhon
    {
        [Key]
        public int Id { get; set; }

        //[MaxLength(80)]
        public string Nombre { get; set; }

        //[MaxLength(200)]
        public string Descripcion { get; set; }

        //[MaxLength(60)]
        public string Pais { get; set; }

        //[MaxLength(60)]
        public string Ciudad { get; set; }

        //[MaxLength(100)]
        public string Address { get; set; }

        //[MaxLength(40)]
        public string Phone { get; set; }
        public string CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        public ApplicationUser CreatedBy { get; set; }

        public string UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public ApplicationUser UpdatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
