using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Patient")]
        public ActionResult GetConfig()
        {
            return Ok("Test Success");
        }
    }
}
