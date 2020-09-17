using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate] // self-written validation, check viewModel folder for futureDate.cs
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; } // genre id from user input

        public IEnumerable<Genre> Genres { get; set; } // for genre dropdown list from database

        public DateTime GetDateTime() {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time)); // return combined string in datetime format
        }
    }
}