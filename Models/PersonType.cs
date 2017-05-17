using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public enum PersonTypeValue
    {
        Patron = 1,
        Author = 2
    }

    public class PersonType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Person Type")]
        public string Name { get; set; }
    }
}