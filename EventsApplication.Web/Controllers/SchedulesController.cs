using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EventsApplication.Web.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET: Schedules/Details/5

        public IActionResult Details(Guid id)
        {
            var schedule = _scheduleService.GetScheduleDetails(id);
            if (schedule == null)
                return NotFound();
            var totalPrice = schedule.EventInSchedules != null
                ? schedule.EventInSchedules
                    .Where(eis => eis.Event != null)
                    .Sum(eis => eis.Event.Price)
                : 0;
            ViewBag.TotalPrice = totalPrice;
            return View(schedule);
        }
    }
}
