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
            // TODO: Implement method
            // Create ViewModel with TotalPrice or pass it through ViewBag/ViewData
            throw new NotImplementedException();
        }
    }
}
