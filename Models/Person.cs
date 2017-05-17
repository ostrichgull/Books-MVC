using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required]
        [Display(Name = "Address Number")]
        public int Number { get; set; }

        [StringLength(5)]
        [Display(Name = "Address Extension")]
        public string Extension { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(25)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("Gender")]
        [Display(Name = "Gender")]
        public int? GenderID { get; set; }

        [ForeignKey("City")]
        [Display(Name = "City")]
        public int? CityID { get; set; }

        [ForeignKey("CityAddress")]
        [Display(Name = "City")]
        public int? CityAddressID { get; set; }

        [ForeignKey("PersonType")]
        [Display(Name = "Type")]
        public int? PersonTypeID { get; set; }

        public virtual PersonType PersonType { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual City CityAddress { get; set; }
        public virtual City City { get; set; }
    }
}