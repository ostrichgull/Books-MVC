using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Rental
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Book")]
        [Display(Name = "Book Title")]
        public int? BookID { get; set; }

        [ForeignKey("Person")]
        [Display(Name = "Patron")]
        public int? PersonID { get; set; }

        [Required]
        [Display(Name = "Rental Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Required]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }

        public virtual Book Book { get; set; }
        public virtual Person Person { get; set; }
    }
}