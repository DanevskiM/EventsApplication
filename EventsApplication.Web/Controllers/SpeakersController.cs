using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;

namespace EventsApplication.Web.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService _speakerService;
        private readonly IEventService _eventService;

        public SpeakersController(ISpeakerService speakerService, IEventService eventService)
        {
            _speakerService = speakerService;
            _eventService = eventService;
        }

        // GET: Speakers
        public IActionResult Index()
        {
            return View(_speakerService.GetAll());
        }

        // GET: Speakers/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = _speakerService.GetById(id.Value);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // GET: Speakers/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_eventService.GetAll(), "Id", "Title");
            return View();
        }

        // POST: Speakers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Topic,EventId")] Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                _speakerService.Insert(speaker);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_eventService.GetAll(), "Id", "Title", speaker.EventId);
            return View(speaker);
        }

        // GET: Speakers/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = _speakerService.GetById(id.Value);
            if (speaker == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_eventService.GetAll(), "Id", "Title", speaker.EventId);
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Topic,EventId")] Speaker speaker)
        {
            if (id != speaker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _speakerService.Update(speaker);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerExists(speaker.Id))
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
            ViewData["EventId"] = new SelectList(_eventService.GetAll(), "Id", "Title", speaker.EventId);
            return View(speaker);
        }

        // GET: Speakers/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = _speakerService.GetById(id.Value);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var speaker = _speakerService.GetById(id);
            if (speaker != null)
            {
                _speakerService.DeleteById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SpeakerExists(Guid id)
        {
            return _speakerService.GetById(id) != null;
        }
    }
}
