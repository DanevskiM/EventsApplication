using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;

namespace EventsApplication.Web.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly IAttendeeService _attendeeService;

        public AttendeesController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        // GET: Attendees
        public IActionResult Index()
        {
            return View(_attendeeService.GetAll());
        }

        // GET: Attendees/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = _attendeeService.GetById(id.Value);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // GET: Attendees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,DateOfBirth,TicketNumber")] Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                _attendeeService.Insert(attendee);
                return RedirectToAction(nameof(Index));
            }
            return View(attendee);
        }

        // GET: Attendees/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = _attendeeService.GetById(id.Value);
            if (attendee == null)
            {
                return NotFound();
            }
            return View(attendee);
        }

        // POST: Attendees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,FirstName,LastName,DateOfBirth,TicketNumber")] Attendee attendee)
        {
            if (id != attendee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _attendeeService.Update(attendee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendeeExists(attendee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(attendee);
        }

        // GET: Attendees/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = _attendeeService.GetById(id.Value);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // POST: Attendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var attendee = _attendeeService.GetById(id);
            if (attendee != null)
            {
                _attendeeService.DeleteById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AttendeeExists(Guid id)
        {
            return _attendeeService.GetById(id) != null;
        }
    }
}
