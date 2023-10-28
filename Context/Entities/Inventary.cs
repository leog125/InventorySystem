using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Entities
{
    public class Inventary //Camilo
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int WineryId { get; set; }

        [ForeignKey("WineryId")]
        public Winery Winery { get; set; }
        public bool State { get; set; }

    }
}
