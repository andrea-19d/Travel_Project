using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;

namespace Domain.Entities.Bookings
{
    public class BookingDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        public int DestinationID { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int NrOfPeople { get; set; }
     }


}
