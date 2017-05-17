using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class State
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "State")]
        public string Name { get; set; }

        [ForeignKey("Country")]
        [Display(Name = "Country")]
        public int? CountryID { get; set; }

        public virtual Country Country { get; set; }
    }
}