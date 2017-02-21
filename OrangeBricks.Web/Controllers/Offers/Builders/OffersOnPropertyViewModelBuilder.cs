using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class OffersOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public OffersOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public OffersOnPropertyViewModel Build(int id)
        {
            var property1 = _context.Properties
            .Include(x => x.Offers)
            .Where(p => p.Property_Id == id)
            .SingleOrDefault();

            var offers = property1.Offers ?? new List<Offer>();

            return new OffersOnPropertyViewModel
            {
                HasOffers = offers.Any(),
                Offers = offers.Select(x => new OfferViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    IsPending = x.Status == OfferStatus.Pending,
                    Status = x.Status.ToString(),
                    user = x.userId,

                    
                }),
                PropertyId = property1.Property_Id,
                PropertyType = property1.PropertyType,
                StreetName = property1.StreetName,
                NumberOfBedrooms = property1.NumberOfBedrooms
                
            };
        }
    }
}