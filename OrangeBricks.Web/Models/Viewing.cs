using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Key]
        public int id { get; set; }
        public Property property { get; set; }
        public DateTime dateTimeBooking { get; set; }
        public string userId { get; set; }

        public ViewingStatus status { get; set; }
    }
}