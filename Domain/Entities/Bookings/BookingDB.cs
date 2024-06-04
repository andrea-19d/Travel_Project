using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class BookingDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        /*--- DESTINATION DETAILS ----*/

        [Required]
        public int DestinationID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DestinationName { get; set; }

        /* --- USER DETAILS ---*/

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        
        /* --- BOOKING DETAILS --- */

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int TotalPeople { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [MaxLength(500)]
        public string Suggestions { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
    }
}
