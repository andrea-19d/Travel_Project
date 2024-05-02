using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bookings
{
    public class UAddressTable
    {
        [Key]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "First Name cannot be longer than 30 characters.")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name ")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Last Name  cannot be longer than 30 characters.")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "City")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "City cannot be longer than 20 characters.")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Region")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 20 characters.")]
        public string Region { get; set; }
    }
}
