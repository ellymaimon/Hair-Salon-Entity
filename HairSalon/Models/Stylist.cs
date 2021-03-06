using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Models
{
    [Table("stylists")]
    public class Stylist
    {
        [Key]
        public int StylistId { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}