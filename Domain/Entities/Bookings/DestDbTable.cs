using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bookings
{
    public class DestDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DestinationID { get; set; }

        [Required]
        [Display(Name = "Destination")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Destination cannot be longer than 30 characters.")]
        public string DestinationName { get; set; }
        [Required]
        public string Country { get; set; }
        public string City { get; set; }
        [Required]
        public int Days { get; set; }
        public int NrOfPersons { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
        public int Rating { get; set; }
        public byte[] Img { get; set; }
    }
}
