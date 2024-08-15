using Microsoft.AspNetCore.Mvc;

namespace Departments.Service_A.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : Controller
    {
        private static readonly string[] Statuses = new[]
        {
            "Активно", "Заблокировано"
        };


        public StatusController() { }

        [HttpGet("[action]")]
        public ActionResult GetStatusByDepartmentId(Guid departmantId)
        {
            return Ok(Statuses[Random.Shared.Next(Statuses.Length)]);
        }

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
