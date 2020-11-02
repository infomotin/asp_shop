using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController :BaseApiController
    {
        [HttpGet("notFound")]
        public ActionResult GetNotFoundRequest(){
            
        }
        
    }
}