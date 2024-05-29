using Microsoft.AspNetCore.Mvc;
using myte.Models;

namespace myte.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            var model = new CalendarPageViewModel
            {
                WbsList = Repository.TodasAsWbs.ToList(),
                CalendarDays = GetCalendarDays(DateTime.Now, 1)
            };
            return View(model);
        }

        private List<CalendarViewModel> GetCalendarDays(DateTime date, int quinzena)
        {
            var days = new List<CalendarViewModel>();
            var year = date.Year;
            var month = date.Month;
            var startDay = quinzena == 1 ? 1 : 16;
            var endDay = quinzena == 1 ? 15 : DateTime.DaysInMonth(year, month);

            for (int day = startDay; day <= endDay; day++)
            {
                var dateTime = new DateTime(year, month, day);
                days.Add(new CalendarViewModel
                {
                    Day = day,
                    DayOfWeek = dateTime.DayOfWeek.ToString(),
                    
                    Hours = 0
                });
            }

            return days;
        }

        [HttpGet]
        public JsonResult GetDays(DateTime date, int quinzena)
        {
            var days = GetCalendarDays(date, quinzena);
            return Json(days);
        }

        [HttpGet]
        public JsonResult GetAllWbs()
        {
            var wbsList = Repository.TodasAsWbs.ToList();
            return Json(wbsList);
        }

        //adicionar action de create (mandar dados para o banco)

        //adicionar action de update 

        //action de delete --
    }
}
