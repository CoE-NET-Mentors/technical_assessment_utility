using Microsoft.AspNetCore.Mvc;

namespace TechAssWeb.Controllers
{
    [Route("roadmaps"),ApiController]
    public class RoadmapsController : ControllerBase
    {
        [HttpGet("{roadmapId}")]
        public IActionResult GetRoadmap(string roadmapId)
        {
            if(System.IO.File.Exists($"./roadmaps/{roadmapId}.json"))
            {                
                return File(System.IO.File.OpenRead($"./roadmaps/{roadmapId}.json"), "application/json");
            }
            return NotFound();
        }

    }
}
