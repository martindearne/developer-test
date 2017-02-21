using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Models;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeOfferCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public MakeOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(MakeOfferCommand command)
        {
            
            var user = HttpContext.Current.User.Identity.GetUserId();
            var property = _context.Properties.Find(command.Property_Id);

            var offer = new Offer
            {
                Amount = command.Offer,
                Status = OfferStatus.Pending,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                userId = user

            };

            if (property.Offers == null)
            {
                property.Offers = new List<Offer>();
            }
                
            property.Offers.Add(offer);
            
            _context.SaveChanges();
        }
    }
}