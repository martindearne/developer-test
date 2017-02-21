using System;
using OrangeBricks.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Controllers.Viewings.Commands
{
    public class BookViewingCommand
    {
        [Required]
        public DateTime dateTimeBooking { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public int Property_Id { get; set; }
        [Required]
        public ViewingStatus status { get; set; }


    }
}