using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using API.Errors;
namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notFound")]
        public ActionResult GetNotFoundRequest()
        {
            var testProduct = _context.Products.Find(-42);
            if (testProduct == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {   
            var testProduct = _context.Products.Find(42);
            var resultP = testProduct.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

         [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }


    }
}