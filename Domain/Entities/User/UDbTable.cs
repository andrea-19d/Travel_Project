using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class UDbTable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int UserId { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        [StringLength(31, MinimumLength = 1, ErrorMessage = "First Name cannot be longer than 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Last Name cannot be longer than 30 characters.")]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string Username { get; set; }
        
        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        public string Password { get; set; }

        public string UserIP { get; set; }

        public DateTime RegisterDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }

        public LevelAcces Level { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}

