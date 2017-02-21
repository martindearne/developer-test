using System;
using OrangeBricks.Web.Controllers.Viewings.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings.Builder
{
    public class ViewingViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;
        public ViewingViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ViewingsViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);

            return new ViewingsViewModel
            {
                Property_Id = id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                dateTimeBooking = DateTime.Now
            };
        }
    }
}