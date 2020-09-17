using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gig
    {
        //who, when, where, what genre
        //who - already declared by default in identity model (renamed to application user), we call it
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; } // foreign key to user table

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }
        // we do not want to duplicate genre in database, so we create seperate class to store it

        [Required]
        public byte GenreId { get; set; } // foreign key to Genre table
    }
}