using Microsoft.AspNetCore.Mvc;
using ConsumingAPIs.Models;
using Flurl.Http;
using Flurl;

namespace ConsumingAPIs.Controllers
{
    public class CalendarificController : Controller
    {
        public IActionResult Index()
        {
            CalendarificHolidayApi cal = new CalendarificHolidayApi();
            int year = DateTime.Today.Year;
            int day = DateTime.Today.Day;
            int month = DateTime.Today.Month;
            var apiUri = "https://calendarific.com/api/v2/holidays"
                .AppendPathSegment("endpoint")
                .SetQueryParams(new
                {
                    api_key = "55eac13a34033fb363cb23faefc2ff601334ddb1",
                    year = year,
                    day = day,
                    month = month,
                    country = "US",
                    type = "observance"
                })
                .SetFragment("after-hash");
            var apiTask = apiUri.GetJsonAsync<IEnumerable<CalendarificHolidayApi>>();
            apiTask.Wait();
            IEnumerable<CalendarificHolidayApi> result = apiTask.Result;
            return View(result);
        }
    }
}
