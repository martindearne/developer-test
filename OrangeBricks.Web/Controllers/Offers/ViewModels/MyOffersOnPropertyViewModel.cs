using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class MyOffersOnPropertyViewModel
    {
        public IEnumerable<MyOfferViewModel> Offers { get; set; }
    }

    public class MyOfferViewModel
    {
        public int Property_Id { get; set; }
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }

        public string description { get; set; }
        public string StreetName { get; set; }


        public int Id;
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPending { get; set; }
        public string Status { get; set; }
        public string user { get; set; }
    }
}