using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EventsApplication.Web.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly IRegisrationService _regisrationService;
        private readonly IAttendeeService _attendeeService;

        public RegistrationsController(IRegisrationService regisrationService, IAttendeeService attendeeService)
        {
            _regisrationService = regisrationService;
            _attendeeService = attendeeService;
        }

        // GET: Registrations
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View(_regisrationService.GetAllByCurrentUser(userId));
        }

        // GET: Registrations/Create
        [Authorize]
        public IActionResult Create(Guid eventId)
        {
            ViewData["EventId"] = eventId;
            ViewData["AttendeeId"] = new SelectList(_attendeeService.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: Registrations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("Id,RegistrationDate,PaymentStatus,EventId,AttendeeId")] Registration registration)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _regisrationService.RegisterAttendeeOnEvent(userId, registration.AttendeeId, registration.EventId, registration.PaymentStatus);
            return RedirectToAction(nameof(Index));
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            // TODO: Implement method
            throw new NotImplementedException();
        }

        // POST: Registrations/CreateSchedule
        [HttpPost, ActionName("CreateSchedule")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult CreateSchedule()
        {
            // TODO: Implement method
            // Find current user, call service method, redirect to details in schedules controller
            throw new NotImplementedException();
        }
    }
}
