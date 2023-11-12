using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            CSCPP.Class1 instance = new CSCPP.Class1();
            Console.WriteLine(instance.GetText());

            return instance.GetText();
        }
    }
}
