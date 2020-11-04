using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //Decoretor of ApiController
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController :ControllerBase
    {
          
    }
}