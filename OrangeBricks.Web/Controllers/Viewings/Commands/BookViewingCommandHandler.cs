using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings.Commands
{
    
    public class BookViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;
        public BookViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookViewingCommand command)
        {
            var property = _context.Properties.Find(command.Property_Id);

            var booking = new Viewing
            {
                dateTimeBooking = command.dateTimeBooking,
                userId = command.userId,
                status = ViewingStatus.Pending,
            };

            if (property.Viewings == null)
            {
                property.Viewings = new List<Viewing>();
            }

            property.Viewings.Add(booking);

            _context.SaveChanges();
            
        }
    }
}