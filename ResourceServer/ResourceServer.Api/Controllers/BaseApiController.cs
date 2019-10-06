using Microsoft.AspNetCore.Mvc;

namespace ResourceServer.Api.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
