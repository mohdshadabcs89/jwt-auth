using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt_token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("product")]
        [Authorize]
        public IActionResult Product()
        {
            return Ok(new { ProductId=101,ProductName="Mobile"});
        }
        [HttpGet]
        [Route("admin")]
        [Authorize(Policy= "AdminOnly")]
        public IActionResult Admin()
        {
            return Ok(new { UserId = 101, UserName = "clark234" });
        }

        [HttpGet]
        [Route("role")]
        [Authorize(Roles = "HR,HRT")]
        public IActionResult role()
        {
            return Ok(new { UserId = 101, UserName = "role based " });
        }
    }
}
