using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City")]
        public string Name { get; set; }

        [ForeignKey("State")]
        [Display(Name = "State")]
        public int? StateID { get; set; }

        public virtual State State { get; set; }
    }
}