using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Models
{
    [Table("clients")]
    public class Client
    {
        public Client()
        {
            this.Stylists = new HashSet<Stylist>(); //The HashSet we create in the constructor can help avoid exceptions 
                                                    //when no records exist in the "many" side of the relationship, but is not required.
        }

        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Stylist> Stylists { get; set; }
    }
}