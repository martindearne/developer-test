using System;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Commands
{
    public class AcceptOfferCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public AcceptOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(AcceptOfferCommand command)
        {
            var offer = _context.Offers.Find(command.OfferId);
            var property = _context.Properties.Find(command.PropertyId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = OfferStatus.Accepted;
            property.IsListedForSale = false;

            _context.SaveChanges();
        }
    }
}