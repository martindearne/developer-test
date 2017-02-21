using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Viewings.ViewModels
{
    public class ViewingsViewModel
    {
        public int id { get; set; }
        public DateTime dateTimeBooking { get; set; }
        public string userId {get; set;}

        public int Property_Id { get; set; }

        public string PropertyType { get; set; }
        public string StreetName { get; set; }

        public ViewingStatus status { get; set; }
    }
}