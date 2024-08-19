using Departments.Service_A.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Departments.Service_A.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(AccessFilterAttribute))]
    public class StatusController : Controller
    {
        private static readonly string[] Statuses = new[]
        {
            "Активно", "Заблокировано"
        };

        [HttpPost("[action]")]
        public ActionResult GetStatusesByDepartmentIds(List<Guid> guids)
        {
            var statusDictionary = guids.ToDictionary(
                guid => guid,
                _ => Statuses[Random.Shared.Next(Statuses.Length)]
                );

            return Ok(statusDictionary);
        }
    }
}
