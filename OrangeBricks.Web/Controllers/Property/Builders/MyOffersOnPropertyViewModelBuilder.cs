using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MyOffersOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersOnPropertyViewModel Build(string userId)
        {
            //string userName = GetUserName(userId); 
            var property1 = _context.Properties
                .Join(_context.Offers,
                prop => prop.Property_Id,
                offs => offs.property.Property_Id,
                (prop, offs) => new { Prop = prop, Offs = offs })
                .Where(p => p.Offs.userId == userId);
            
            return new MyOffersOnPropertyViewModel
            {
                Offers = property1.Select(x => new MyOfferViewModel
                {
                    Id = x.Offs.Id,
                    Amount = x.Offs.Amount,
                    CreatedAt = x.Offs.CreatedAt,
                    IsPending = x.Offs.Status == OfferStatus.Pending,
                    Status = x.Offs.Status.ToString(),
                    user  = x.Prop.SellerUserId,
                    Property_Id = x.Prop.Property_Id,
                    PropertyType = x.Prop.PropertyType,
                    description = x.Prop.Description,
                    StreetName = x.Prop.StreetName,
                    NumberOfBedrooms = x.Prop.NumberOfBedrooms
                }
                ),
            };

        }

    }
    public class username
    {
        public string GetUserName(string userId)
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId).UserName;
        }
    }
}