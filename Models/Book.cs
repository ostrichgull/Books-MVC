using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Range(1, 10)]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }

        [Display(Name = "Book Cover")]
        public byte[] Image { get; set; }

        [ForeignKey("Person")]
        [Display(Name = "Author")]
        public int? PersonID { get; set; }

        [ForeignKey("Genre")]
        [Display(Name = "Genre")]
        public int? GenreID { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Person Person { get; set; }
    }
}