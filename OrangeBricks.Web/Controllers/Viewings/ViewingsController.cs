using System;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Controllers.Viewings.Commands;
using OrangeBricks.Web.Controllers.Viewings.Builder;
using OrangeBricks.Web.Models;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Viewings
{
    public class ViewingsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public ViewingsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        // GET: Viewings
        public ActionResult Viewings(int id)
        {
            var builder = new ViewingViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }

        public ActionResult BookViewing(BookViewingCommand command)
        {
            var handler = new BookViewingCommandHandler(_context);
            command.userId = User.Identity.GetUserId();

            handler.Handle(command);

            return RedirectToAction("Index", "Property");
        }
    }
}
