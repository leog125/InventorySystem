using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Entities
{
    public class InventaryDetail //Leonardo
    {
        [Key]
        public int Id { get; set; }
        public int InventaryId { get; set; }
        [ForeignKey("InventaryId")]
        public Inventary Inventary { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int StockPrevious { get; set; }
        public int Amount { get; set; }

    }
}
